Backend için;
appsetings.json dosyası içinde ve TaskManagementProjectContext.cs içindeki UseSqlServer metodundaki
"DefaultConnection" alanı kendi database bilgilerinize göre güncellenmelidir.


Database için;

Sql Server'da "TaskProject" adında yeni bir database oluşturulur.
Ardından sol üst köşeden file>open>file..>script.sql

dosyası bulunup çalıştırılır. database kurulumu gerçekleşmiş olur.


UI için;

Visual Studio Code'da terminal açılır. npm install komutu çalıştırılır. daha soonra npm run dev komutu çalıştırılıp front-end görüntülenir.



Gereksinimler:

Node.js,
Visual Studio Code,


Not!!: UI çalıştırmadan önce backend ayakta olduğundan emin olun.
