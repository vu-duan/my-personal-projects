#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);
int camBien = 5;
int camBienValue;


void setup(){
  lcd.init();
  lcd.backlight();
  Serial.begin(9600);
  pinMode(camBien, INPUT);

}

void loop(){
  camBienValue = digitalRead(camBien);
  Serial.println(camBienValue);
  delay(300);
  if(camBienValue == 0){
    lcd.setCursor(0, 0);
    lcd.print("Co Vat Can        ");
  }

  else if(camBienValue == 1){
    lcd.setCursor(0, 0);
    lcd.print("khong Co Vat Can");
  }
  
}
