int analogPin = A0;

void setup(){
  Serial.begin(9600);
}


void loop(){
  int analogValue = analogRead(analogPin);
  Serial.print("Gia tri analog: ");
  Serial.print(analogValue);
  int nhietDo = map(analogValue, 0, 1023, 0, 100);
  Serial.print("    Nhiet do: ");
  Serial.println(nhietDo);
  delay(2000);
  
}