using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TomoyaChartProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LineChart.Series["Temperature"].ChartType = SeriesChartType.Line;

            FillData();
        }

        private void FillData()
        {

            List<int> arrayofvalues = new List<int>();
            arrayofvalues.Add(10);
            arrayofvalues.Add(10);
            arrayofvalues.Add(10);
            arrayofvalues.Add(50);
            arrayofvalues.Add(70);
            arrayofvalues.Add(30);
            arrayofvalues.Add(20);
            arrayofvalues.Add(-10);
            arrayofvalues.Add(-10);
            arrayofvalues.Add(30);
            arrayofvalues.Add(30);
            arrayofvalues.Add(30);
            arrayofvalues.Add(50);
            arrayofvalues.Add(50);
            arrayofvalues.Add(50);
            arrayofvalues.Add(50);
            arrayofvalues.Add(50);
            arrayofvalues.Add(50);
            arrayofvalues.Add(50);
            arrayofvalues.Add(50);

            int index = 0, lasthour = 0;
            foreach (int a in arrayofvalues)
            {
                if (index == 0)
                {
                    LineChart.Series["Temperature"].Points.AddXY(0, a);
                }
                else
                {
                    int diff = 0, hour = 0;
                    if (a > arrayofvalues[index - 1])
                    {
                        diff = a - arrayofvalues[index - 1];
                        hour = diff / 5;
                    }
                    else
                    {
                        diff = arrayofvalues[index - 1] - a;
                        hour = diff / 10;

                        if (hour == 0)
                            hour = 1;
                    }

                    LineChart.Series["Temperature"].Points.AddXY(lasthour + hour, a);
                    lasthour += hour;
                }

                index++;
            }

            LineChart.Series["Temperature"].XValueMember = "Time";
            LineChart.Series["Temperature"].YValueMembers = "Degree";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            printForm.PrintAction = PrintAction.PrintToPreview;
            printForm.Print();
            btnPrint.Visible = true;
        }
    }
}
