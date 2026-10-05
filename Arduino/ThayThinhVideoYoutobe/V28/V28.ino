int inA = 7;
int inB = 8;

int enA = 9;
int bienTroPin  = A0;

void setup(){
  pinMode(inA, OUTPUT);  // kHAI BAO CHAN XUAT TIN HIEU RA DK DONG CO
  pinMode(inB, OUTPUT);
   pinMode(enA, OUTPUT);
   pinMode(bienTroPin, INPUT);
   Serial.begin(9600);
  //  digitalWrite(inA, HIGH);
  // digitalWrite(inB, LOW);
  /*
   for(int i = 50; i <= 100; i = i + 10){
     digitalWrite(inA, HIGH);
    digitalWrite(inB, LOW);
    analogWrite(enA, i);
    delay(3000);
  }
*/
}

void loop(){
    int bienTroValue = analogRead(bienTroPin);
    int tocDo = map(bienTroValue, 0, 1023, 0, 255);
    Serial.print("Gia Tri: ");
    Serial.print(bienTroValue);
     Serial.print("  Toc Do: ");
    Serial.println(tocDo);
    delay(1000);
    digitalWrite(inA, HIGH);
    digitalWrite(inB, LOW);


    /*
    for(int i = 50; i <= 255; i = i + 1){
      analogWrite(enA, i);
      delay(100);
    }
    delay(200);
    */

    /************** Bai Toan 2 *************
    if(bienTroValue >= 100 && bienTroValue <= 300){
      analogWrite(enA, 70);
    }

    else if(bienTroValue > 300 && bienTroValue <= 500){
      analogWrite(enA, 140);
    }

    else if(bienTroValue > 500){
      analogWrite(enA, 250);
    }

    else if(bienTroValue >= 0 && bienTroValue < 100){
      digitalWrite(inA, LOW);
    digitalWrite(inB, LOW);
    }
    *****************/
    
    analogWrite(enA, tocDo);
    
  }
  


