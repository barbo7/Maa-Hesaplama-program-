using System;
using System.Windows.Forms;
using MaasHesaplama_Dll;

namespace Maaş_Hesaplama_Uygulaması
{
    public partial class Form1 : Form
    {
        MaasH maasHesaplama = new MaasH();
        int n;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.Enabled = true;
            else textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Enabled == false)
                textBox2.Text = "0";
            double netMaas = maasHesaplama.NetMaas(double.Parse(textBox1.Text), checkBox1.Checked, checkBox2.Checked, int.Parse(textBox2.Text));
            listView1.Items.Add(netMaas.ToString());
            n--;
            if (n == 0)
                checkBox3.Checked = false;
            maasHesaplama.DtEkle(double.Parse(textBox1.Text), netMaas, checkBox1.Checked, checkBox2.Checked, int.Parse(textBox2.Text));
            MessageBox.Show("Kayıt yapıldı!");
        }   

        private void Form1_Load(object sender, EventArgs e)
        {

            if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Kaç personel gireceksiniz?", "Personel sayısı"), out int n))
                checkBox3.Checked = true; 
            else checkBox3.Checked = false;

            button1.Enabled = checkBox3.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox3.Checked;
        }
    }
}
