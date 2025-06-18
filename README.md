# MultiShop Mikroservis E-Ticaret Projesi

Bu proje, .NET Core ve Mikroservis Mimarisi kullanılarak sıfırdan geliştirilmiş, tam donanımlı bir e-ticaret platformudur. Proje, birbirinden bağımsız olarak geliştirilebilen, dağıtılabilen ve ölçeklendirilebilen 12 adet mikroservis ve bu servislerle iletişim kuran modern bir kullanıcı arayüzünden oluşmaktadır.

## 🎯 Projenin Amacı

Bu projeyi geliştirirken temel amacım, modern yazılım geliştirme prensiplerini ve teknolojilerini tek bir çatı altında birleştirmekti. Mikroservis mimarisinin karmaşıklığını yönetmek, farklı veritabanı teknolojilerini bir arada kullanmak (Polyglot Persistence) ve dağıtık bir sistemde güvenliği merkezi olarak sağlamak gibi konularda derinlemesine tecrübe edinmeyi hedefledim. Proje, hem son kullanıcıya zengin bir alışveriş deneyimi sunmakta hem de yöneticilere tüm sistemi kontrol edebilecekleri dinamik bir panel sağlamaktadır.

## 🛠️ Kullanılan Teknolojiler, Mimariler ve Desenler

### Mimari ve Tasarım Desenleri
&#8226; **Microservice Architecture:** – Uygulamanın temel mimarisi.
&#8226; **Onion Architecture:** – Her bir servis içinde katmanlı ve bağımsız bir yapı kurmak için.

&#8226; **CQRS Design Pattern:** – Komut ve sorgu sorumluluklarını ayırarak performansı artırmak için.

&#8226; **Mediator Design Pattern:** – Servis içi katmanlar arası iletişimi merkezileştirmek için.

&#8226; **Repository Design Pattern:** – Veri erişim katmanını soyutlamak için.


### Backend ve Frameworkler
&#8226; **ASP.NET Core Web API:** – Mikroservislerin oluşturulması için.

&#8226; **ASP.NET Core MVC:** – Kullanıcı ve admin panellerinin geliştirilmesi için.


### Veritabanları ve Veri Erişimi (Polyglot Persistence)
&#8226; **PostgreSQL:** – Sipariş ve kullanıcı gibi ilişkisel verilerin yönetimi için.

&#8226; **MongoDB:** – Ürün kataloğu gibi esnek ve doküman tabanlı veriler için.

&#8226; **MSSQL:** – Identity Server verileri ve belirli servisler için.

&#8226; **Redis:** – Sepet verileri ve yüksek performanslı önbellekleme (caching) için.

&#8226; **Dapper:** – Yüksek performans gerektiren sorgularda ORM alternatifi olarak.


### Gateway ve Servisler Arası İletişim
&#8226; **Ocelot API Gateway:** – Tüm mikroservislere tek bir noktadan erişim sağlamak için.

&#8226; **Identity Server:** – Tüm mikroservislerin güvenliğini merkezi bir noktadan yönetmek için.


### Kimlik Doğrulama ve Güvenlik
&#8226; **Authentication & Authorization:** – Kullanıcı ve rol bazlı yetkilendirme.

&#8226; **JWT Bearer (Json Web Token):** – Servisler arası güvenli iletişim için.


### Gerçek Zamanlı İletişim ve API'ler
&#8226; **SignalR:** – Admin panelindeki anlık bildirimler ve canlı istatistikler için.

&#8226; **Google Drive API:** – Ürün fotoğraflarını harici bir serviste depolamak için.

&#8226; **Rapid API:** – Harici servislerle (döviz kuru vb.) entegrasyon için.

&#8226; **API Consume:** – MVC katmanından API'leri güvenli bir şekilde tüketmek için.

&#8226; **Ajax:** – Kullanıcı arayüzünde dinamik işlemler yapmak için.


### Containerization ve Araçlar
&#8226; **Docker:** – Her bir servisi ve veritabanını izole ortamlarda (container) çalıştırmak için.

&#8226; **Swagger:** – Geliştirilen tüm API'lerin dokümantasyonunu oluşturmak ve test etmek için.

&#8226; **Postman:** – API'leri detaylı bir şekilde test etmek için.



## 📌 Proje İçeriği

### Kullanıcı Arayüzü (MVC Web App)
&#8226; **Dinamik Ana Sayfa:** – Slider, öne çıkan ürünler ve kampanyalar gibi içeriklerin admin panelinden yönetildiği vitrin.

&#8226; **Ürün Listeleme ve Filtreleme:** – Kategori, marka, fiyat aralığı gibi kriterlere göre gelişmiş ürün arama.

&#8226; **Alışveriş Sepeti:** – Redis ile yönetilen, yüksek performanslı ve kullanıcı oturumuna bağlı sepet işlemleri.

