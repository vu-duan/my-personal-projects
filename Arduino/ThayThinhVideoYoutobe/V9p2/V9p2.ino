int led1 = 2;
int led2 = 4;
int nut1 = 8;
int nut2 = 10;
int valueNut1;
int valueNut2;


void setup(){
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(nut1, INPUT);
  pinMode(nut2, INPUT);
}

void loop(){
  valueNut1 = digitalRead(nut1);
  valueNut2 = digitalRead(nut2);
  if(valueNut1 == 0){
    digitalWrite(led1, HIGH);
    delay(2000);
    digitalWrite(led1, LOW);

  }
  else if(valueNut2 == 0){
    digitalWrite(led1, HIGH);
    digitalWrite(led2, HIGH);
    delay(2000);
    digitalWrite(led1, LOW);
    digitalWrite(led2, LOW);

  }
}

    