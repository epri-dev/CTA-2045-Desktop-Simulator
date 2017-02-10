// Written by Gary Aumaugher based on work by Nick Gammon
// December 2013
// SPI pin definitions
//    MISO  D-12
//    MOSI  D-11
//    SS    D-10  Select
//    SCK   D-13  Clock
//    ATN   D-9   Attention
//    LED   D-8

#include "pins_arduino.h"

#define RESET 6
#define MODDET 7
#define DEBUG 8
#define ATTENTION 9
#define SS 10
#define MOSI 11
#define MISO 12
#define SCK 13

byte command = 0;
byte c;
boolean newchar = false;
byte simRxBuf[256];
byte spiRxBuf[256];
int simRxCount = 0;
int spiRxCount = 0;
int spiTxCount = 0;
int spiMsgSize = 0;
boolean receiving = false;
boolean sending = false;
byte spiTxData;

//******************************************************
// Setup routine                                       *
//******************************************************
void setup (void)
{
  
  Serial.begin (115200);
  pinMode(RESET, INPUT);   //D6 to S7
  pinMode(MODDET, INPUT);
  pinMode(DEBUG, OUTPUT);
  pinMode(ATTENTION, OUTPUT);
  pinMode(SS, INPUT);      //D10 to S4
  pinMode(MOSI, INPUT);     //D11  to S5
  pinMode(MISO, OUTPUT);      
  pinMode(SCK, INPUT);     //D13 to S3
  
  digitalWrite(ATTENTION, HIGH);  // ensure ATTENTION stays high for now
  // have to send on master in, *slave out*
  digitalWrite(DEBUG, LOW);  // debug pin

  // turn on SPI in slave mode
  SPCR |= _BV(SPE);

  // turn on interrupts
  SPCR |= _BV(SPIE);
}  // end of setup

//******************************************************
// SPI interrupt routine                               *
//******************************************************
ISR (SPI_STC_vect)
{
  spiRxBuf[spiRxCount] = SPDR;
  if (sending == true) {
    if (spiTxCount >= spiMsgSize) {
      SPDR = 0xFF;
      spiTxCount++;
      if (spiTxCount >= spiMsgSize + 1) {
        sending = false;
      }
    }
    else {
      SPDR = simRxBuf[spiTxCount];
      spiTxCount++;
    } 
  }
  else {
    SPDR = 0xFF;
    if (receiving == true) {
      spiRxCount++;
      if (spiRxCount >= sizeof(spiRxBuf)) {
        spiRxCount = sizeof(spiRxBuf) - 1;  //Don't allow overflow
      }
    }
  }
}  // end of interrupt service routine (ISR) SPI_STC_vect

//******************************************************
// Main program loop                                   *
//******************************************************
void loop (void)
{
  int i;
  char  HighNib;
  char  LowNib;
  int messageState = 0;
  boolean timedout;
  int oversize;
  unsigned long simMessageStartTime;
  unsigned long spiMessageStartTime;
  unsigned long lastCharTime;
  unsigned long timeout;

  if (digitalRead(RESET) == LOW) {
    while (1) {
      // Ignore everything while RESET is LOW
      if (digitalRead(RESET) == HIGH) {
        command = 0;
        newchar = false;
        simRxCount = 0;
        spiRxCount = 0;
        spiTxCount = 0;
        spiMsgSize = 0;
        receiving = false;
        sending = false;
        simMessageStartTime = 0;
        spiMessageStartTime = 0;
        break;
      }
      delay (1);
    }
  }
  
  if ((digitalRead(SS) == LOW) && (messageState == 0)) {
    /*===============================================
    | Main routine for receiving messages from SGD  |
    ************************************************/
    // Message is coming from SGD
    messageState = 1;
    spiRxCount = 0;
    receiving = true;
    spiMessageStartTime = millis();
    digitalWrite(ATTENTION, LOW);  // Acknowledge Select Active

    // Wait for Select to go Inactive
    while (digitalRead(SS) == LOW) {
      // Check for timeout
      if (spiMessageStartTime + 1000 < millis()) break;
    }
    
    // Message receive completed
    digitalWrite(ATTENTION, HIGH);  // Acknowledge Select In-Active
    spiMessageStartTime = 0;
    receiving = false;
    //==================================================
    // Send data up to simulator
    //==================================================
    for (i = 0; i < spiRxCount; i++) {
      Serial.write (spiRxBuf[i]);
    }
    spiRxCount = 0;
    messageState = 0;
  }

  if ((digitalRead(SS) == HIGH) && (messageState == 0)) {
    if (Serial.available() > 0) {
      /*===============================================
      | Main routine for sending messages to SGD      |
      ************************************************/
      // Message coming from UCM
      sending = true;
      simRxCount = 0;
      messageState = 10;
      simMessageStartTime = millis();

      // Get complete message from simulator
      while (1) {
        while (Serial.available() > 0) {
          // Get all data available from simulator serial port
          simRxBuf[simRxCount] = Serial.read();
          simRxCount++;
          if (simRxCount > 255) break;  // Prevent buffer overrun
          lastCharTime = millis();
        }
        // Check if full message has been received
        if (simRxBuf[0] == 8 || simRxBuf[0] == 9) {
          if (simRxCount >= 4) {
            oversize = simRxCount - (6 + simRxBuf[3] + (simRxBuf[2] * 256));
            if (oversize >= 0) break;
          }
        }
        else if (simRxBuf[0] == 0x06 || simRxBuf[0] == 0x15) {
          oversize = simRxCount - 2;
          if (oversize >= 0) break;
        }
        else {
          //Unknown message type so wait for characters to stop coming
          if (millis() > (lastCharTime + 100)) {
            // For debug purposes send what you have
            timedout = true;
            break;
          }
          else if (lastCharTime > millis()) {
            // clock has rolled over so reset lastCharTime
            lastCharTime = 0;
          }
        }
      }
      // Complete message received or timed out
      simMessageStartTime = 0;    // Clear the sim message timer
      spiMessageStartTime = millis();
      spiMsgSize = simRxCount;
      SPDR = simRxBuf[0];    // Preload the SPI buffer with the first byte
      spiTxCount = 1;              // and set pointer to next byte
      digitalWrite(ATTENTION, LOW);  // Request message transfer to SGD
      while (digitalRead(SS) == HIGH) {  // Wait for transfer to start
        if (millis() > (spiMessageStartTime + 1000)) break;
        delayMicroseconds (1);
      }
      while (sending == true) {
        if (millis() > (spiMessageStartTime + 1000)) break;
        delayMicroseconds (1);
      }
      digitalWrite(ATTENTION, HIGH);  // Message complete
      while (digitalRead(SS) == LOW) {  // Wait for transfer to complete
        if (millis() > (spiMessageStartTime + 1000)) break;
        delayMicroseconds (1);
      }
      spiMessageStartTime = 0;
      messageState = 0;
      spiRxCount = 0;
      receiving = false;
      sending = false;
    }
  }
}  // end of loop

