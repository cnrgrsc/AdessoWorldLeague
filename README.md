# Adesso World League Projesi

## Proje Açıklaması
Adesso World League, 8 farklı ülkenin 4'er takımıyla katıldığı ve toplamda 32 takımın yer aldığı bir lig sistemidir. Bu projede, takımlar belirli kurallara göre 4 veya 8 gruba dağıtılmaktadır.

### Kurallar:
1. **Grup Sayısı**: 4 veya 8 olmalıdır.
2. **Grup Yapısı**:
    - **4 Grup**: Her grupta 8 farklı ülkenin birer takımı bulunur.
    - **8 Grup**: Her grupta 4 farklı ülkenin birer takımı bulunur.
3. **Takım Dağılımı**:
    - Her grupta aynı ülkeden sadece bir takım olabilir.
    - Bir takım sadece bir gruba ait olabilir.
4. **Kura Çekimi Sırası**:
    - İlk olarak 1. gruba bir takım seçilir, sonra 2. gruba geçilir ve bir takım seçilir. Bu süreç tüm gruplara birer takım seçilene kadar devam eder.
    - Tüm gruplara birinci takımlar seçildikten sonra tekrar 1. gruba dönülür ve ikinci takımlar eklenir. Bu süreç tüm takımlar yerleştirene kadar devam eder.
5. **Kura Çekimi Bilgisi**:
    - Kura çekimini yapan kişinin isim ve soyisim bilgileri alınır ve veritabanına kaydedilir.
    - Oluşan gruplar ve kura çekimini yapan kişi veritabanına kaydedilir.

## Proje Yapısı
- **AdessoWorldLeague.Api**: Web API katmanı.
- **AdessoWorldLeague.Application**: Uygulama iş mantığı katmanı.
- **AdessoWorldLeague.Domain**: Domain modelleri ve iş kuralları.
- **AdessoWorldLeague.Infrastructure**: Veritabanı işlemleri ve veri erişim katmanı.

## Gerekli Araçlar ve Teknolojiler
- .NET 8 SDK
- Entity Framework Core
- SQL Server
- Visual Studio veya Visual Studio Code

## Kurulum ve Çalıştırma

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/kullanici/AdessoWorldLeague.git
2. Veritabanını Oluşturma
Veritabanınızı oluşturmak ve gerekli tabloları eklemek için aşağıdaki adımları izleyin.

2.1. Migration Oluşturma ve Veritabanını Güncelleme
Package Manager Console'da aşağıdaki komutları çalıştırın:

powershell
Kodu kopyala
Add-Migration InitialCreate -Context ApplicationDbContext
Update-Database -Context ApplicationDbContext
2.2. Başlangıç Verilerini Ekleme
Veritabanınıza başlangıç verilerini eklemek için aşağıdaki SQL sorgularını çalıştırın:

<details> <summary>SQL Sorguları</summary>
sql
Kodu kopyala
INSERT INTO dbo.Countries (Id, Name)
VALUES (NEWID(), 'Türkiye'),
       (NEWID(), 'Almanya'),
       (NEWID(), 'Fransa'),
       (NEWID(), 'Hollanda'),
       (NEWID(), 'Portekiz'),
       (NEWID(), 'İtalya'),
       (NEWID(), 'İspanya'),
       (NEWID(), 'Belçika');

INSERT INTO Teams (Id, Name, CountryId)
VALUES
(NEWID(), 'Adesso İstanbul', (SELECT Id FROM Countries WHERE Name = 'Türkiye')),
(NEWID(), 'Adesso Ankara', (SELECT Id FROM Countries WHERE Name = 'Türkiye')),
(NEWID(), 'Adesso İzmir', (SELECT Id FROM Countries WHERE Name = 'Türkiye')),
(NEWID(), 'Adesso Antalya', (SELECT Id FROM Countries WHERE Name = 'Türkiye')),

(NEWID(), 'Adesso Berlin', (SELECT Id FROM Countries WHERE Name = 'Almanya')),
(NEWID(), 'Adesso Frankfurt', (SELECT Id FROM Countries WHERE Name = 'Almanya')),
(NEWID(), 'Adesso Münih', (SELECT Id FROM Countries WHERE Name = 'Almanya')),
(NEWID(), 'Adesso Dortmund', (SELECT Id FROM Countries WHERE Name = 'Almanya')),

(NEWID(), 'Adesso Paris', (SELECT Id FROM Countries WHERE Name = 'Fransa')),
(NEWID(), 'Adesso Marsilya', (SELECT Id FROM Countries WHERE Name = 'Fransa')),
(NEWID(), 'Adesso Nice', (SELECT Id FROM Countries WHERE Name = 'Fransa')),
(NEWID(), 'Adesso Lyon', (SELECT Id FROM Countries WHERE Name = 'Fransa')),

(NEWID(), 'Adesso Amsterdam', (SELECT Id FROM Countries WHERE Name = 'Hollanda')),
(NEWID(), 'Adesso Rotterdam', (SELECT Id FROM Countries WHERE Name = 'Hollanda')),
(NEWID(), 'Adesso Lahey', (SELECT Id FROM Countries WHERE Name = 'Hollanda')),
(NEWID(), 'Adesso Eindhoven', (SELECT Id FROM Countries WHERE Name = 'Hollanda')),

(NEWID(), 'Adesso Lisbon', (SELECT Id FROM Countries WHERE Name = 'Portekiz')),
(NEWID(), 'Adesso Porto', (SELECT Id FROM Countries WHERE Name = 'Portekiz')),
(NEWID(), 'Adesso Braga', (SELECT Id FROM Countries WHERE Name = 'Portekiz')),
(NEWID(), 'Adesso Coimbra', (SELECT Id FROM Countries WHERE Name = 'Portekiz')),

(NEWID(), 'Adesso Roma', (SELECT Id FROM Countries WHERE Name = 'İtalya')),
(NEWID(), 'Adesso Milano', (SELECT Id FROM Countries WHERE Name = 'İtalya')),
(NEWID(), 'Adesso Venedik', (SELECT Id FROM Countries WHERE Name = 'İtalya')),
(NEWID(), 'Adesso Napoli', (SELECT Id FROM Countries WHERE Name = 'İtalya')),

(NEWID(), 'Adesso Sevilla', (SELECT Id FROM Countries WHERE Name = 'İspanya')),
(NEWID(), 'Adesso Madrid', (SELECT Id FROM Countries WHERE Name = 'İspanya')),
(NEWID(), 'Adesso Barselona', (SELECT Id FROM Countries WHERE Name = 'İspanya')),
(NEWID(), 'Adesso Granada', (SELECT Id FROM Countries WHERE Name = 'İspanya')),

(NEWID(), 'Adesso Brüksel', (SELECT Id FROM Countries WHERE Name = 'Belçika')),
(NEWID(), 'Adesso Brugge', (SELECT Id FROM Countries WHERE Name = 'Belçika')),
(NEWID(), 'Adesso Gent', (SELECT Id FROM Countries WHERE Name = 'Belçika')),
(NEWID(), 'Adesso Anvers', (SELECT Id FROM Countries WHERE Name = 'Belçika'));

INSERT INTO Groups (Id, Name)
VALUES 
(NEWID(), 'A'),
(NEWID(), 'B'),
(NEWID(), 'C'),
(NEWID(), 'D'),
(NEWID(), 'E'),
(NEWID(), 'F'),
(NEWID(), 'G'),
(NEWID(), 'H');
</details>
Not: Bu sorguları SQL Server Management Studio veya tercih ettiğiniz başka bir veritabanı yönetim aracında çalıştırabilirsiniz.
