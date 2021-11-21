using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Method_of_calculation_RGR
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

		double funct(double x)
		{
			return Math.Sin(x);
		}

		static double a = 0;
		static double b = Math.PI / 2;
		static int n = 1;
		double h = (b - a) / n;

		public double calcTrapezoid(double h, double a, double b)
		{
			double sum = 0;
			sum += (funct(a) + funct(b))/2;
			double S = 0;
			for (int i = 1; i < (b - a) / h; i++)
				S += funct(i * h + a);
			sum += S;
			sum *= h;
			return sum;
		}

		private void Result_btn_Click(object sender, EventArgs e)
        {
			while (n <= 16777216)
			{
				//Считаем J по методу трапеций
				double jh = calcTrapezoid(h, a, b);
				dataGridView.Rows.Add(n, jh);
				n *= 2;
				h = (b - a) / n;
			}
		}
	}
}
