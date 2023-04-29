using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_pracadyp
{
    public partial class opiniaform : Form
    {
        public int rec_czy_pro;
        public static opiniaform form2instance;
        private opinia_recenzent objRecenzent;
        private opinia_promotor objPromotor;
        public opiniaform()
        {
            InitializeComponent();
            form2instance = this;
        }

        private void opiniaform_Load(object sender, EventArgs e)
        {
            if (rec_czy_pro == 1)
            {
                objRecenzent = new opinia_recenzent();
            }
            else
            {
                objPromotor = new opinia_promotor();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.nazwisko_recenzenta = textBox1.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.nazwisko_promotora = textBox1.Text;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.realizacja = textBox2.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.realizacja = textBox2.Text;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.istotnosc = textBox3.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.istotnosc = textBox3.Text;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.praktycznosc = textBox4.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.praktycznosc = textBox4.Text;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.poprawnosc = textBox5.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.poprawnosc = textBox5.Text;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.bibliografia = textBox6.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.bibliografia = textBox6.Text;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.zredagowanie = textBox7.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.zredagowanie = textBox7.Text;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.wiedza = textBox8.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.wiedza = textBox8.Text;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.zaangazowanie = textBox9.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.zaangazowanie = textBox9.Text;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.tytul = textBox11.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.tytul = textBox11.Text;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                objRecenzent.ang_tytul = textBox10.Text;
            }
            else if (objPromotor != null)
            {
                objPromotor.ang_tytul = textBox10.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objRecenzent.GetType());
                using (var writer = new StreamWriter("Eksportopiniarec.xml"))
                {
                    x.Serialize(writer, objRecenzent);
                }
            }
            else if (objPromotor != null)
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objPromotor.GetType());
                using (var writer = new StreamWriter("Eksportopiniapro.xml"))
                {
                    x.Serialize(writer, objPromotor);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (objRecenzent != null)
            {
                if (!File.Exists("./Eksportopiniarec.xml"))
                {
                    return;
                }

                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objRecenzent.GetType());
                using (var reader = new StreamReader("Eksportopiniarec.xml"))
                {
                    objRecenzent = (opinia_recenzent)x.Deserialize(reader);
                    textBox1.Text = objRecenzent.nazwisko_recenzenta;
                    textBox2.Text = objRecenzent.realizacja;
                    textBox3.Text = objRecenzent.istotnosc;
                    textBox4.Text = objRecenzent.praktycznosc;
                    textBox5.Text = objRecenzent.poprawnosc;
                    textBox6.Text = objRecenzent.bibliografia;
                    textBox7.Text = objRecenzent.zredagowanie;
                    textBox8.Text = objRecenzent.wiedza;
                    textBox9.Text = objRecenzent.zaangazowanie;
                    textBox10.Text = objRecenzent.tytul;
                    textBox11.Text = objRecenzent.ang_tytul;

                }
            }
                if (objPromotor != null)
                {
                    if (!File.Exists("./Eksportopiniapro.xml"))
                    {
                        return;
                    }

                    System.Xml.Serialization.XmlSerializer z = new System.Xml.Serialization.XmlSerializer(objPromotor.GetType());
                    using (var reader = new StreamReader("Eksportopiniapro.xml"))
                    {
                        objPromotor = (opinia_promotor)z.Deserialize(reader);
                        textBox1.Text = objPromotor.nazwisko_promotora;
                        textBox2.Text = objPromotor.realizacja;
                        textBox3.Text = objPromotor.istotnosc;
                        textBox4.Text = objPromotor.praktycznosc;
                        textBox5.Text = objPromotor.poprawnosc;
                        textBox6.Text = objPromotor.bibliografia;
                        textBox7.Text = objPromotor.zredagowanie;
                        textBox8.Text = objPromotor.wiedza;
                        textBox9.Text = objPromotor.zaangazowanie;
                        textBox10.Text = objPromotor.tytul;
                        textBox11.Text = objPromotor.ang_tytul;

                    }
                }
        }
    }
}
