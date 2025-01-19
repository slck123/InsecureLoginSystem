SQL Injection ve Güvensiz Yazılım Geliştirmenin Tehlikeleri
Linkteki medium makalesinde kodlar detaylı şekilde açıklanmıştır.
https://medium.com/@selcuk.myo/sql-injection-ve-g%C3%BCvensiz-yaz%C4%B1l%C4%B1m-geli%C5%9Ftirmenin-tehlikeleri-09c8f443d07b


Günümüz yazılım geliştirme dünyasında güvenlik, başarılı bir uygulamanın en kritik bileşenlerinden biridir. Ancak, birçok uygulamada temel güvenlik önlemleri göz ardı ediliyor ve bu durum, zararlı saldırılar için açık kapı bırakıyor. Bu yazıda, SQL Injection saldırısını ele alacak ve aşağıdaki kod örneği üzerinden nasıl gerçekleştiğini açıklayacağız.

Kod İncelemesi
Aşağıda, bir Visual Basic uygulamasında kullanıcı girişini kontrol eden bir kod örneği bulunmaktadır. Kod, kullanıcıdan alınan kullanıcı adı ve şifre bilgilerini kullanarak bir SQL sorgusu oluşturur ve bu sorguyla bir veritabanını kontrol eder:

bu visual basic kodu bir forms arayüzü oluşturmak ve veritabanına bağlanmak için. ‘your source’ kısmına sizin bağlantı adresiniz olmalıdır
tasarladığımız form’un arayüzü
Güvenlik Açığı: SQL Injection
Bu kodun en büyük güvenlik açığı, kullanıcıdan alınan verilerin doğrudan SQL sorgusuna eklenmesidir. Kullanıcıdan gelen veri doğrulanmadığı veya temizlenmediği için, saldırganlar sorguyu manipüle ederek SQL Injection saldırıları gerçekleştirebilir.

SQL Injection Nasıl Çalışır?
SQL Injection saldırısında, saldırgan aşağıdaki gibi özel hazırlanmış bir girdi sağlayarak veritabanı sorgusunun yapısını değiştirir:

Kullanıcı adı: admin' OR '1'='1
Şifre: (herhangi bir değer)
Bu girdi ile oluşturulan SQL sorgusu şu şekilde olur:


Bu sorguda '1'='1' koşulu her zaman doğru olduğu için, veritabanındaki kullanıcılar kontrol edilmeden giriş yapılabilir. Ancak, yukarıdaki kod örneğinde SQL injection saldırısının başarılı olması için username alanına girilen değerin veritabanında kayıtlı bir kullanıcıya uygun olması gerektiğini unutmayın. Örneğin, veritabanında "admin" adında bir kullanıcı kaydı yoksa admin' OR '1'='1 girişi çalışmaz.

Şifre Alanında SQL Injection
Aynı sorguyu manipüle etmek için şifre alanına da bir giriş yapılabilir. Şifre alanında SQL injection saldırısı yapmak, yukarıdaki kısıtlamayı ortadan kaldırabilir. Örneğin:

Kullanıcı adı: (herhangi bir değer, örneğin “ad”)
Şifre: ' OR '1'='1
Bu durumda SQL sorgusu şu şekilde olur:


'1'='1' koşulu yine her zaman doğru olduğu için giriş işlemi başarılı olur. Şifre alanındaki bu saldırı yöntemi, kullanıcı adının veritabanında mevcut olmasına gerek kalmadan çalışır.

Çözüm: Güvenli Kod Yazımı
SQL Injection saldırılarını önlemek için aşağıdaki yöntemleri kullanabilirsiniz:

Parametreli Sorgular Kullanmak: Veritabanına gönderilen verileri sorgudan ayırarak SQL Injection saldırılarını önleyebilirsiniz. Örneğin:


Giriş Doğrulama: Kullanıcıdan alınan verileri SQL sorgusuna eklemeden önce doğrulamalı ve temizlemelisiniz.

Minimum Yetki Politikası: Veritabanı kullanıcılarına sadece gerekli yetkileri vererek, olası zararları sınırlayabilirsiniz

Sonuç
Bu yazıda, SQL Injection saldırısının nasıl çalıştığını ve yukarıdaki kodun bu saldırıya açık olduğunu gösterdik. Özellikle kullanıcı adı ve şifre alanlarının her ikisinin de farklı şekillerde SQL Injection saldırısına maruz kalabileceğini gördük. Ancak, kullanıcı adı alanındaki saldırının başarılı olması için hedeflenen kullanıcı adının veritabanında mevcut olması gerektiğini, şifre alanında ise böyle bir kısıtlamanın bulunmadığını vurguladık.

Bu tür güvenlik açıklarından kaçınmak için güvenli kod yazma uygulamalarını benimsemek şarttır. Yazılım geliştirme sürecinizde güvenlik önlemlerini baştan alarak, saldırganların sisteminize erişmesini engelleyebilirsiniz.

Unutmayın, güvenlik bir seçenek değil, bir zorunluluktur.
