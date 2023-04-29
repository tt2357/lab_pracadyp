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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_pracadyp
{
    public partial class protokol : Form
    {
        komisja objpro = new komisja();
        public protokol()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            objpro.ocena_pracy = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objpro.GetType());
            using (var writer = new StreamWriter("Eksportprotokol.xml"))
            {
                x.Serialize(writer, objpro);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./Eksportprotokol.xml"))
            {
                return;
            }

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objpro.GetType());
            using (var reader = new StreamReader("Eksportprotokol.xml"))
            {
                objpro = (komisja)x.Deserialize(reader);
                numericUpDown1.Value = objpro.ocena_pracy;
                numericUpDown2.Value = objpro.ocena_egzamin;
                numericUpDown3.Value = objpro.ocena_studiow;
                if(objpro.czy_przyznano==true)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }

            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            objpro.ocena_egzamin = Convert.ToInt32(numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            objpro.ocena_studiow = Convert.ToInt32(numericUpDown3.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                objpro.czy_przyznano = true;
            }
            else
            {
                objpro.czy_przyznano = false;
            }
        }
    }
}
