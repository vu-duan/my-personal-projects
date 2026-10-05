int led1 = 2;   // kHAI BAO CHAN XUAT TIN HIEU RA
int led2 = 3;
int led3 = 4;
int led4 = 5;
int led5 = 6;

int nut1 = 8;
int nut2 = 9;
int nut3 = 10;
int nut4 = 11;

int nut1Value;
int nut2Value;
int nut3Value;
int nut4Value;



void setup(){
  /*
  pinMode(nut1, INPUT);
  pinMode(nut2, INPUT);
  pinMode(nut3, INPUT);
  pinMode(nut4, INPUT);
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(led3, OUTPUT);
  pinMode(led4, OUTPUT);
  */

  for(int nutI = 8; nutI <= 11; nutI++){
    pinMode(nutI, INPUT);
  }
  for(int ledI = 2; ledI <= 6; ledI++){
    pinMode(ledI, OUTPUT);
  }

}

void ham(int i){
  digitalWrite(i, HIGH);
  delay(5000);
  digitalWrite(i, LOW);
} 


void loop(){
  nut1Value = digitalRead(nut1);   
  nut2Value = digitalRead(nut2);
  nut3Value = digitalRead(nut3);
  nut4Value = digitalRead(nut4);

  if(nut1Value == 0){
    ham(led1);
  }
  else if(nut2Value == 0){
    ham(led2);
  }
  else if(nut3Value == 0){
    ham(led3);
  }
  else if(nut4Value == 0){
    ham(led4);
  }
  
}
