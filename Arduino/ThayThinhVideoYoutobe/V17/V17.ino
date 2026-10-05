int led = 8;
int i = 0;
void setup(){
  pinMode(led, OUTPUT);
  /*
  for(i = 0; i <= 4; i++){
    ct();
  }
  digitalWrite(led, LOW);
  */
  while(i <= 4){
    digitalWrite(led, HIGH);
    delay(3000);
    digitalWrite(led, LOW);
    delay(3000);
    i = i + 1;
  }

}
/*
void ct(){
  digitalWrite(led, HIGH);
  delay(3000);
  digitalWrite(led, LOW);
  delay(3000);
}
*/
void loop(){
  
}

  
  



