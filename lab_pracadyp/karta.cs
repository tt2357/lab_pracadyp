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
using System.Xml;
using System.Xml.Serialization;

namespace lab_pracadyp
{

    public partial class karta : Form
    {
        
        temat objkarta = new temat();
        public karta()
        {
            InitializeComponent();
        }

        private void karta_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            objkarta.imie = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            objkarta.tytul = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            objkarta.ang_tytul = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            objkarta.dane_wejsciowe = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            objkarta.zakres = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            objkarta.termin = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            objkarta.promotor = textBox7.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            objkarta.jednostka_promotora = textBox8.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objkarta.GetType());
            using (var writer = new StreamWriter("Eksport.xml"))
            {
                x.Serialize(writer, objkarta);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./Eksport.xml"))
            {
                return;
            }

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objkarta.GetType());
            using (var reader = new StreamReader("Eksport.xml"))
            {
                objkarta = (temat)x.Deserialize(reader);
                textBox1.Text = objkarta.imie;
                textBox2.Text = objkarta.tytul;
                textBox3.Text = objkarta.ang_tytul;
                textBox4.Text = objkarta.dane_wejsciowe;
                textBox5.Text = objkarta.zakres;
                textBox6.Text = objkarta.termin;
                textBox7.Text = objkarta.promotor;
                textBox8.Text = objkarta.jednostka_promotora;

            }
        }
    }
   }

