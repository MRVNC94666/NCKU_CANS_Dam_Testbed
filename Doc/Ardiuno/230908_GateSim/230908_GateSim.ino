#include <Servo.h>
Servo myservo1;

float c0 = 0;   // 低電流值
float c1 = 255; // 高電流值

const float voltage = 130; // 電壓數值
float current = c0;  // 電流數值
float opening = 50;   // 開度數值 (50 ~ 210 為正常數值，對應開度 0.0 ~ 8.0 m)


int gate_movement = 0;   // 閘門動作: 0 = stop, 1 = up, 2 = down
int gate_state = 0; // 閘門狀態: 0 = normal, 1 = opened completely, 2 = closed completely, 3 = over max opening, 4 = under min opening.  

void setup() {
  Serial.begin(9600);

  pinMode(10, OUTPUT); // 電壓值
  pinMode(11, OUTPUT); // 電流值
  pinMode(12, OUTPUT); // 開度值

  pinMode(30, OUTPUT); // 電源
  pinMode(31, OUTPUT); // 現場
  pinMode(32, OUTPUT); // 遠端
  pinMode(33, OUTPUT); // 上升
  pinMode(34, OUTPUT); // 下降
  pinMode(35, OUTPUT); // 全開  
  pinMode(36, OUTPUT); // 超全關
  pinMode(37, OUTPUT); // 超全開
  pinMode(38, OUTPUT); // 關閉過扭力
  pinMode(39, OUTPUT); // 3E逃脫
  pinMode(40, OUTPUT); // 調門機過載
  pinMode(41, OUTPUT); // 馬達過熱逃脫
  pinMode(42, OUTPUT); // 緊急停止
  pinMode(43, OUTPUT); // 開啟過扭力
  pinMode(44, OUTPUT); // 接地故障
  pinMode(45, OUTPUT); // 全關
}

void loop() {
  current = c0; // 預設電流為低
  digitalWrite(30, HIGH); // 電源
  digitalWrite(31, HIGH);  // 現場
  digitalWrite(32, HIGH); // 遠端  
  
  if (digitalRead(26) == HIGH) {
    digitalWrite(33, LOW);
    digitalWrite(34, LOW);
  } else {
    (digitalRead(22) == HIGH) ? digitalWrite(33, HIGH) : digitalWrite(33, LOW);
    (digitalRead(24) == HIGH) ? digitalWrite(34, HIGH) : digitalWrite(34, LOW);
  }
 
  // Analog Output
  analogWrite(10, voltage);
  analogWrite(11, current);
  analogWrite(12, opening);
  delay(100);
}

