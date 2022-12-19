# MaasHesaplamaProgrami
Nesne yönelimli programlama dersinde, dll kullanarak proje oluşturmamız gerektiği için oluşturduğum program

##Sql Database oluşuturulduktan sonra oluşturulacak tablonun kodu::

`CREATE TABLE [dbo].[PERSONEL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BURUTMAAS] [float] NOT NULL,
	[NETMAAS] [float] NOT NULL,
	[ENGELLILIK] [bit] NOT NULL,
	[EVLILIK] [bit] NOT NULL,
	[COCUKSAYISI] [tinyint] NULL,
 CONSTRAINT [PK_PERSONEL 2] PRIMARY KEY CLUSTERED ` 
Şeklindedir.

Uygulamada Dll dosyasını aktif etmek için öncelikle dll dosyasını build ettikten sonra normal uygulamamıza girip,
Oradan da build ettiğimiz dll'i project butonundan "add referance" seçeneğini seçip dll yolunu kaydettikten sonra uygulamamız kullanıma hazır hale geliyor. sonrasında 
hesaplamalarda, vergi oranında vs. değişikliği olduğu vakit anında bütün dll'i kullandığımız yerlerde etki etmesi için dll üzerinden değişiklik yapmamız yeterli geliyor.

![image](https://user-images.githubusercontent.com/114573591/208494714-1d011bb0-c7ee-43d9-b169-05e2aba21707.png)                ![image](https://user-images.githubusercontent.com/114573591/208494868-31de25b1-e118-48cb-aa6f-b938cb6e1cf8.png)


İlk olarak bize kaç kayıt gireceğimizi soruyor uygulama ve girdiğimiz kayıt sayısı verdiğimiz istediğimiz sayıya gelince ekleme yapma butonu kapanıyor fakat yine de kayıt girmek istersek yanındaki checkBox'ı işaretlememiz yetiyor.
Burada ana formumuzu görüyorsunuz, net maaşa etki eden kalemleri verdiğiniz bilgilere göre değerlendirip olması gereken aylık bürüt maaşı database'e kaydedip listView'de gösteriyorum.

Dilerseniz sadece aylık bürüt askeri ücrete göre hesap yapmak için yandaki radio buttonlarından seçebilir veya kendiniz veri girebilirsiniz.


Sql'e kaydetme kısmı ve net maaş hesaplama kısmı dll içerisinde mevcuttur.

Dll kısmında ise 2 class mevcut ilki maaş hesabı ile ilgili diğeri ise database'e veri kaydetme ile ilgili.
Daha sonrasında verileri kolaylıkla güncelleyip programın ilerleyişini sürdürebilmek için maaş hesaplama class'ında bazı değişkenler vermiş bulunmaktayım.
Açıklama satırlarıyla beraber kodlar mevcuttur

![image](https://user-images.githubusercontent.com/114573591/208497456-502c8ede-1def-4dd6-80dd-9381f1460263.png)

![image](https://user-images.githubusercontent.com/114573591/208323762-b559a615-91ff-443c-9d21-d9696366ff50.png)

Sonradan değişebilecek değerler olduğu için bazı değerleri enum yöntemi ile kaydettim ve bu şekilde kullandım.

En sonda da veri tabanına göndermek için oluşturduğum class'taki method'u görüyoruz. Buradaki methoda değer göndermek için Ana formumuzdan işaretlediğimiz değerlere 
göre veriler gönderiliyor.

![image](https://user-images.githubusercontent.com/114573591/208323848-6805fbb1-cf0c-438d-9b1c-b7c3c77a1573.png)

Database'imize gelen veriler de şu şekildedir:

![image](https://user-images.githubusercontent.com/114573591/208324994-b8993829-26fe-4c05-965b-a31b8f699589.png)



