using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public void calculateTotal()
        {
            // ... vasiot kod ovde ...
            int pica = 0;
            int dodatok = 0;
            int vkupna = 0;
            if (radioButton1.Checked) 
            {
                int.TryParse(textBox1.Text, out pica);
               
            }
            if (radioButton2.Checked) 
            {
                int.TryParse(textBox2.Text, out pica);
                
            }
            if (radioButton3.Checked)
            {
                int.TryParse(textBox3.Text, out pica);
                
            }
            vkupna = pica;
            if (checkBox1.Checked)
            {
                int pom = 0;
                int.TryParse(textBox4.Text, out pom);
                dodatok += pom;
            }
            if (checkBox2.Checked)
            {
                int pom = 0;
                int.TryParse(textBox5.Text, out pom);
                dodatok += pom;
            }
            if (checkBox3.Checked)
            {
                int pom = 0;
                int.TryParse(textBox6.Text, out pom);
                dodatok += pom;
            }
            vkupna += dodatok;
            int koka = 0;
            int.TryParse(textBox7.Text, out koka);
            int cenaKoka = 0;
            int.TryParse(textBox12.Text, out cenaKoka);
            int vkupnoKoka = koka * cenaKoka;
            if (vkupnoKoka != 0)
                textBox13.Text = vkupnoKoka.ToString();
            vkupna += vkupnoKoka;

            int sok = 0;
            int.TryParse(textBox8.Text, out sok);
            int cenaSok = 0;
            int.TryParse(textBox11.Text, out cenaSok);
            int vkupnoSok = sok * cenaSok;
            if (vkupnoSok != 0)
                textBox14.Text = vkupnoSok.ToString();
            vkupna += vkupnoSok;

            int pivo = 0;
            int.TryParse(textBox9.Text, out pivo);
            int cenaPivo = 0;
            int.TryParse(textBox10.Text, out cenaPivo);
            int vkupnoPivo = pivo * cenaPivo;
            if (vkupnoPivo != 0)
                textBox15.Text = vkupnoPivo.ToString();
            vkupna += vkupnoPivo;

            int x = listBox1.SelectedIndex;
            if (x == 0)
            {
                textBox17.Text = "110";
                int cena = 0;
                int.TryParse(textBox17.Text, out cena);
                vkupna += cena;
            }
            if (x == 1)
            {
                textBox17.Text = "50";
                int cena = 0;
                int.TryParse(textBox17.Text, out cena);
                vkupna += cena;
            }
            
            if (x == 2)
            {
                textBox17.Text = "70";
                int cena = 0;
                int.TryParse(textBox17.Text, out cena);
                vkupna += cena;
            }
            
            textBox18.Text = vkupna.ToString();
            int naplateno;
            int.TryParse(textBox19.Text, out naplateno);
            if (naplateno != 0)
            {
                int pomc = naplateno - vkupna;
                textBox20.Text = pomc.ToString();
            }
               
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сакате да ја откажете нарачката?", "Откажи",
               MessageBoxButtons.YesNo, // vid na dijalogot 
               MessageBoxIcon.Question); // ikona na dijalogot
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string konecna = "";
            string pica = "";
            if (radioButton1.Checked)
                pica = "Мала пица";
            else if (radioButton2.Checked)
                pica = "Средна пица";
            else if (radioButton3.Checked)
                pica = "Голема пица";
            konecna += pica + "\n";

            string dodatoci = "";
            Boolean d = false;
            if (checkBox1.Checked)
            {
                dodatoci += "Феферонки";
                d = true;
            }

            if (checkBox2.Checked)
            {
                if (d)
                    dodatoci += "\nЕкстра сирење";
                else
                    dodatoci += "Екстра сирење";
                d = true;
            }

            if (checkBox3.Checked)
            {
                if (d)
                    dodatoci += "\nКечап";
                else
                    dodatoci += "Кечап";

            }
                
            if (dodatoci != "")
                konecna += "Додатоци:\n" + dodatoci + "\n";

            string pijalok = "";
            int kolicina = 0;
            int.TryParse(textBox7.Text,out kolicina);
            Boolean ima = false;
            if (kolicina != 0)
            {
                pijalok += (kolicina.ToString() + " Кока кола / Фанта / Спрајт");
                ima = true;
            }
            int.TryParse(textBox8.Text, out kolicina);
            if (kolicina != 0)
            {
                if (ima)
                    pijalok += ("\n" + kolicina.ToString() + " Сок од јаболко / портокал");
                else
                    pijalok += (kolicina.ToString() + " Сок од јаболко / портокал");
                ima = true;
            }
            int.TryParse(textBox9.Text, out kolicina);
            if (kolicina != 0)
            {
                if (ima)
                    pijalok += ("\n" + kolicina.ToString() + " Пиво");
                else
                    pijalok += (kolicina.ToString() + " Пиво");
                ima = true;
            }
            if (pijalok != "")
                konecna += "Пијалок:\n" + pijalok + "\n";
            if (listBox1.SelectedIndex == 0)
                konecna += "Десерт:\nОвошна пита";
            else if (listBox1.SelectedIndex == 1)
                konecna += "Десерт:\nСладолед";
            else if (listBox1.SelectedIndex == 2)
                konecna += "Десерт:\nТорта";
            DialogResult result = MessageBox.Show(konecna,"Нарачка");
        }

        
    }

}
