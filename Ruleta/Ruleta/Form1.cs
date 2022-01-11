using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruleta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Zde vyber jestli chceš sázet na sudé \nnebo liché číslo";
            label2.Text = "Zde vyber na jaké číslo vsadíš (0-99)\n**Šance na Jackpot!!" ;
            label3.Text = "Zde vyber na jakou chceš sázet barvu";
            label12.Text = "Stačí když se čísla budou lišit +-5";
            VyhraS.Text = "";
            VyhraB.Text = "";
            VyhraC.Text = "";
            jackpot1.Text = "";
            jackpot2.Text = "";
            penize.Text = "1500$";
            cena.Text = "5000$";
        }
        public int cash = 1500;
        public int Jack = 5000;
        public int i = -1;
        public bool nacitani = true;

        private void button1_Click(object sender, EventArgs e)
        {
            bool chyba = false;                    
            penize.Text = cash.ToString()+"$";
            int numerik;
            Random rnd = new Random();
            int cislo = rnd.Next(0, 100);
            int barva = rnd.Next(0, 4);
            if (nacitani == true)
            {
                try
                {
                    
                    VyhraC.Text = "";
                    numerik = Convert.ToInt32(textBox2.Text);
                    if (numerik == cislo)
                    {
                        jackpot2.Text = "!!JACKPOT!!";
                        cash += (Jack - 20);
                    }
                    else if (cislo - numerik >= -5 && cislo - numerik <= 5)
                    {
                        VyhraC.Text = "+200   Výhra na číslo";
                        cash += 180;
                    }
                    else
                    {
                        VyhraC.Text = "-20$";
                        cash -= 20;
                    }


                }
                catch (Exception)
                {
                    MessageBox.Show("Chyba v zadávání", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chyba = true;
                }
            }
            if (chyba == false)
            {
                textBox1.Text = cislo.ToString();

                if (cislo == 0) textBox1.ForeColor = Color.Green;
                else if (barva % 2 == 0) textBox1.ForeColor = Color.MediumVioletRed;
                else textBox1.ForeColor = Color.Black;

                VyhraS.Text = "";
                VyhraB.Text = "";
                
                jackpot1.Text = "";
                jackpot2.Text = "";

                if (i > 3 && i < 10)
                {
                    Jack += 100 * i;
                    cena.Text = (Jack).ToString() + "$";
                }
                if (i > 10)
                {
                    Jack += 50 * i;
                    cena.Text = (Jack).ToString() + "$";
                }
                i++;

                if (Suda.Checked && cislo % 2 == 0)
                {
                    VyhraS.Text = "+200$   Výhra na SUDÉ";
                    cash += 100;
                }
                else if (Licha.Checked && cislo % 2 == 1)
                {
                    VyhraS.Text = "+200$   Výhra na LICHÉ";
                    cash += 100;
                }
                else if (Suda.Checked || Licha.Checked)
                {
                    VyhraS.Text = "-100$";
                    cash -= 100;
                }

                if (zelena.Checked && cislo == 0)
                {
                    jackpot1.Text = "!!JACKPOT!!";
                    cash += Jack;
                }
                else if (cervena.Checked && barva % 2 == 0)
                {
                    VyhraB.Text = "+300$   Výhra na ČERVENOU";
                    cash += 140;
                }
                else if (cerna.Checked && barva % 2 == 1)
                {
                    VyhraB.Text = "+300$   Výhra na ČERNOU";
                    cash += 140;
                }
                else if (zelena.Checked || cervena.Checked || cerna.Checked)
                {
                    cash += -160;
                    VyhraB.Text = "-160$";
                }

                penize.Text = cash.ToString() + "$";
                if (cash <= 0) Close();
            }
        }

        private void Suda_CheckedChanged(object sender, EventArgs e)
        {
            if (Suda.Checked) Suda.ForeColor = Color.Black;
            else Suda.ForeColor = Color.White;
            if (Suda.Checked && Licha.Checked) Licha.Checked = false;
        }

        private void Licha_CheckedChanged(object sender, EventArgs e)
        {
            if (Licha.Checked) Licha.ForeColor = Color.Black;
            else Licha.ForeColor = Color.White;
            if (Suda.Checked && Licha.Checked) Suda.Checked = false;
        }

        private void cerna_CheckedChanged(object sender, EventArgs e)
        {
            if (cerna.Checked) cerna.ForeColor = Color.Black;
            else cerna.ForeColor = Color.White;
            if (cerna.Checked && cervena.Checked) cervena.Checked = false;
            if (cerna.Checked && zelena.Checked) zelena.Checked = false;
        }

        private void cervena_CheckedChanged(object sender, EventArgs e)
        {
            if (cervena.Checked) cervena.ForeColor = Color.Black;
            else cervena.ForeColor = Color.White;
            if (cervena.Checked && cerna.Checked) cerna.Checked = false;
            if (cervena.Checked && zelena.Checked) zelena.Checked = false;
        }

        private void zelena_CheckedChanged(object sender, EventArgs e)
        {
            if (zelena.Checked) zelena.ForeColor = Color.Black;
            else zelena.ForeColor = Color.White;
            if (zelena.Checked && cervena.Checked) cervena.Checked = false;
            if (zelena.Checked && cerna.Checked) cerna.Checked = false;
        }

        private void tutorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jackpot\n- Hodnota jackpotu je zobrazena vpravo nahoře\n- Hdnota jackpotu se zvyšuje postupným hraním hry\n- Jackpot se dá vyhrát pokud hráč vyhraje na zelenou nebo vsadí na číslo 0(pokud hráč vsadí na oba naráz a Jackpot padne hráč obdrží částku 2x protože 0 je jediné číslo, které je zelené)\nDále hráč může sázet na sudé nebo liché číslo a na barvu čísla\n","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            /*Form menu = new Information();
            menu.Show();*/
        }      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                nacitani = false;
                checkBox1.ForeColor = Color.White;
            }
            else
            {
                nacitani = true;
                checkBox1.ForeColor = Color.Black;
            }
        }
    }
}
