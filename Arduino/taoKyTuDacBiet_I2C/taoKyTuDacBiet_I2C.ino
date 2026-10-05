
#include <LiquidCrystal_I2C.h>


LiquidCrystal_I2C lcd(0x27, 16, 2);


byte phanTram[] = {
  B00000,
  B11000,
  B11001,
  B00010,
  B00100,
  B01000,
  B10011,
  B00011
};

byte kiTuVa[] = {
  B00000,
  B01100,
  B10010,
  B10100,
  B01000,
  B10101,
  B10010,
  B01101
};

byte aCong[] = {
  B00000,
  B01100,
  B10010,
  B00001,
  B01001,
  B10101,
  B10110,
  B01100
};

byte kiTuThang[] = {
  B00000,
  B01010,
  B01010,
  B11111,
  B01010,
  B11111,
  B01010,
  B01010
};

byte doLa[] = {
  B00000,
  B00100,
  B01111,
  B10100,
  B01110,
  B00101,
  B11110,
  B00100
};


byte sao[] = {
  B00000,
  B00100,
  B10101,
  B01110,
  B11111,
  B01110,
  B10101,
  B00100
};

byte loa[] = {
  B00001,
  B00011,
  B00111,
  B11111,
  B11111,
  B00111,
  B00011,
  B00001
  };

byte doC[] = {
  B11000,
  B11000,
  B00111,
  B01000,
  B10000,
  B10000,
  B01000,
  B00111
};

void setup(){
  lcd.init();
  lcd.backlight();
  lcd.begin(16, 2);
  // Tao Ky Tu Dac Biet
  lcd.createChar(0, phanTram);
  lcd.createChar(1, kiTuVa);
  lcd.createChar(2, aCong);
  lcd.createChar(3, kiTuThang);
  lcd.createChar(4, doLa);
  lcd.createChar(5, sao);
  lcd.createChar(6, loa);
   lcd.createChar(7, doC);

}


void loop(){
  //IN KY DAC BIET RA MAN HINH
  
  lcd.write(0);

  lcd.setCursor(2,0);
  lcd.write(1);

  lcd.setCursor(4,0);
  lcd.write(2);

  lcd.setCursor(6,0);
  lcd.write(3);

  lcd.setCursor(8,0);
  lcd.write(4);

  lcd.setCursor(10,0);
  lcd.write(5);

   lcd.setCursor(12,0);
  lcd.write(6);

   lcd.setCursor(14,0);
  lcd.write(7);
}

