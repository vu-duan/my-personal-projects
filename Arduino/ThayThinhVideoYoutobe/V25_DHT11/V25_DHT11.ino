#include<DHT.h>
//#include <wire.h>
#include <LiquidCrystal_I2C.h>

 const int PINDHT = 4;
 const int DHTTYPE = DHT11;
DHT dht(PINDHT, DHTTYPE);

//#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27, 16, 2);


void setup(){
  Serial.begin(9600);
  dht.begin();

   lcd.init();
   lcd.backlight();
  lcd.clear();
}

void loop(){
  double doAm = dht.readHumidity();
  double nhietDo = dht.readTemperature();
  Serial.print("Do am: ");
  Serial.println(doAm);
  Serial.print("Nhiet do: ");
  Serial.println(nhietDo);

   lcd.setCursor(0, 0);
  lcd.print("Do am: ");
  lcd.setCursor(7, 0);
  lcd.print(doAm);
  lcd.setCursor(0, 1);
  lcd.print("Nhiet do: ");
  lcd.setCursor(10, 1);
  lcd.print(nhietDo);
  // lcd.setCursor(1, 1);
  // lcd.print("Do am  = 60");
}