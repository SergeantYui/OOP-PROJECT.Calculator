﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            InitializeComponent();
        }
    }
}
