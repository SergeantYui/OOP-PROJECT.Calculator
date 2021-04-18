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
    }
}
