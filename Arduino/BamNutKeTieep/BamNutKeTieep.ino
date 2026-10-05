int pinA = 2;
int pinB = 3;
int pinC = 4;
int pinD = 5;
int pinE = 6;
int pinF = 7;
int pinG = 8;
int pinDp = 9;
int number = 0;


void setup(){
  /*
  pinMode(pinA, OUTPUT);
  pinMode(pinB, OUTPUT);
  pinMode(pinC, OUTPUT);
  pinMode(pinD, OUTPUT);
  pinMode(pinE, OUTPUT);
  pinMode(pinF, OUTPUT);
  pinMode(pinG, OUTPUT);
  pinMode(pinDp, OUTPUT);
  */
  for(int i = 2; i <= 8; i++){
    pinMode(i, OUTPUT);
  }
  pinMode(12, INPUT);   // CHAN 12 LA CHAN NHAN TIN HIEU DIEN
  Serial.begin(9600);
}

void printNumber(int number){
  if(number == 0){
    digitalWrite(2, LOW);
    digitalWrite(3, LOW);
    digitalWrite(4, LOW);
  	digitalWrite(5, LOW);
  	digitalWrite(6, LOW);
  	digitalWrite(7, LOW);
  	digitalWrite(8, HIGH);
    //delay(1000);
  }
  else if(number == 1){
    digitalWrite(2, HIGH);
  	digitalWrite(3, LOW);
  	digitalWrite(4, LOW);
  	digitalWrite(5, HIGH);
  	digitalWrite(6, HIGH);
  	digitalWrite(7, HIGH);
  	digitalWrite(8, HIGH);
    //delay(1000);
  }
  else if(number == 2){
    digitalWrite(2, LOW);
  	digitalWrite(3, LOW);
  	digitalWrite(4, HIGH);
  	digitalWrite(5, LOW);
  	digitalWrite(6, LOW);
  	digitalWrite(7, HIGH);
  	digitalWrite(8, LOW);
    //delay(1000);
  }
  else if(number == 3){
    digitalWrite(2, LOW);
  	digitalWrite(3, LOW);
  	digitalWrite(4, LOW);
  	digitalWrite(5, LOW);
  	digitalWrite(6, HIGH);
  	digitalWrite(7, HIGH);
  	digitalWrite(8, LOW);
    //delay(1000);
  }
  else if(number == 4){
    digitalWrite(2, HIGH);
  	digitalWrite(3, LOW);
  	digitalWrite(4, LOW);
  	digitalWrite(5, HIGH);
  	digitalWrite(6, HIGH);
  	digitalWrite(7, LOW);
  	digitalWrite(8, LOW);
    //delay(1000);
  }
  else if(number == 5){
    digitalWrite(2, LOW);
  	digitalWrite(3, HIGH);
  	digitalWrite(4, LOW);
  	digitalWrite(5, LOW);
  	digitalWrite(6, HIGH);
  	digitalWrite(7, LOW);
  	digitalWrite(8, LOW);
    //delay(1000);
  }
  else if(number == 6){
    digitalWrite(2, LOW);
  	digitalWrite(3, HIGH);
  	digitalWrite(4, LOW);
  	digitalWrite(5, LOW);
  	digitalWrite(6, LOW);
  	digitalWrite(7, LOW);
  	digitalWrite(8, LOW);
    //delay(1000);
  }
  else if(number == 7){
    digitalWrite(2, LOW);
  	digitalWrite(3, LOW);
  	digitalWrite(4, LOW);
  	digitalWrite(5, HIGH);
  	digitalWrite(6, HIGH);
  	digitalWrite(7, HIGH);
  	digitalWrite(8, HIGH);
    //delay(1000);
  }
  else if(number == 8){
    digitalWrite(2, LOW);
  	digitalWrite(3, LOW);
  	digitalWrite(4, LOW);
  	digitalWrite(5, LOW);
  	digitalWrite(6, LOW);
  	digitalWrite(7, LOW);
  	digitalWrite(8, LOW);
   	//delay(1000);
  }
  else if(number == 9){
    digitalWrite(2, LOW);
    digitalWrite(3, LOW);
 	digitalWrite(4, LOW);
  	digitalWrite(5, LOW);
  	digitalWrite(6, HIGH);
  	digitalWrite(7, LOW);
 	digitalWrite(8, LOW);
    //delay(1000);
  }
  
}

void loop(){
  
  int value = digitalRead(12);
 // Serial.println(value);
  printNumber(number);
  if(value == 0){
    delay(400);
    if(value == 0){
      number = number + 1;
      printNumber(number);
    }
    Serial.println(number);
  }
  if(number == 10){
    number = 0;
  }
    
 
}
