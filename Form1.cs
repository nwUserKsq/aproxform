using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aproxform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Рассчитать";
            chart1.Series.Add("aprox");
            chart1.Series.Add("aproxreal");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            int q = Convert.ToInt32(textBox1.Text);
            int sumx = 0;
            int sumy = 0;
            int sumxy = 0;
            int sumxx = 0;
            int[] mass = new int[q];
            double[] mass2 = new double[q];
            Random random = new Random();

            chart1.Series["aprox"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["aproxreal"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            listBox1.Items.Clear();
            
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = random.Next(-20, 80);//наролили
                listBox1.Items.Add(mass[i]); //Добавили 
                sumx += i;
                sumy += mass[i];
                sumxy += i + mass[i];
                sumxx += i + i;

            }
            double a = (mass.Length * sumxy - sumx * sumy) / (mass.Length * sumxx - sumx * sumx);
            double b = (sumy - a * sumx) / mass.Length;
            for(int i = 0; i < mass.Length; i++) {
                mass2[i] = a * i + b;
                
            }
            chart1.Series["aprox"].Points.Clear();
            chart1.Series["aproxreal"].Points.Clear();
            for (int i = 0; i < mass.Length; i++)
            {
                chart1.Series["aprox"].Points.Add(mass[i]);
                chart1.Series["aproxreal"].Points.Add(mass2[i]);
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
