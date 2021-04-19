using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_PROJECT.Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0; // Dito sinisave yung result sa operation
        String operationPerformed = ""; //Dito sinisave yung operation
        bool isOperationPerformed = false; // need mag true para sa display

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(Splashstart)); //For thread/connecting
            t.Start();
            Thread.Sleep(2000);

            InitializeComponent();

            t.Abort();
        }

        public void Splashstart()
        {
            Application.Run(new Form2()); //This will run the form2
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button_numbers(object sender, EventArgs e)
        {
            if ((current_operation.Text == "0") || (isOperationPerformed))
                current_operation.Text = "";
            isOperationPerformed = false;

            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!current_operation.Text.Contains("."))
                    current_operation.Text = current_operation.Text + button.Text;
            }
            else
                current_operation.Text = current_operation.Text + button.Text;
        }

        private void button_operator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                button_equal.PerformClick();
                operationPerformed = button.Text;
                display1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(current_operation.Text);
                display1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            current_operation.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            current_operation.Text = "0";
            display1.Text = "";
            resultValue = 0;
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    current_operation.Text = (resultValue + double.Parse(current_operation.Text)).ToString();
                    break;
                case "-":
                    current_operation.Text = (resultValue - double.Parse(current_operation.Text)).ToString();
                    break;
                case "x":
                    current_operation.Text = (resultValue * double.Parse(current_operation.Text)).ToString();
                    break;
                case "%":
                    current_operation.Text = (resultValue / double.Parse(current_operation.Text)).ToString();
                    break;
                default:
                    break;

            }

            resultValue = double.Parse(current_operation.Text);
            display1.Text = "";
            operationPerformed = "";
        }

        private void popup_Click_Click(object sender, EventArgs e)

        {
            Form popup = new Form3();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                popup.Dispose();
            }


        }
            

}

    }

