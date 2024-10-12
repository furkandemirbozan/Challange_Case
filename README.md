Carrier management System

Genel Bakış

Kargo Yönetim Sistemi, siparişleri, kargo firmalarını ve gönderi detaylarını verimli bir şekilde yönetmek için tasarlanmış kapsamlı bir web uygulamasıdır. Kullanıcıların sipariş oluşturmasına, yönetmesine ve takip etmesine olanak tanırken, farklı kargo konfigürasyonlarına göre nakliye maliyetlerini hesaplar. Proje, katmanlı bir mimari kullanarak kodun bakımını ve genişletilebilirliğini sağlar.

Özellikler

Sipariş Yönetimi: Kullanıcılar, gönderiO siparişleri oluşturabilir, güncelleyebilir ve silebilir.

Kargo ve Konfigürasyon Yönetimi: Kargolar ve ilgili konfigürasyonlar, sipariş özelliklerine göre optimal nakliye maliyetlerini belirlemek için yönetilebilir.

Dinamik Maliyet Hesaplama: Sistem, siparişin desisine göre nakliye maliyetlerini hesaplayarak kullanıcı için en uygun kargo firmasını seçer.

Hata Yönetimi: Eksik veriler veya geçersiz konfigürasyonlar gibi senaryolar için uygun hata mesajları sağlanır.

Hangfire ile Arka Plan İşlemleri: Hangfire kullanılarak e-posta bildirimleri ve veri işleme gibi görevler zamanlanmış arka plan işleri olarak uygulanmıştır.

Kullanılan Teknolojiler

ASP.NET Core: Güçlü ve ölçeklenebilir bir web hizmeti için backend.

Entity Framework Core: Veritabanı işlemleri ve göçlerin yönetimi için kullanılır.

AutoMapper: Domain modelleri ve DTO'lar arasında kolay eşleme sağlar.

Hangfire: Zamanlanmış görevler için arka plan işi işleme sağlar.

SQL Server: Verilerin depolanması için ana veritabanı.

Swagger: Daha kolay test ve hata ayıklama için etkileşimli API dokümantasyonu sağlar.

Mimari

Uygulama, aşağıdaki katmanlı mimari modelini takip eder:

Domain Katmanı: Order, Carrier ve CarrierConfiguration gibi temel iş mantığını ve varlıkları tanımlar.

Uygulama Katmanı: Domain ile diğer katmanlar arasındaki iletişimi yönetmek için servis arayüzleri ve DTO'lar içerir.

Altyapı Katmanı: Entity Framework ve depoları kullanarak veritabanı işlemlerini yönetir.

API Katmanı: Sipariş ve kargo yönetimi için RESTful endpoint'ler sağlar.

Proje Kurulumu

Kargo Yönetim Sistemi ile çalışmaya başlamak için aşağıdaki adımları izleyin:

Gereksinimler

.NET SDK: Sürüm 6.0 veya üzeri

SQL Server

Hangfire Dashboard: Arka plan işlerini izlemek için

Çalıştırma Adımları

Depoyu Klonlayın:
https://github.com/furkandemirbozan/Challange_Case.git

Proje Dizini Üzerine Geçin:
dotnet ef database update
dotnet run

Hangfire Dashboard'a Erişim:

Tarayıcınızda /Shipping.Hf adresine giderek arka plan işlerini görüntüleyin ve yönetin.


Gelecekteki Geliştirmeler

Kullanıcı Kimlik Doğrulama ve Yetkilendirme: Admin ve Kullanıcı gibi farklı kullanıcı rolleri için kimlik doğrulama hizmetlerini entegre edin.

Gerçek Zamanlı Bildirimler: Sipariş durum güncellemeleri için SignalR kullanın.

Uluslararası Kargo Desteği: Uluslararası gönderileri, gümrük masrafları da dahil olacak şekilde desteklemek için mantığı genişletin.

Sonuç

Kargo Yönetim Sistemi, gönderileri yönetmek, maliyetleri dinamik olarak hesaplamak ve birden fazla kargo firmasıyla verimli bir şekilde entegre olmak için güçlü bir çözümdür. Hangfire eklenmesiyle, kritik görevler için verimli arka plan işleme desteği de sağlanmaktadır.

Katkıda bulunmaktan veya depoda sorun bildirmekten çekinmeyin!
