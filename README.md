# Fatura Yönetim Sistemi

Bu proje, kullanıcıların çeşitli faturalarını (elektrik, su, internet gibi) yönetmelerini sağlayan bir yazılım sistemidir. Fatura türlerini yönetebilmek ve her türün özelleşmiş hesaplama işlevlerini yerine getirebilmek için nesne yönelimli programlama (OOP) prensiplerinden yararlanılmıştır. Ayrıca, bağımlılık tersini (Dependency Inversion Principle - DIP) uygulayarak sistemin esnekliğini artırmış ve modüler bir yapı oluşturulmuştur.

## Kullanılan OOP Prensipleri

### Kalıtım (Inheritance)

Kalıtım, nesne yönelimli programlamada, bir sınıfın başka bir sınıftan özellik ve davranışları miras almasını sağlayan bir prensiptir. Bu projede kalıtım, faturaların farklı türlerinin yönetilmesi amacıyla kullanılmıştır.

*   **Fatura Sınıfı (Bill):** Bu sınıf, tüm fatura türlerinin temel sınıfıdır. `Bill` sınıfı, tüm faturalar için ortak olan özellikleri (örneğin, `BillId`, `CustomerName`, `DueDate`) ve ortak metotları (örneğin, `CalculateTotalAmount()`, `GetBillId()`) içerir.
*   **Elektrik Faturası (ElectricityBill), Su Faturası (WaterBill) ve İnternet Faturası (InternetBill):** Bu sınıflar, `Bill` sınıfından türetilmiştir ve her biri, ilgili fatura türü için spesifik hesaplama ve veri yönetimi işlevlerini barındırır. Örneğin, elektrik faturasında `UnitCost` ve `UnitsConsumed` gibi özellikler bulunurken, internet faturasında `MonthlyCost` gibi farklı bir özellik bulunmaktadır.

**Kalıtımın Kullanıldığı Yerler:**

*   `ElectricityBill`, `WaterBill` ve `InternetBill` sınıfları, `Bill` sınıfından türemektedir.
*   Her fatura sınıfı, `Bill` sınıfındaki soyut metotları uygulayarak, kendi türüne özel hesaplamalar yapar.

### Kapsülleme (Encapsulation)

Kapsülleme, sınıfın içindeki verileri (değişkenler) dışarıdan erişime kapalı tutup, bu verilere yalnızca sınıfın metotları aracılığıyla erişilmesini sağlayan bir prensiptir. Bu projede, her fatura türü için özellikler (özellikle fiyatlandırma ve fatura bilgileri) özel alanlar olarak tanımlanmış ve bu verilere erişim için getter ve setter metotları kullanılmıştır.

*   Faturaların özellikleri (`BillId`, `CustomerName`, `DueDate` gibi) genellikle `private` erişim belirleyicisiyle tanımlanmış, dışarıdan erişilmesini engellemek için yalnızca `public` metotlar (getter/setter) aracılığıyla bu verilere ulaşılması sağlanmıştır.

**Kapsüllemenin Kullanıldığı Yerler:**

*   Fatura bilgileri, sınıfın içeriğinde gizlenmiş ve dışarıdan yalnızca belirli metotlar aracılığıyla erişilmiştir. Örneğin, `BillId` ve `CustomerName` gibi özellikler yalnızca getter ve setter metotları aracılığıyla ayarlanabilir.

### Polimorfizm (Polymorphism)

Polimorfizm, aynı isme sahip metotların farklı şekillerde çalışabilmesi ilkesidir. Bu prensip, farklı sınıfların aynı metot adıyla farklı işlevler yapabilmesini sağlar. Projemizde `"calculateTotalAmount"` metodu, farklı fatura türlerine göre farklı hesaplamalar yapacak şekilde polimorfik olarak kullanılmıştır.

**Polimorfizmin Kullanıldığı Yerler:**

*   `CalculateTotalAmount()` metodu, `Bill` sınıfında soyut bir metot olarak tanımlanmış ve her bir türe özgü hesaplamalar, `ElectricityBill`, `WaterBill` ve `InternetBill` sınıflarında farklı şekillerde uygulanmıştır. Elektrik faturasında birim fiyat ve kullanılan birim sayısı çarpılarak hesaplama yapılırken, internet faturasında sabit bir aylık ücret hesaplanmıştır.

### Soyutlama (Abstraction)

Soyutlama, karmaşık sistemlerin daha basit bir şekilde temsil edilmesini sağlayan bir prensiptir. Soyut sınıflar ve arayüzler, sistemin karmaşık detaylarını gizler ve kullanıcıya yalnızca önemli olan bilgileri sunar.

*   Bu projede, `Bill` sınıfı soyut bir sınıf olarak tasarlanmıştır. Bu sınıf, faturaların temel bilgilerini ve işlemlerini soyutlar. Her fatura türü (elektrik, su, internet) bu soyut sınıftan türetilerek, her türün özgül işlevselliği uygulanmıştır.

**Soyutlamanın Kullanıldığı Yerler:**

*   `Bill` sınıfı soyut bir sınıf olarak belirlenmiştir ve bu sınıf, her fatura türünün sağlaması gereken ortak metotları içerir (örneğin, `CalculateTotalAmount()`). Gerçek hesaplama işlemi, her alt sınıfın kendine özgü implementasyonlarıyla sağlanır.

### Bağımlılık Tersini (Dependency Inversion Principle - DIP)

Bağımlılık tersini prensibi, yüksek seviyeli modüllerin düşük seviyeli modüllere bağımlı olmaması gerektiğini, bunun yerine her ikisinin de soyutlamalara (interfaces veya abstract classes) bağımlı olması gerektiğini savunur. Bu projede DIP, fatura oluşturma işlemi sırasında uygulanmıştır.

*   **BillFactory Sınıfı:** `BillFactory` sınıfı, bağımlılıkları soyutlama ile yönetir. Fatura türünü yaratırken, her fatura türü `IBillFactory` arayüzüne göre yaratılır. Bu, sistemin esnekliğini artırır ve fatura türlerini eklemek veya değiştirmek çok daha kolay hale gelir.
*   **IBillFactory Arayüzü:** Bu arayüz, fatura yaratma işlevselliğini soyutlar ve `BillFactory` sınıfı, bu arayüzü uygulayarak farklı fatura türlerinin üretiminden sorumlu olur. Bu sayede, yüksek seviyeli modüller (kullanıcı arayüzü, sistem yönetimi) düşük seviyeli modüllere (fatura türleri) doğrudan bağımlı olmaz, sadece soyutlamaya bağımlı olur.

**DIP’nin Kullanıldığı Yerler:**

*   `IBillFactory` arayüzü, fatura türlerini oluşturacak olan fabrika sınıfı için bir bağımlılık sağlar. Böylece, ana uygulama (UI veya iş mantığı) doğrudan fatura türlerine bağımlı kalmaz ve gelecekte yeni fatura türleri eklemek daha kolay hale gelir.

## Sonuç

Bu proje, nesne yönelimli programlamanın temel ilkelerini başarıyla uygulamıştır. Kalıtım, kapsülleme, polimorfizm ve soyutlama, sistemi modüler ve esnek hale getirmek için kullanılmıştır. Ayrıca, bağımlılık tersini uygulayarak, sistemin daha sürdürülebilir ve kolay genişletilebilir olmasını sağlamıştır. Bu sayede, projede yeni fatura türleri eklemek, mevcut türleri değiştirmek veya yeni işlevsellikler eklemek çok daha kolay ve güvenli bir hale gelmiştir.
