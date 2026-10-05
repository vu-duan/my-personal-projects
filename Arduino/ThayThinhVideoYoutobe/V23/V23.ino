#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);


//LiquidCrystal lcd(12, 11, 7, 6, 5, 4);

void setup(){
  lcd.begin(16,2);   // Khai bao su dung thiet bi lcd nao

}

void loop(){
  lcd.setCursor(1, 0);
  lcd.print("Vu Ngoc Duannnnn");
  lcd.setCursor(2, 1);
  lcd.print("xin chao");
}
