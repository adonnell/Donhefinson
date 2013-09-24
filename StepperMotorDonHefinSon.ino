// Aaron Donnell
// 9/5/2013
// Code to make the drink shelf move on the DonHefinSon

#include <AccelStepper.h>

int POS = 0;
int STEPS_PER_BOTTLE = 1000;
// Define a stepper and the pins it will use
// Default is 2 wire, step pin = 8, direction pin = 9
AccelStepper stepper;

void setup()
{  
    stepper.setMaxSpeed(4000.0);
    stepper.setAcceleration(2500.0);     
    Serial.begin(9600);
}

void loop()
{    
    if (Serial.available() > 0) 
    {
      // read the incoming byte:
      POS = Serial.read();
      if(POS != 10 && POS != 9)
      {
        // offset because the carriage starts in middle at 0
        POS = POS - 4;
        stepper.runToNewPosition(STEPS_PER_BOTTLE*POS);
        // delay for pouring the alc
        delay(1000);
        // tell the computer you're there
        Serial.println(1, DEC);
      }
      // error with the console code, go back to 0
      // and print error.
      else if(POS == 9)
      {
        stepper.runToNewPosition(0);
        Serial.println(1, DEC);  
      }
      // if the drink is finished, go back to 0
      else
      {
        stepper.runToNewPosition(0);
        Serial.println(1, DEC); 
      }
    }
}
