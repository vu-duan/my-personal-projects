int inA = 7;
int inB = 8;
int enA = 9;
int buttomPin = 2;
int ledPin = 10;
int buttomValue = 1;
int dem = 0;

void setup(){
  
  pinMode(inA, OUTPUT);
  pinMode(inB, OUTPUT);
  pinMode(enA, OUTPUT);
  pinMode(buttomPin, INPUT);
  pinMode(ledPin, OUTPUT);

}

void loop(){
 
  buttomValue = digitalRead(buttomPin);
  if(buttomValue == 0 ){
    delay(400);
    if(buttomValue == 0){     // Ktra bam nut
      dem =  dem + 1;

      if(dem == 1){
        digitalWrite(inA, HIGH);
        digitalWrite(inB, LOW);
        analogWrite(enA, 90);
      }

      else if(dem == 2){
        digitalWrite(inA, HIGH);
        digitalWrite(inB, LOW);
        analogWrite(enA, 120);
      }

      else if(dem  == 3){
        digitalWrite(inA, HIGH);
        digitalWrite(inB, LOW);
        analogWrite(enA, 255);
      }

      else if(dem == 4){
        digitalWrite(inA, LOW);
        digitalWrite(inB, LOW);
        digitalWrite(ledPin, HIGH);
      }

      else if (dem == 5){
        digitalWrite(inA, LOW);
        digitalWrite(inB, LOW);
        digitalWrite(ledPin, LOW);
        dem = 0;
      }

    }
  }

}