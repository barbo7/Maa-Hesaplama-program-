using System;
using System.Data.SqlClient;

namespace MaasHesaplamasi
{
    public class MaasH
    {
        public static double Asgari = 6471;
        double SgkTavan = Asgari * 7.5;

        public static double VergiOrani = 20;
        double SigortaOrani = 15;

        double ek = 0;
        byte asga = 1;

        public double NetMaas1(bool Asgari, double BrutMaas, bool EvliMi, bool Engellilik, int CocukSayisi)
        {
            if (Asgari) asga = 0;
            double Vergi = (BrutMaas * VergiOrani * asga) / 100;
            double Sigorta = BrutMaas >= SgkTavan ? (SgkTavan * SigortaOrani) / 100 : (BrutMaas * SigortaOrani) / 100;

            if (Engellilik)
                ek += 500;
            double NetMaasimiz = BrutMaas - (Vergi + Sigorta) + ek;
            if (EvliMi && CocukSayisi > 0)
                ek += CocukSayisi * 100;
            ek = 0;
            return NetMaasimiz+ek;
        }

        public double NetMaas2(bool Asgari, double BrutMaas, bool Engellilik)
        {
            if (Asgari) asga = 0;
            double Vergi = (BrutMaas * VergiOrani * asga) / 100;
            double Sigorta = BrutMaas >= SgkTavan ? (SgkTavan * SigortaOrani) / 100 : (BrutMaas * SigortaOrani) / 100;

            if (Engellilik) ek += 500;

            double NetMaasimiz = BrutMaas - (Vergi + Sigorta) + ek;
            ek = 0;
            return NetMaasimiz;
        }
    }
    public class DtEkleme
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=maaslar;Integrated Security=True");

        public void DtEkle(double BrutMaas, double Netmaass, bool EvliMi, bool Engellilik, int CocukSayisi)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO PERSONEL(BURUTMAAS,NETMAAS,ENGELLILIK,EVLILIK,COCUKSAYISI) " +
                "VALUES(" + BrutMaas + "," + Netmaass + ",'" + Engellilik + "','" + EvliMi + "'," + CocukSayisi + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
