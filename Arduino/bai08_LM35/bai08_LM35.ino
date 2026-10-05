int sensorPin = A0;    // Ten chan nhan tin hieu TU cam bien
int sensorPinValue = 0;
double vol = 0.0;
double tem = 0.0;
void setup()
{
 	//pinMode(sensorPin, INPUT);
  	Serial.begin(9600); 		// Thiet lap 2 kenh truyen
}

void loop()
{
  	sensorPinValue = analogRead(sensorPin);
  	Serial.println(sensorPinValue);
 // Doi so nguyen[0,1023] sang Vol   
  	vol = (sensorPinValue * 5.0) / 1023;
    tem = vol * 100;
  	Serial.println(tem);
    delay(2000);
}