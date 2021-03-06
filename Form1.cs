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
        double special_operator = 0;
        Double resultValue = 0; // Dito sinisave yung result sa operation
        String operationPerformed = ""; //Dito sinisave yung operation
        bool isOperationPerformed = false; // need mag true para sa display
        const double pi = Math.PI;

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(Splashstart)); //Thread: Creating a new instance
            t.Start();
            Thread.Sleep(3000);

            InitializeComponent();

            t.Abort(); //Use for destroying threads
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
                current_operation.Text = ""; //para mag empty yung textbox
            isOperationPerformed = false; //Para sa display

            Button button = (Button)sender;
            if (button.Text == ".") //applies to period button only
            {
                if (!current_operation.Text.Contains("."))
                    current_operation.Text = current_operation.Text + button.Text;
            }
            else
                current_operation.Text = current_operation.Text + button.Text;
        }

        private void button_operator(object sender, EventArgs e) // for saving the first input
        {
            Button button = (Button)sender;
            if (resultValue != 0) //if not equal to zero
            {
                button_equal.PerformClick(); //mag equal yung operation
                operationPerformed = button.Text;
                display1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true; //pag naka true, magdi display yung operation sa display1
            }
            else//if not
            {
                operationPerformed = button.Text; // magsa save muna
                resultValue = Double.Parse(current_operation.Text); //resultValue is saved as a double
                display1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            switch (operationPerformed) //yung unang input na number and operator
            {
                case "+": //reading the text
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
                default: // pag walang na meet sa mga given arguments, default will activate
                    break;

            }

            resultValue = double.Parse(current_operation.Text); //saving the last result for the new operation
            display1.Text = "";
            operationPerformed = "";
        }

        private void popup_Click_Click(object sender, EventArgs e)//For my information (form3)

        {
            Form popup = new Form3();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK) //yung modal value from the button
            {
                popup.Dispose(); // For memory cleanup and release and reset unmanaged resources
            }


        }

        private void squared_click(object sender, EventArgs e) //For squared operator
        {
            special_operator = double.Parse(current_operation.Text);
            current_operation.Text = Math.Pow(special_operator, 2).ToString();
        }   //Math.pow(input, 2 ) 2 kasi squared

        private void cube_click(object sender, EventArgs e) // For cubed operator
        {
            special_operator = double.Parse(current_operation.Text);
            current_operation.Text = Math.Pow(special_operator, 3).ToString();
        }   //Math.pow(input, 3 ) 3 kasi cubed

        private void pi_click(object sender, EventArgs e) // For pi operator
        {
            special_operator = double.Parse(current_operation.Text);
            current_operation.Text = (special_operator * pi).ToString();

        }

        private void divide_click(object sender, EventArgs e) // 1/x to decimal
        {
            special_operator = double.Parse(current_operation.Text);
            current_operation.Text = (1 / special_operator).ToString();
        }

        private void sign_click(object sender, EventArgs e) // For sign
        {
            special_operator = double.Parse(current_operation.Text);
            current_operation.Text = (-1 * special_operator).ToString();
        }

        private void button_C_Click(object sender, EventArgs e) // Empty 
        {
            current_operation.Text = "0";
            display1.Text = "";
            resultValue = 0;
        }

        private void button_CE_Click(object sender, EventArgs e) // Clear entry
        {
            current_operation.Text = "0";
        }


    }
}

