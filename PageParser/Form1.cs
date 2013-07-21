using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
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

            var urls = Source.Text.Split(new[] {',', ';', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            Progress.Maximum = urls.Count();

            var resultsList = new List<StringValue>();

            foreach (var url in urls)
            {
                string html = (new WebClient {Encoding = new UTF8Encoding()}).DownloadString(url);
                if (!string.IsNullOrEmpty(html))
                {
                    var regForProxy = new Regex(Pattern.Text, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    var collectMatch = regForProxy.Matches(html);
                    int i = 0;
                    foreach (Match a in collectMatch)
                    {
                        resultsList.Add(new StringValue(HttpUtility.UrlDecode(a.Value), ++i));
                    }

                    //resultsList.AddRange(from Match a in collectMatch select a.Value);
                }
                Progress.Value++;
                // GetMatch(url, resultsList);
            }

            //ResultGrid.Columns.Add("Index", "N");
            //DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            //cell.Value = cell.RowIndex;
            //ResultGrid.Columns["Index"].CellTemplate = cell;
            ResultGrid.DataSource = resultsList;
            var column = ResultGrid.Columns["Value"];
            if (column != null)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ResultGrid.DataSource = Generate(words).ToList();
            //ResultGrid.Columns.Remove("Откуда");
        }

        public class StringValue
        {
            public StringValue(string s, int n)
            {
                Value = s;
                Number = n;
            }

            public int Number { get; set; }
            public string Value { get; set; }
        }

        //private List<string> GetMatch(string url, List<string> results)
        //{
        //    string html = (new WebClient()).DownloadString(url);
        //    if (!string.IsNullOrEmpty(html))
        //    {
        //        var regForProxy = new Regex(Pattern.Text, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //        var collectMatch = regForProxy.Matches(html);

        //        results.AddRange(from Match a in collectMatch select Convert.ToString(a));
        //    }
        //    Progress.Value++;
        //}
    }
}
