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
    public partial class DiagramColor : Form
    {
        Dictionary<string, double> dc;

        public DiagramColor(Dictionary<string, double> tmp)
        {
            InitializeComponent();
            dc = new Dictionary<string, double>(tmp);
            dc.Remove("Коричневый");
            for (int i = 0; i < dc.Count; i++)
            {
                chart1.Series.Add(dc.ElementAt(i).Key);
                chart1.Series[dc.ElementAt(i).Key].BorderWidth = 10;
                chart1.Series[dc.ElementAt(i).Key].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[dc.ElementAt(i).Key].ToolTip = InfColors.GetHColor(dc.ElementAt(i).Key);//info color
                chart1.Series[dc.ElementAt(i).Key].Color = Color.Black;//можно реализовать изменение цвета по ключу
                chart1.Series[dc.ElementAt(i).Key].Points.AddXY((i + 1)*3 , dc.ElementAt(i).Value * 100);
                chart1.Series[dc.ElementAt(i).Key].Points.AddXY((i + 1)*3 , dc.ElementAt(i).Value * 100);
                //можно обернуть в паттерн...
            }
            if (dc.Count == 0)
            {
                MessageBox.Show("Преобладающих цветов не найдено");
                this.Close();
            }
            chart1.Update();
        }

        
    }
}
