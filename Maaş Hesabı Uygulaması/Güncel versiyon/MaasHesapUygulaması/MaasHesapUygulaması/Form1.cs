using System;
using System.Windows.Forms;
using MaasHesaplamasi;
namespace MaasHesapUygulaması
{
    public partial class Form1 : Form
    {
        MaasH maasHesaplama = new MaasH(); //Dll'i kullanmak için oluşturduğumuz ilk nesne.
        DtEkleme dt = new DtEkleme();      //Dll'i kullanmak için oluşturduğumuz ikinci nesne.
        int n; //gireceğimiz kayıt sayısı için sayısal değişken.
        int cocuks = 0; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Kaç personel gireceksiniz?", "Personel sayısı","0"), out int n) && n>0)
                checkBox3.Checked = true;
            else checkBox3.Checked = false;
            //Program oluşturulurken girilmek istenen kayıt sayısını önceden soran kod parçası
            button1.Enabled = checkBox3.Checked;


            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Enabled)
                cocuks = int.Parse(comboBox1.Text);


            if (textBox1.Text != "" || radioButton2.Checked)
            {
                if (radioButton2.Checked) textBox1.Text = MaasH.Asgari.ToString();


                double netMaas = maasHesaplama.NetMaas1(double.Parse(textBox1.Text), checkBox1.Checked, checkBox2.Checked, cocuks);

                //net maaş hesaplamak için.

                listView1.Items.Add(netMaas.ToString()); //Girilen verileri Listelemek için
                dt.DtEkle(textBox1.Text, netMaas.ToString().Replace(',','.'), checkBox1.Checked, checkBox2.Checked, cocuks);
                //Dll üzerinden Database kaydedilmek istenen veriler...
                n--;
                MessageBox.Show("Kayıt yapıldı!");

            }
            else MessageBox.Show("Bürüt maaş kısmını doldurunuz!!!");

            if (n == 0) //girmek istediğimiz kayıt sayısına ulaştıktan sonra devreye girecek koşul satırı.
                checkBox3.Checked = false;
            button1.Enabled = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = checkBox4.Checked; //Çocuk sayısı girmemiz için gereken işaretlenen checkBox ile ilgili kod
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox3.Checked;
            //Kayıt yapmak için işaretlememiz gereken checkBoxa bağlı buton'un kapalı veya açık durumu
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = radioButton1.Checked; //başlangıçta asgari bürüt hesabına göre geliyor fakat değişebiliyor.
        }
    }
}
