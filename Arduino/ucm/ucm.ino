// Written by Gary Aumaugher based on work by Nick Gammon
// December 2013
// SPI pin definitions
//    MISO  D-12
//    MOSI  D-11
//    SS    D-10  Select
//    SCK   D-13  Clock
//    ATN   D-9   Attention
//    LED   D-8
// Modified by Simon Boka August 2019

#include "pins_arduino.h"

#define RESET 6
#define MODDET 7
#define DEBUG 8
#define ATTENTION 9
#define SS 10
#define MOSI 11
#define MISO 12
#define SCK 13
#define BUFFSIZE 255

const bool DEBUGGING = false; //Set this to true and view the data into serial monitor.

/*
   List of Variables that are affected by Interrupt Service Routine
*/
volatile byte spiRxBuf[BUFFSIZE + 1];
volatile byte simRxBuf[BUFFSIZE + 1];
volatile int spiRxCount = 0;
volatile int spiTxCount = 0;
/*
   List of Variable not affected by Interrupt Service Routine
*/
boolean timedout = false;
int simRxCount = 0;
int oversize = 0;
unsigned long simMessageStartTime  = 0;
unsigned long spiMessageStartTime = 0;
unsigned long lastCharTime = 0;

//******************************************************
//   Reset Variables Routine                           *
//******************************************************
void reset_values()
{
  simRxCount = 0;
  spiRxCount = 0;
  spiTxCount = 0;
  memset(spiRxBuf, NULL, BUFFSIZE);
  memset(simRxBuf, NULL, BUFFSIZE);
  timedout = false;
  oversize = 0;
  simMessageStartTime  = 0;
  spiMessageStartTime = 0;
  lastCharTime = 0;
  SPDR = 0xFF;
}

//******************************************************
//   Write to Serial Moniter Routine                   *
//******************************************************
void terminal_print(byte data[], int xCount)
{
  int byteCount = 0;
  Serial.print("\nFrom SPI:\t");
  do
  {
    Serial.print(data[byteCount++], HEX); Serial.print(" ");
  }
  while (byteCount != xCount );
  Serial.print("\tByte Count: "); Serial.println(xCount);//Serial.println(byteCount);
}

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
  spiRxBuf[spiRxCount++] = SPDR;
  if (spiTxCount > 0) // Checking the sending buffer first
  {
    if (DEBUGGING) Serial.print(simRxBuf[spiTxCount - 1]);
    SPDR = simRxBuf[spiTxCount++];
  }
  else if (spiRxCount > 0)
  {
    SPDR = 0xFF;
    if (DEBUGGING) Serial.print(spiRxBuf[spiRxCount - 1]);
  }
}  // end of interrupt service routine (ISR) SPI_STC_vect

//******************************************************
// Main program loop                                   *
//******************************************************
void loop (void)
{

  while (digitalRead(RESET) == LOW) delayMicroseconds(20);

  reset_values(); // Let's re-initialize the variables

  if (digitalRead(SS) == LOW) {
    /*===============================================
      | Main routine for receiving messages from SGD  |
    ************************************************/
    // Message is coming from SGD
    spiMessageStartTime = millis();
    digitalWrite(ATTENTION, LOW);  // Acknowledge Select Active

    while ( spiRxCount < BUFFSIZE && spiMessageStartTime + 1000 >= millis()) {
      // Check for timeout and overflow
      if (digitalRead(SS) == HIGH) {  // Wait for Select to go Inactive
        break;
      }
      delayMicroseconds(1);
    }
    // Message receive completed
    digitalWrite(ATTENTION, HIGH);  // Acknowledge Select In-Active

    //==================================================
    // Send data up to simulator
    //==================================================
    if (DEBUGGING) terminal_print(spiRxBuf, spiRxCount);
    Serial.write((char *)spiRxBuf, spiRxCount);
  }

  while (digitalRead(SS) == LOW) { // Wait for SELECT to become high
    delayMicroseconds(20);
  }

  if (Serial.available() > 0) {
    /*===============================================
      | Main routine for sending messages to SGD      |
    ************************************************/
    // Message coming from UCM
    simMessageStartTime = millis();

    // Get complete message from simulator
    while (1) {
      while (Serial.available() > 0) {
        // Get all data available from simulator serial port
        simRxBuf[simRxCount++] = Serial.read();
        lastCharTime = millis();
        if (simRxCount > BUFFSIZE) break;  // Prevent buffer overrun
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

    if (DEBUGGING) {
      Serial.print("To SPI:\t");
      Serial.println((char *) simRxBuf);
    }

    // Complete message received or timed out
    spiMessageStartTime = millis() + 100;
    digitalWrite(ATTENTION, LOW);  // Request message transfer to SGD

    while (digitalRead(SS) == HIGH) {  // Wait for transfer to start
      if (millis() > spiMessageStartTime) {
        break;
      }
      delayMicroseconds (1);
    }

    SPDR = simRxBuf[spiTxCount++];  // Preload the SPI buffer with the first byte

    spiMessageStartTime += 100;

    while ( spiTxCount <= BUFFSIZE && millis() <= spiMessageStartTime) {
      delayMicroseconds(20);
      if (digitalRead(SS) == HIGH)
      {
        digitalWrite(ATTENTION, HIGH);  // Message complete
        break;
      }
    }
 
    if (digitalRead(ATTENTION) == LOW) // Double check the ATTENTION line and Force end of Message if Line if not HIGH
	{
       digitalWrite(ATTENTION, HIGH);  // Message complete
       spiMessageStartTime += 100;
       while (digitalRead(SS) == LOW) {  // Wait for transfer to complete
         if (millis() >= spiMessageStartTime) break;
         delayMicroseconds (10);
       }
	}

    if (DEBUGGING) {
      Serial.print("TxCount: ");
      Serial.print(spiTxCount);
      Serial.print("\tsimRxCount: ");
      Serial.println(simRxCount);
    }
  }
}  // end of loop