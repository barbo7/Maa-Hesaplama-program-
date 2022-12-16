# MaasHesaplamaProgrami
Nesne yönelimli programlama dersinde, dll kullanarak proje oluşturmamız gerektiği için oluşturduğum program

##Sql Database oluşuturulduktan sonra oluşturulacak tablonun kodu::

`CREATE TABLE [dbo].[Personel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BURUTMAAS] [decimal](18, 0) NOT NULL,
	[NETMAAS] [float] NOT NULL,
	[ENGELLILIK] [bit] NOT NULL,
	[EVLILIK] [nchar](10) NOT NULL,
	[COCUKSAYISI] [tinyint] NOT NULL,
 CONSTRAINT [PK_Personell] PRIMARY KEY CLUSTERED` 
Şeklindedir.

Uygulamada Dll dosyasını aktif etmek için öncelikle dll dosyasını build ettikten sonra normal uygulamamıza girip,
Oradan da build ettiğimiz dll'i project butonundan "add referance" seçeneğini seçip dll yolunu kaydettikten sonra uygulamamız kullanıma hazır hale geliyor. sonrasında 
hesaplamalarda, vergi oranında vs. değişikliği olduğu vakit anında bütün dll'i kullandığımız yerlerde etki etmesi için dll üzerinden değişiklik yapmamız yeterli geliyor.

![image](https://user-images.githubusercontent.com/114573591/208199770-1d45cf49-fe1f-42f7-88ba-c9fc1a919045.png)

İlk olarak bize kaç kayıt gireceğimizi soruyor uygulama ve girdiğimiz kayıt sayısı verdiğimiz istediğimiz sayıya gelince ekleme yapma butonu kapanıyor.
Burada ana formumuzu görüyorsunuz, çocuk başına net maaşa direkt olarak etki eden para almak için öncelikle evli olmanız gerekiyor.
Onun dışında Engellilik durumuna göre net maaşa direkt etki eden bir gelir koyuyoruz hesaplarken. n sayıda girmek istediğimiz kayıt'ı girdikten sonra buton kapanıyor fakat yanındaki checkBox'ı işaretleyerek veri girmeye devam edebiliyoruz.

Sql'e kaydetme kısmı ve net maaş hesaplama kısmı dll içerisinde mevcuttur.
