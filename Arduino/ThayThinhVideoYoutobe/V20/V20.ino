// int led1 = 10;
// int led2 = 9;
// int led3 = 8;
// int led4 = 7;
int led[] = {10, 9, 8, 7};
int bienTroPin = A0;

void setup(){
  for(int i = 0; i <= 3; i++){
    pinMode(led[i], OUTPUT);
  }
  Serial.begin(9600);  // THIET LAP KENH TRUYEN

}

void cheDo0(){
  digitalWrite(led[0], LOW);
  digitalWrite(led[1], LOW);
  digitalWrite(led[2], LOW);
  digitalWrite(led[3], LOW);

}

void cheDo1(){
  digitalWrite(led[0], HIGH);
  digitalWrite(led[1], LOW);
  digitalWrite(led[2], LOW);
  digitalWrite(led[3], LOW);

}

void cheDo2(){
  digitalWrite(led[0], LOW);
  digitalWrite(led[1], HIGH);
  digitalWrite(led[2], LOW);
  digitalWrite(led[3], LOW);

}

void cheDo3(){
  digitalWrite(led[0], LOW);
  digitalWrite(led[1], LOW);
  digitalWrite(led[2], HIGH);
  digitalWrite(led[3], LOW);

}

void cheDo4(){
  digitalWrite(led[0], LOW);
  digitalWrite(led[1], LOW);
  digitalWrite(led[2], LOW);
  digitalWrite(led[3], HIGH);

}
void loop(){
  int bienTroValue = analogRead(bienTroPin);
  int nhietDo = map(bienTroValue, 0, 1023, 0, 100);
  Serial.print("Gia Tri Cua Bien Tro: ");
  Serial.print(bienTroValue);
  Serial.print("  Nhiet Do: ");
  Serial.println(nhietDo);
  delay(1000);
  if(nhietDo < 30){
    cheDo0();
  }
  else if(nhietDo >= 30 && nhietDo <= 50){
    cheDo1();
  }
  else if(nhietDo >= 51 && nhietDo <= 60){
    cheDo2();
  
  }
  else if(nhietDo >= 61 && nhietDo <= 80){
     cheDo3();
    
  }
  else if(nhietDo >= 81 && nhietDo <= 100){
     cheDo4();
  }
  
}