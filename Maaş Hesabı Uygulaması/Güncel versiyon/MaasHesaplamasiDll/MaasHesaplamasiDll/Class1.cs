using System;
using System.Data.SqlClient;

namespace MaasHesaplamasi
{
    public class MaasH
    {
        public static double Asgari = 6471;
        double AsgariGVIstisnasi = 825.0525; //Asgari Net ücret * 0.15
        double AsgariDamgaVergisiIstisnasi = Math.Ceiling(Asgari * 0.759) / 100; //=49.12

        double SgkTavan = Asgari * 7.5;
        double SigortaOrani = 15;

        double ek = 0;

        public double NetMaas1(double BrutMaas, bool EvliMi, bool Engellilik, int CocukSayisi)
        {
            double Sigorta = BrutMaas >= SgkTavan ? (SgkTavan * SigortaOrani) / 100 : (BrutMaas * SigortaOrani) / 100;
            //Bürüt maaş Sgk Tavan puanını geçtiği zaman sgkTavan puanı üzerinden sigorta pirimi hesaplanıyor.
            double Vergi = VergiHesap(BrutMaas - Sigorta);
            //Gelir vergisi net maaş üzerinden hesaplandığı için methoda veri böyle gidiyor.
            Vergi += BrutMaas* 0.759/100; //Damga vergisi bürüt maaş üzerinden hesaplanıyor.

            if (Engellilik) ek += 500; // Engellilik durumuna göre net maaşa ek olarak almamız gereken miktar
            if (EvliMi && CocukSayisi > 0) ek += CocukSayisi * 100; //Çocuk durumuna göre net maaşa ek olarak almamız gereken miktar.

            double NetMaasimiz = BrutMaas - (Vergi + Sigorta) + ek + AsgariDamgaVergisiIstisnasi + AsgariGVIstisnasi;
            //Yaptığımız işlem bürüt maaş üzerinden vergi ve sigortayı çıkarttıkan sonra vergi istisnaları dahil edildikten sonra engellilik veyahut evli ve çocuklu durumuna göre net maaşımızı belirlememize olanak tanıyor.

            ek = 0;
            return NetMaasimiz;
        }

        public double NetMaas2(double BrutMaas, bool Engellilik)
        {
            double Sigorta = BrutMaas >= SgkTavan ? (SgkTavan * SigortaOrani) / 100 : (BrutMaas * SigortaOrani) / 100;
            double Vergi = VergiHesap(BrutMaas -Sigorta);
            Vergi += BrutMaas * 0.759 / 100;

            if (Engellilik) ek += 500;

            double NetMaasimiz = BrutMaas - (Vergi + Sigorta) + ek + AsgariDamgaVergisiIstisnasi + AsgariGVIstisnasi;

            ek = 0;
            return NetMaasimiz;
        }

        public double VergiHesap(double ABurut)
        {
            double Vergi;
            //Gelir vergisi oranı, aylık kümülatif gelirimize göre değişmektedir lakin bu programda sadece aylık bazda hesap yapıldığı için istediğimizi vermesine lakin doğru çalışmaz. Doğru olması için kümülatif gelirimizi de hesaba alıp hangi süreden hangi süreye giriş yapmak istediğimizi giriş yapmamız gerekir.
            if (0 <= ABurut && ABurut < (double)UcretGelirVergisi.ilk)
                Vergi = (ABurut * (double)VergiOran.ilk) / 100;

            else if ((double)UcretGelirVergisi.ilk <= ABurut && ABurut < (double)UcretGelirVergisi.ikinci)
                Vergi = (ABurut * (double)VergiOran.ikinci) / 100;

            else if ((double)UcretGelirVergisi.ikinci <= ABurut && ABurut < (double)UcretGelirVergisi.ucuncu)
                Vergi = (ABurut * (double)VergiOran.ucuncu) / 100;

            else if ((double)UcretGelirVergisi.ucuncu <= ABurut && ABurut < (double)UcretGelirVergisi.dorduncu)
                Vergi = (ABurut * (double)VergiOran.dorduncu) / 100;

            else if ((double)UcretGelirVergisi.dorduncu <= ABurut)
                Vergi = (ABurut * (double)VergiOran.son) / 100;

            else Vergi = 0; //Bir yanlışlık olduğu anlaşılması açısndan 

            return Vergi;
        }

        enum UcretGelirVergisi
        {
            ilk = 32000,
            ikinci=70000,
            ucuncu = 250000,
            dorduncu=880000
        }
        enum VergiOran
        {
            ilk = 15,
            ikinci = 20,
            ucuncu = 27,
            dorduncu = 35,
            son = 40
        }
    }
    public class DtEkleme
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=maaslar;Integrated Security=True");

        public void DtEkle(string BrutMaas, string Netmaass, bool EvliMi, bool Engellilik, int CocukSayisi)
        {
            con.Open();
            string sorgu = String.Format("INSERT INTO PERSONEL(BURUTMAAS,NETMAAS,ENGELLILIK,EVLILIK,COCUKSAYISI)" +
                "VALUES({0},{1},'{2}','{3}',{4})", BrutMaas, Netmaass, Engellilik, EvliMi, CocukSayisi);
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