&#8226; **Sipariş ve Ödeme Akışı:** – Kullanıcının siparişlerini oluşturup takip edebileceği panel.

&#8226; **Kullanıcı Paneli:** – Sipariş geçmişi, profil bilgileri ve favori ürünlerin yönetimi.


### Admin Paneli (MVC Web App)
&#8226; **Dashboard:** – SignalR ile anlık güncellenen satış istatistikleri, en çok satan ürünler gibi verilerin sunulduğu ana panel.

&#8226; **İçerik Yönetimi:** – Sitenin tüm dinamik alanlarının (slider, kampanya vb.) yönetimi.

&#8226; **CRUD İşlemleri:** – Ürün, kategori, marka, kullanıcı ve sipariş yönetimi.

&#8226; **Yetkilendirme:** – Identity Server ile entegre, rol bazlı yetki ve erişim kontrolü.



## 🔧 Öğrendiklerim & Deneyimlerim

Bu projeyi geliştirirken aşağıdaki konularda derinlemesine deneyim kazandım:

&#8226; **Mikroservis Mimarisi:** – Dağıtık bir sistem tasarlamanın zorluklarını ve avantajlarını (bağımsız geliştirme, ölçeklenebilirlik) uygulamalı olarak gördüm.

&#8226; **API Gateway (Ocelot):** – Düzinelerce servisi tek bir çatı altında nasıl yöneteceğimi ve istemciyi servis karmaşıklığından nasıl soyutlayacağımı öğrendim.

&#8226; **Merkezi Kimlik Doğrulama (Identity Server):** – Tüm sisteme yayılan güvenlik katmanını nasıl merkezi ve tutarlı bir şekilde yöneteceğimi deneyimledim.

&#8226; **Polyglot Persistence:** – Her veri türü için doğru veritabanı teknolojisini (SQL, NoSQL, In-Memory) seçmenin önemini kavradım.

&#8226; **Containerization (Docker):** – Geliştirme ortamından production ortamına geçişi nasıl sorunsuz ve tutarlı hale getirebileceğimi öğrendim.

&#8226; **CQRS & Mediator:** – Karmaşık iş mantığına sahip servislerde kodun ne kadar temiz, okunabilir ve sürdürülebilir hale geldiğini tecrübe ettim.



## 🎉 Sonuç & Gelecek Planlarım

Bu proje, 55.5 saatlik bir eğitim sürecinin sonunda, teorik bilgileri pratiğe dökerek modern yazılım mimarileri konusunda kendimi geliştirmemi sağlayan paha biçilmez bir deneyim oldu. İleride projeye aşağıdaki özellikleri eklemeyi planlıyorum:

&#8226; Servisler arası asenkron iletişim için **RabbitMQ** veya **Kafka** gibi bir mesaj kuyruğu sistemi entegre etmek.

&#8226; Docker container'larını bir orkestrasyon aracı olan **Kubernetes** ile yönetmek.

&#8226; **CI/CD pipeline**'ları kurarak derleme, test ve dağıtım süreçlerini otomatize etmek.

&#8226; Elastik arama ve loglama için **Elasticsearch, Logstash, Kibana (ELK Stack)** entegrasyonu yapmak.


Bu projenin ortaya çıkmasında yol gösteren ve engin bilgilerini paylaşan değerli eğitmen Murat Yücedağ'a teşekkürü bir borç bilirim!

![Screenshot_10](https://github.com/user-attachments/assets/53bfc432-a8ad-43ff-872e-3acb7bb60f9a)
![Screenshot_9](https://github.com/user-attachments/assets/07a67900-bed0-430e-aa2c-b67836dd11aa)
![Screenshot_8](https://github.com/user-attachments/assets/14164bbe-8daa-486d-b521-6ad9b632ce2c)
![Screenshot_7](https://github.com/user-attachments/assets/e4f72e78-a5bc-4aaf-8f95-1aa4c8c3cac4)
![Screenshot_6](https://github.com/user-attachments/assets/893be7d2-7c85-4366-baed-75bf9c8c9c34)
![Screenshot_5](https://github.com/user-attachments/assets/f60c3ee5-12c0-4d6e-b95e-b4173caf2e7d)
![Screenshot_4](https://github.com/user-attachments/assets/e6c504ac-2e5f-4409-b599-82065f6a3f2d)
![Screenshot_3](https://github.com/user-attachments/assets/7e432cbc-ce5b-4277-bcee-55243df95c0d)
![Screenshot_2](https://github.com/user-attachments/assets/87649179-c4f9-4f69-ac74-c165db8af160)
![Screenshot_1](https://github.com/user-attachments/assets/935f7b13-811b-43d3-bebb-9345c38127d3)


