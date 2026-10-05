/*
int ledPin = 12;
int speakPin = 2;
int buttomPin = 8;
int buttomValue = 1;
int value  = 0;

void setup(){
  Serial.begin(9600);  // Thiet lap kenh truyen
  pinMode(ledPin, OUTPUT);
  pinMode(buttomPin, INPUT);
  pinMode(speakPin, OUTPUT);
}

void loop(){
  buttomValue = digitalRead(buttomPin);
  Serial.println(buttomValue);
  if(buttomValue == 0){
    delay(300);
    if(buttomValue == 0){
      value = !value;
      if(value == 1){
        digitalWrite(ledPin, HIGH);
        digitalWrite(speakPin, HIGH);
        delay(300);
        digitalWrite(speakPin, LOW);
//        delay()
      }
      else if(value == 0){
        digitalWrite(ledPin, LOW);
      }
    }
  }
}
*/
int ledPin1 = 2;   // KHAI BAO CHAN TIN HIEU OUT
int ledPin2 = 4;

int buttomPin1 = 8;  // kHAI BAO CHAN NHAN TIN HIEU DIEN VAO
int buttomPin2 = 10;
int buttomValue1 = 1;
int buttomValue2 = 1;
int value  = 0;
int phu = 0;

void setup(){
  Serial.begin(9600);  // Thiet lap kenh truyen
  pinMode(ledPin1, OUTPUT);
  pinMode(buttomPin1, INPUT);
  pinMode(ledPin2, OUTPUT);
  pinMode(buttomPin2, INPUT);
}

void loop(){
  buttomValue1 = digitalRead(buttomPin1);
  buttomValue2 = digitalRead(buttomPin2);
  if(buttomValue1 == 0){
    delay(300);
    if(buttomValue1 == 0){
      value = !value;
      if(value == 1){
        digitalWrite(ledPin1, HIGH);
      }
      else if(value == 0){
        digitalWrite(ledPin1, LOW);
      }
    }
  }

  else if(buttomValue2 == 0){
    delay(300);
    if(buttomValue2 == 0){
      value = !value;
      if(value == 1){
        digitalWrite(ledPin1, HIGH);
        digitalWrite(ledPin2, HIGH);
      }
      else if(value == 0){
        digitalWrite(ledPin1, LOW);
        digitalWrite(ledPin2, LOW);
      }
    }
  }
 
  
}