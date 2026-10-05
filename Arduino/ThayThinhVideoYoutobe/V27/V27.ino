int inA = 7;
int inB = 8;

int enA = 9;

void setup(){
  pinMode(inA, OUTPUT);  // kHAI BAO CHAN XUAT TIN HIEU RA DK DONG CO
  pinMode(inB, OUTPUT);
   pinMode(enA, OUTPUT);
   

}

void loop(){
  digitalWrite(inA, HIGH);
  digitalWrite(inB, LOW);
  analogWrite(enA, 100);
  delay(5000);
  digitalWrite(inA, LOW);
  digitalWrite(inB, HIGH);
    analogWrite(enA, 255);
  delay(5000);

}
