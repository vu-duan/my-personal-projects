int soundPin = 7;
float sinValue;  // Am thanh la song hinh sin
int toneValue;    // Tone giong

void setup(){
  pinMode(soundPin, OUTPUT);
}
/* Cap Cuu 1
void loop(){
  tone(soundPin, 2500, 50);
  delay(1000);
}

*/
// Code Dung Cho Loa Canh Bao
void loop(){
  for(int i = 0; i <= 180; i++){ 
    // Chay tu 0 -> 180 ddo
    sinValue = (sin(i * (3.14 / 180)));
    // Chuyen do -> radian
    toneValue = 2000 + (int(sinValue * 1000));
    tone(soundPin, toneValue);
    delay(1);
  }

}