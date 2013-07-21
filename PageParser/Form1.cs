using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PageParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultGrid.Columns.Clear();
            
            //ResultGrid.Columns.Add("Index", "N");
            //DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            //cell.Value = cell.RowIndex;
            //ResultGrid.Columns["Index"].CellTemplate = cell;
            //ResultGrid.DataSource = Results.ToList();
            //ResultGrid.DataSource = Generate(words).ToList();
            //ResultGrid.Columns.Remove("Откуда");
        }
    }
}
