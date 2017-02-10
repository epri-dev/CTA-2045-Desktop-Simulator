// Written by Gary Aumaugher based on work by Nick Gammon
// December 2013
// SPI pin definitions
//    MISO    D-12
//    MOSI    D-11
//    SS      D-10  Select
//    SCK     D-13  Clock
//    ATN     D-9   Attention
//    LED     D-8
//    LED     D-8
//    MODDET  D-7
//    RESET   D-6

#include <SPI.h>
#include "pins_arduino.h"

#define RESET 6
#define MODDET 7
#define DEBUG 8
#define ATTENTION 9
#define SS 10
#define MOSI 11
#define MISO 12
#define SCK 13

byte simRxBuf[256];
byte spiRxBuf[256];
int simRxCount = 0;
int spiRxCount = 0;
int spiTxCount = 0;
int spiMsgSize = 0;
boolean receiving = false;
boolean sending = false;
boolean firstbyte = true;
boolean waitingForModule = true;

void setup (void)
{
  Serial.begin (115200);
  
  pinMode(RESET, OUTPUT);   //D6 to S7
  pinMode(MODDET, INPUT);
  pinMode(DEBUG, OUTPUT);
  pinMode(ATTENTION, INPUT);
  pinMode(SS, OUTPUT);      //D10 to S4
  pinMode(MOSI, OUTPUT);     //D11  to S5
  pinMode(MISO, INPUT);      
  pinMode(SCK, OUTPUT);     //D13 to S3

  digitalWrite(SS, HIGH);  // ensure SS stays high for now
  digitalWrite(RESET, LOW);  // Set reset pin low until module is plugged in
  digitalWrite(DEBUG, LOW);  // debug pin

  // Put SCK, MOSI, SS pins into output mode
  // also put SCK, MOSI into LOW state, and SS into HIGH state.
  // Then put SPI hardware into Master mode and turn SPI on
  SPI.begin ();

  // Slow down the master a bit
  SPI.setClockDivider(SPI_CLOCK_DIV8);
  waitingForModule = true;
}  // end of setup

byte transferAndWait (const byte xferVal)
{
  byte a = SPI.transfer (xferVal);
  delayMicroseconds (20);
  return a;
} // end of transferAndWait

//******************************************************
// Main program loop                                   *
//******************************************************
void loop (void)
{
  int i;
  byte ucmData;
  byte ucmMsgType;
  boolean timedout;
  int oversize;
  int ucmMsgSize;
  int calcMsgSize;
  unsigned long simMessageStartTime;
  unsigned long spiMessageStartTime;
  unsigned long lastCharTime;

  if (digitalRead(MODDET) == HIGH) {
    // If the module is not pluged in then wait for it
    waitingForModule = true;
    digitalWrite(RESET, LOW);  // Set reset pin low
  }
  else {
    if (waitingForModule == true) {

      digitalWrite(RESET, LOW);  // Set reset pin low
      delay (500);  // Hold reset low for minimum of 500ms
      digitalWrite(RESET, HIGH);  // Set reset pin high
      waitingForModule = false;
      spiRxCount = 0;
      spiTxCount = 0;
      spiMsgSize = 0;
      receiving = false;
      sending = false;
      firstbyte = true;
      simMessageStartTime = 0;
      spiMessageStartTime = 0;
    }

    if (digitalRead(ATTENTION) == LOW) {
//      Serial.println ("Attn Set Low");
      /*===============================================
      | Main routine for receiving messages from UCM  |
      ************************************************/
      // Message is coming from UCM
      spiRxCount = 0;
      receiving = true;
      spiMessageStartTime = millis();
      digitalWrite(SS, LOW);  // Acknowledge ATTENTION Active
      firstbyte = true;
      ucmMsgSize = 8;
      delayMicroseconds (20);    // Wait 20us before send clock

      while (digitalRead(ATTENTION) == LOW) {
        // Wait for attention to go High
        // Otherwise get next byte
        spiRxBuf[spiRxCount] = transferAndWait (0xFF);  // Get next data byte from UCM
        if (firstbyte == true) {
          // First byte defines message type
          ucmMsgType = spiRxBuf[spiRxCount];
          if (ucmMsgType == 0x06 || ucmMsgType == 0x15) {
            ucmMsgSize = 2;
            spiRxCount++;
            firstbyte = false;
          }
          else if (ucmMsgType == 0x08 || ucmMsgType == 0x09) {
            // Set a dummy size until enough bytes are received to calculate
            ucmMsgSize = 0x7fff;
            spiRxCount++;
            firstbyte = false;
          }
          else {
            // Unknown message type with unknown length - use buffer size
            ucmMsgSize = sizeof(spiRxBuf);
          }
        }
        else {
          if (ucmMsgSize == 0x7fff) {
            // Waiting for a message size
            if (spiRxCount == 2) {
              calcMsgSize = spiRxBuf[spiRxCount];
            }
            else if (spiRxCount == 3) {
              ucmMsgSize = calcMsgSize + spiRxBuf[spiRxCount] + 6;
              // do not overflow the buffer
              if (ucmMsgSize >= sizeof(spiRxBuf)) ucmMsgSize = sizeof(spiRxBuf);
            }
          }
          spiRxCount++;
        }
        if (spiRxCount >= ucmMsgSize) {
          // Complete message has been received - Wait for Attnetion to go high
          while (digitalRead(ATTENTION) == LOW) {
            if ((spiMessageStartTime + 500) < millis()) {
              // Timed out waiting for UCM to release Attention line
              digitalWrite(SS, HIGH);  // Set select to inactive
              while (digitalRead(ATTENTION) == LOW) {
                // Nothing we can do until the Attention is released
                delayMicroseconds(10);
              }
            }
          }
        }
//        delayMicroseconds(10);    // Provide a pause for the UCM to insert character
      }
      // disable Slave Select
      digitalWrite(SS, HIGH);
      // Write spi data to simulator
      for (i = 0; i < spiRxCount; i++) {
        Serial.write (spiRxBuf[i]);
      }
      spiRxCount = 0;
    }

    if ((digitalRead(ATTENTION) == HIGH)) {
      if (Serial.available() > 0) {
        /*===============================================
        | Main routine for sending messages to UCM      |
        ************************************************/
        // Message coming from SGD
        timedout = false;
        oversize = 0;
        sending = true;
        simRxCount = 0;
        simMessageStartTime = millis();

        // Get complete message from simulator
        while (1) {
          while (Serial.available() > 0) {
            // Get all data available from simulator serial port
            simRxBuf[simRxCount] = Serial.read();
            simRxCount++;
            lastCharTime = millis();
          }
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
        digitalWrite(SS, LOW);  // Request message transfer to UCM
        spiMessageStartTime = millis() + 100;
        while (digitalRead(ATTENTION) == HIGH) {  // Wait for transfer to start
          if (millis() > spiMessageStartTime) {
            //Timed out waiting for Att to go low
            simRxCount = 0;
            break;
          }
        }
        spiMessageStartTime = 0;    // Clear the sim message timer
        for (i = 0; i < simRxCount; i++) {
          ucmData = transferAndWait (simRxBuf[i]);  // Send data to UCM
        }
        digitalWrite(SS, HIGH);  // Close message to UCM
        while (digitalRead(ATTENTION) == LOW) {  // Wait for transfer to end
          // Cannot continue until Attn goes high
          delayMicroseconds (1);
        }
        simRxCount = 0;
      }
    }
  }
}  // end of loop
