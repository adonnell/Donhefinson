// Aaron Donnell
// 9/5/2013
// Code to make the drink shelf move on the DonHefinSon

#include <AccelStepper.h>

/* Different commands received from the app */
#define CMD_MAKE_DRINK  16
#define CMD_ADMIN       32

/* Status received from app */
#define ERR     10
#define FINISH  9

/* Status sent to app */
#define AT_TARGET 1
#define READY     2

/* Stepper specific */
#define STEPS_PER_BOTTLE 500
#define POS_OFFSET       4
#define HOME             0

static void make_drink();
static void admin_control();

/* Define a stepper and the pins it will use
Default is 2 wire, step pin = 8, direction pin = 9 */
AccelStepper stepper;

void setup()
{  
    stepper.setMaxSpeed(2000.0);
    stepper.setAcceleration(1500.0);     
    Serial.begin(9600);
}

void loop()
{
  int CMD = 0;
  
  /* Number of bytes available to read */
  if( Serial.available() > 0 )
  {
      CMD = Serial.read();
      if( CMD_MAKE_DRINK == CMD )
      {
        make_drink();
      }
      else if( CMD_ADMIN == CMD )
      {
        admin_control();
      }
   }    
}

static void admin_control()
{

}

static void make_drink()
{
  /* Position of the current goto target */
  int POS = 0;

Start_make:  
  /* wait for app to send next position */
  while( Serial.available() <= 0 )
  {
    Serial.println( READY, DEC ); 
  }
  
  /* got byte from app, read it */
  POS = Serial.read();
  
  if(POS != FINISH && POS != ERR)
      {
        /* offset because the carriage starts in middle at 0 */
        POS = POS - POS_OFFSET;
        
        // call a setup function again with globals that contain speed and accel so we can modify them
        stepper.runToNewPosition(STEPS_PER_BOTTLE*POS);
        
        /* delay for pouring the alc - CODE FOR ACTUATOR */
        delay(1000);
        
        /* tell the app you're at the target location */
        Serial.println( AT_TARGET, DEC);
        goto Start_make;
      }
      /* error with the console code, go back to home
      and print error */
      else if( POS == ERR )
      {
        stepper.runToNewPosition( HOME );
        Serial.println( AT_TARGET, DEC );  
      }
      /* if the drink is finished, go back to home */
      else if( POS == FINISH )
      {
        stepper.runToNewPosition( HOME );
        Serial.println( AT_TARGET, DEC); 
      }
}
