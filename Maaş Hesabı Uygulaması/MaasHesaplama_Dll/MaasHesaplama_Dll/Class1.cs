using System;
using System.Data.SqlClient;

namespace MaasHesaplama_Dll
{
    public class MaasH
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=maaslar;Integrated Security=True");
        double VergiOrani = 20;
        double SigortaOrani = 15;
        double net = 0;

        public double NetMaas(double BrutMaas, bool EvliMi, bool Engellilik, int CocukSayisi)
        {
            double Vergi = (BrutMaas * VergiOrani) / 100;
            double Sigorta = (BrutMaas * SigortaOrani) / 100;

            if (EvliMi && CocukSayisi > 0)
                net += CocukSayisi * 100;
            if (Engellilik)
                net += 500;
            double NetMaasimiz = BrutMaas - (Vergi + Sigorta) + net;
            net = 0;
            return NetMaasimiz;
        }
        public void DtEkle(double BrutMaas, double Netmaass, bool EvliMi, bool Engellilik, int CocukSayisi)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO PERSONEL(BURUTMAAS,NETMAAS,ENGELLILIK,EVLILIK,COCUKSAYISI) " +
                "VALUES("+ BrutMaas + "," + Netmaass + ",'" + Engellilik + "','" + EvliMi + "'," + CocukSayisi + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
