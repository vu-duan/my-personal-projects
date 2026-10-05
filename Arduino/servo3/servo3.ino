#include <Servo.h>
Servo myServo;
int  servoPin = 8;
int bienTroPin = A0;
/*Chan A0 nhan dien tu chiet ap   Sau do xuat tin hieu ra 
       gia tri nguyen */
int bienTroValue = 0;  // Ban dau chua doc duoc gi
					   // tin hieu la gia tri NGUYEN [0,1023]

void setup(){
  pinMode(servoPin, OUTPUT);
  myServo.attach(servoPin);
  pinMode(bienTroPin, INPUT);
  Serial.begin(9600);     // Thiet Lap Kenh Truyen
  
  
}

void loop(){
  bienTroValue = analogRead(bienTroValue);
  Serial.println(bienTroValue);
  //int value = (bienTroValue * 180) / 1023;
  int value = map(bienTroValue, 0, 1023, 0, 180);
  myServo.write(value);
  delay(100);
}

