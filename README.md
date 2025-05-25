# نظام إدارة بنك الدم

تطبيق مكتبي بلغة C# (Windows Forms App - .NET Framework) يهدف إلى إدارة المتبرعين بالدم والطلبات والمخزون بشكل فعّال. يستخدم قاعدة بيانات MySQL، ويتصل بها عبر MySQL Connector.

---

## كيفية تشغيل المشروع

1. افتح المشروع باستخدام **Visual Studio**.
2. تأكد من تشغيل **XAMPP** (تفعيل MySQL).
3. استيراد قاعدة البيانات:
   - اذهب إلى `phpMyAdmin`
   - قم باستيراد ملف قاعدة البيانات: `db_Export/blood_bank.sql`
4. قم بتثبيت مكتبة iTextSharp عبر NuGet:
   - من داخل Visual Studio، افتح **Package Manager Console** واكتب:
     ```
  
     ```
5. قم بعملية Build ثم تشغيل المشروع.

---

## المتطلبات

- [.NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework)  
- [XAMPP](https://www.apachefriends.org/index.html) (MySQL)  
- [MySQL Connector لـ .NET](https://dev.mysql.com/downloads/connector/net/)  
- [iTextSharp](https://www.nuget.org/packages/iTextSharp/) (لإنشاء ملفات PDF)

---

## ملاحظات

- إعدادات الاتصال بقاعدة البيانات موجودة في: `DatabaseConnection/Database.cs`  
- واجهة المستخدم تم بناؤها باستخدام `System.Windows.Forms`  
- التعامل مع البيانات يتم باستخدام مكتبة `MySql.Data`  
- يتم توليد ملفات PDF باستخدام مكتبة `iTextSharp`

---

## الرخصة

هذا المشروع لأغراض تعليمية فقط.
