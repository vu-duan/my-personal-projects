#include<Servo.h>

Servo myServo;
int servoPin = 8;
int buttomPin = 12;
//int buttomValue ;
int value = 0;     // GATE dang o trang thai dong

void setup(){
  Serial.begin(9600);
  pinMode(servoPin, OUTPUT);
  myServo.attach(servoPin);
  myServo.write(58);
  pinMode(buttomPin, INPUT);
 // buttomValue = digitalWrite(buttomPin);
}

void loop(){
  int buttomValue = digitalRead(12);
  Serial.println(buttomValue);
  buttomValue = digitalRead(buttomPin);
  if(buttomValue == 0){
   delay(30);       // nhan nut
    if(buttomValue == 0){
      value = !value;
      if(value == 1){
        for(int pos = 58; pos <= 145; pos++){
      	  myServo.write(pos);
    	    delay(30);
        }
        myServo.write(145); // giu nguyen vi tri cuoi
      }
      if(value == 0){
        for(int pos = 145; pos >= 58; pos--){
          myServo.write(pos);
          delay(30);
        }
        myServo.write(58);
      }
    }
    
  }
 }