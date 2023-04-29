using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_pracadyp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                karta karta = new karta();
                karta.Show();
            } 
            else if (comboBox1.SelectedIndex == 2)
            {
                opiniaform opiniaform = new opiniaform();
                opiniaform.Show();
                opiniaform.form2instance.rec_czy_pro = 1;
            }
            else if (comboBox1.SelectedIndex == 1) 
            {
                protokol protokol = new protokol();
                protokol.Show();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                opiniaform opiniaform = new opiniaform();
                opiniaform.Show();
                opiniaform.form2instance.rec_czy_pro = 2;
            }
        }

       
    }
}
