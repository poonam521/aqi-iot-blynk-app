#iot project for aqi with blynk app code
#define BLYNK_PRINT Serial
#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266.h>
#include <DHT.h>
#define DHT11_PIN D2
DHT DHT(DHT11_PIN,DHT11);
BlynkTimer timer;
int analogPin = A0;
float val;
char auth[] = "7b0244eefcd74b7b849e6874e141055b";
char ssid[] = "Danger";
char pass[] = "12345678";
void setup()
{
Serial.begin(9600);
DHT.begin();
Blynk.begin(auth, ssid, pass,8080);
timer.setInterval(10L,myTimerEvent);
Blynk.syncAll();
}
void loop()
{
timer.run();
Blynk.run();
}
void myTimerEvent()
{
float tempC = DHT.readTemperature();
float tempF = DHT.convertCtoF(tempC);
float humidity = DHT.readHumidity();
val = analogRead(analogPin);
Blynk.virtualWrite(V0,val);
Blynk.virtualWrite(V1,tempC);
Blynk.virtualWrite(V2,humidity);
}