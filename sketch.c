#include<Servo.h>;

Servo setX;
Servo setY;
String serialData;

void setup(){
  setX.attach(10);
  setxY.attach(11);
  Serial.begin(9600)
  Serial.setTimeout(10); //default length is 1000ms
}

void loop(){



}

void serialEvent(){
	serialData = Serial.readString();

	setX.write(parseDataX(serialData));
	setY.write(parseDataX(serialData));
}

int parseDataX(String data){
	data.remove(data.indexOf("Y"));
	data.remove(data.indexOf("X"), 1);

	return data.toInt();
}

int parseDataY(String data){
	data.remove(0, data.indexOf("Y") + 1);

	return data.toInt();
}
