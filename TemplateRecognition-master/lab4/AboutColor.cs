using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class AboutColor : Form
    {
        Dictionary<string, double> dict;

        public AboutColor(Dictionary<string,double> tmp)
        {
            InitializeComponent();
            dict = new Dictionary<string, double>(tmp);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void SetTextAboutColor(string str)
        {
            rchbAboutColor.Text = str;
        }

        public void GetInfoColors()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiagramColor form = new DiagramColor(dict);
            form.ShowDialog();
        }
    }
}
