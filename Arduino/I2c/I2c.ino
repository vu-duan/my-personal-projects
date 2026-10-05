#include <LiquidCrystal.h>

#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

void setup(){
  lcd.init();
  lcd.backlight();
  lcd.setCursor(2, 0);
  lcd.print("VU NGOC DUAN");
  lcd.setCursor(3, 1);
  lcd.print("14-10-2003");
  delay(5000);
  lcd.clear();
}

void loop(){
  lcd.setCursor(0, 0);
  lcd.print("CUA HANG DIEN TU");
  delay(3000);
  lcd.clear();
  lcd.setCursor(4, 1);
  lcd.print("Xin Chao");
  delay(3000);
  lcd.clear();


}