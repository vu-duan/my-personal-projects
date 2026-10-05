#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);
int camBien = 5;
int camBienValue;
int dem = 0;
int pre = 0;


void setup(){
  lcd.init();
  lcd.backlight();
  Serial.begin(9600);
  pinMode(camBien, INPUT);

}

void loop(){
  camBienValue = digitalRead(camBien);
  Serial.println(camBienValue);
  if(camBienValue == 0 && pre == 0){
    dem = dem + 1;
    delay(100);
  }
  pre = !camBienValue;
  lcd.setCursor(0,0);
  lcd.print("So Luong: ");
  lcd.setCursor(10, 0);
  lcd.print(dem);
    lcd.setCursor(14, 0);
  lcd.print("SP");
  
}