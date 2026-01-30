  #include <WiFi.h>
  #include <SPI.h>
  #include <MFRC522.h>
  
  const char* ssid = "NOTEBOOK";
  const char* password = "GGPR2025";
  IPAddress staticIP(192, 168, 137, 215); // IP fixo ESP32
  WiFiServer server(80);
  
  const int red = 12;     
  const int green = 13;
  const int blue = 14;
  const int ledBuiltIn = 2;
  const int red2 = 4;
  const int green2 = 26;
  const int blue2 = 25;
  
  void setupLED() {
    pinMode(red, OUTPUT);
    pinMode(green, OUTPUT);
    pinMode(blue, OUTPUT);
    pinMode(ledBuiltIn, OUTPUT);
    pinMode(red2, OUTPUT);
    pinMode(green2, OUTPUT);
    pinMode(blue2, OUTPUT);
  
    // Inicializa desligado (anodo comum: HIGH = desligado)
    digitalWrite(red, HIGH);
    digitalWrite(green, HIGH);
    digitalWrite(blue, HIGH);
    digitalWrite(ledBuiltIn, LOW);
    digitalWrite(red2, HIGH);
    digitalWrite(green2, HIGH);
    digitalWrite(blue2, HIGH);
  }
  
  void vermelhoFuncao() {
    digitalWrite(red, LOW);   // acende
    digitalWrite(green, HIGH);
    digitalWrite(blue, HIGH);
  }
  
  void verdeFuncao() {
    digitalWrite(red, HIGH);
    digitalWrite(green, LOW); // acende
    digitalWrite(blue, HIGH);
  }
  
  void azulFuncao() {
    digitalWrite(red, HIGH);
    digitalWrite(green, HIGH);
    digitalWrite(blue, LOW);  // acende
  }
  
  void roxoFuncao() {
    digitalWrite(red, LOW);
    digitalWrite(green, HIGH);
    digitalWrite(blue, LOW);
  }
  
  //
  //void brancoFuncao() {
  //  digitalWrite(red, LOW);
  //  digitalWrite(green, LOW);
  //  digitalWrite(blue, LOW);
  //}
  //
  //void amareloFuncao() {
  //  digitalWrite(red, LOW);
  //  digitalWrite(green, LOW);
  //  digitalWrite(blue, HIGH);
  //}
  void verdeFuncao2() {
    digitalWrite(red2, HIGH);
    digitalWrite(green2, LOW); // acende
    digitalWrite(blue2, HIGH);
  }
  
  void verdeApaga(){
    digitalWrite(red2,  HIGH);
    digitalWrite(green2, HIGH); // acende
    digitalWrite(blue2, HIGH);
  }
  
  
  // ------------------- RFID -------------------
  #define SS_PIN 5
  #define RST_PIN 27
  MFRC522 mfrc522(SS_PIN, RST_PIN);
  
  void setupRFID() {
    SPI.begin(18, 19, 23);
    mfrc522.PCD_Init();
    Serial.println("RC522 pronto. Aproxime o cartão...");
  }
  
  
    WiFiClient client;
   bool clienteConectado = false;
  
  void setup() {
    Serial.begin(115200);
  
    setupLED();
  
    setupRFID();
  
    // Wi-Fi
    Serial.println("Conectando ao Wi-Fi...");
    WiFi.begin(ssid, password);
    while (WiFi.status() != WL_CONNECTED) {
      delay(500);
      Serial.print(".");
      digitalWrite(ledBuiltIn , !digitalRead(ledBuiltIn));
    }
  
    if (!WiFi.config(staticIP)) { 
      Serial.println("Falha ao configurar IP estático");
    } else {
      Serial.println("IP estático configurado!");
    }
  
    Serial.println("\nWi-Fi conectado!");
    Serial.print("IP: ");
    Serial.println(WiFi.localIP());
  
    digitalWrite(ledBuiltIn, HIGH); // acende LED onboard
    vermelhoFuncao();
    server.begin();
  }
  
  void loop() {
    String uidString = "";
    if (mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial()) {
      for (byte i = 0; i < mfrc522.uid.size; i++) {
          if (mfrc522.uid.uidByte[i] < 0x10) uidString += "0";
          uidString += String(mfrc522.uid.uidByte[i], HEX);
      }
     uidString.toUpperCase();
  
      Serial.println("UID lido: " + uidString);
      verdeFuncao2();
      delay(600);
      verdeApaga();
  
      // Envia para o C# apenas se o cliente estiver conectado
      if (client && client.connected()) {
          client.println("UID:" + uidString); // formato esperado pelo C#
      }
  
      mfrc522.PICC_HaltA();
      mfrc522.PCD_StopCrypto1();
  }
      delay(1000 );
    
  
  WiFiClient novoCliente = server.available();
  if (novoCliente && novoCliente.connected() && !client.connected()) {
      client = novoCliente; // atualiza o cliente global
      clienteConectado = true;
  }
  
  if (client && client.connected()) {
      if (!clienteConectado) {
          Serial.println("Cliente conectado!");
          clienteConectado = true;
      }
  
      if (client.available()) {
          String msg = client.readStringUntil('\n');
          msg.trim(); 
          Serial.println("Recebi: " + msg);
  
          if (msg == "red") vermelhoFuncao();
          else if (msg == "green") verdeFuncao();
          else if (msg == "blue") azulFuncao();
          else if (msg == "roxo") roxoFuncao();
          else if(msg == "ping") client.println("pong");
      }
  } else {
      if (clienteConectado) {
          Serial.println("Cliente desconectado!");
          clienteConectado = false;
          client.stop();
      }
  }
  }
