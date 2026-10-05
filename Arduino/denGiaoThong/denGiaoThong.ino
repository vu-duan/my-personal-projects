 int ledPinXanh = 13;
int ledPinVang = 12;
int ledPinDo = 8;

void setup(){
  pinMode(ledPinXanh,OUTPUT);
  pinMode(ledPinVang,OUTPUT);
  pinMode(ledPinDo,OUTPUT);
}

void loop(){
  digitalWrite(ledPinXanh, HIGH);
  delay(20000);
  digitalWrite(ledPinXanh, LOW);
  delay(1000);
  //
  digitalWrite(ledPinVang, HIGH);
  delay(4000);
  digitalWrite(ledPinVang, LOW);
  delay(1000);
  digitalWrite(ledPinDo, HIGH);
  delay(15000);
  digitalWrite(ledPinDo, LOW);
  delay(1000);
  digitalWrite(ledPinVang, HIGH);
  delay(4000);
  digitalWrite(ledPinVang, LOW);
  delay(1000);
}