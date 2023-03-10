using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enriquez_Perceptron
{
    public partial class Form1 : Form
    {
        PerceptronSoln perceptron;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the inputs from the user
            int inputx1 = Convert.ToInt32(this.inputx1.Text);
            int inputx2 = Convert.ToInt32(this.inputx2.Text);
            int epochs = Convert.ToInt32(this.epochs.Text);

            //implementation of perceptron
            perceptron = new PerceptronSoln(inputsNum: 2);
            double[][] inputs = new double[][]
            {
                new double[] { 1, 1 },
                new double[] { 1, -1 },
                new double[] { -1, 1 },
                new double[] { -1, -1 }
            };
            int[] target = new int[] { 1, -1, -1, -1 };
            perceptron.Training(inputs, target, epochs);
            string output = perceptron.Prediction(new double[] { inputx1, inputx2 }).ToString();
            outputlabel.Text = output;
        }
    }
}
