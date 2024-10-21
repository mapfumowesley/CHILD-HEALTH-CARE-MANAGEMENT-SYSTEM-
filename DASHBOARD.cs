using Bunifu.Framework.UI;
using Guna.UI.WinForms;
using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_
{
    public partial class DASHBOARD : Form
    {
        public DASHBOARD()
        {
            InitializeComponent();
            LoadDefaultGraphs_Fo_Girls();

            Create_Graphs_For_Height();
        }




        CHCMS_CLASS obj = new CHCMS_CLASS();
        public int id;
        public  string docId="";
        public string gender = "female";


        private List<DataPoint> dataPoints1; // Declare dataPoints1 as a field
        private List<DataPoint> dataPoints2;
        private List<DataPoint> dataPoints3;
        private List<DataPoint> dataPoints4;
        private List<DataPoint> dataPoints5;


        public void Count()
        {
            lblPatients_Num.Text = obj.Patient_load().Rows.Count.ToString();
            lblHIV_Num.Text = obj.Diagnosis_load_HIV().Rows.Count.ToString();
            lblPending.Text = obj.Appointments_Search_Today(docId, "Pending", DateTime.Today).Rows.Count.ToString();
            lblMissed.Text = obj.Appointments_Search_Today(docId, "Missed", DateTime.Today).Rows.Count.ToString();
            lblFullfilled.Text = obj.Appointments_Search_Today(docId, "Fullfilled", DateTime.Today).Rows.Count.ToString();


        }

        private void LoadDefaultGraphs_ForBoysWeight()
        {
            // Default data points for graph 1
            dataPoints1 = new List<DataPoint>
            {
               new DataPoint(1, 2.4),
               new DataPoint(2,3),
               new DataPoint(3,3.6),
               new DataPoint(4,4.1),
               new DataPoint(5,4.6),
               new DataPoint(6,5),
               new DataPoint(7,5.5),
               new DataPoint(8,6),
               new DataPoint(9,6.4),
               new DataPoint(10,6.7),
               new DataPoint(11,7),
               new DataPoint(12,7.2),
               new DataPoint(13,7.4),
               new DataPoint(14,7.6),
               new DataPoint(15,7.8),
               new DataPoint(16,8),
               new DataPoint(17,8.2),
               new DataPoint(18,8.4),
               new DataPoint(19,8.6),
               new DataPoint(20,8.8),
               new DataPoint(21,9),
               new DataPoint(22,9.1),
               new DataPoint(23,9.25),
               new DataPoint(24,9.4),
               new DataPoint(25,9.6),
               new DataPoint(26,9.8),
               new DataPoint(27,9.9),
               new DataPoint(28, 10),
               new DataPoint(29,10.2),
               new DataPoint(30,10.4),
               new DataPoint(31,10.6),
               new DataPoint(32,10.65),
               new DataPoint(34,10.9),
               new DataPoint(35,11.1),
               new DataPoint(36,11.2),
               new DataPoint(37,11.4),
               new DataPoint(38,11.5),
               new DataPoint(39,11.6),
               new DataPoint(40,11.7),
               new DataPoint(41,11.9),
               new DataPoint(42,12),
               new DataPoint(43,12.1),
               new DataPoint(44,12.2),
               new DataPoint(45,12.3),
               new DataPoint(46,12.4),
               new DataPoint(47,12.5),
               new DataPoint(48,12.6),
               new DataPoint(49,12.7),
               new DataPoint(50,12.8),
               new DataPoint(51,12.9),
               new DataPoint(52,13.1),
               new DataPoint(53,13.2),
               new DataPoint(54,13.3),
               new DataPoint(55,13.4),
               new DataPoint(56,13.5),
               new DataPoint(57,13.6),
               new DataPoint(58,13.7),
               new DataPoint(59,13.8),
               new DataPoint(60,13.9),

            };

            // Default data points for graph 2
            dataPoints2 = new List<DataPoint>
            {
               new DataPoint(1, 4.4),
               new DataPoint(2,5.8),
               new DataPoint(3,6.6),
               new DataPoint(4,7.4),
               new DataPoint(5,8),
               new DataPoint(6,8.6),
               new DataPoint(7,9),
               new DataPoint(8,9.6),
               new DataPoint(9,10),
               new DataPoint(10,10.4),
               new DataPoint(11,10.7),
               new DataPoint(12,11),
               new DataPoint(13,11.4),
               new DataPoint(14,11.6),
               new DataPoint(15,11.8),
               new DataPoint(16,12),
               new DataPoint(17,12.35),
               new DataPoint(18,12.6),
               new DataPoint(19,12.9),
               new DataPoint(20,13),
               new DataPoint(21,13.3),
               new DataPoint(22,13.6),
               new DataPoint(23,13.8),
               new DataPoint(24,14),
               new DataPoint(25,14.2),
               new DataPoint(26,14.5),
               new DataPoint(27,14.8),
               new DataPoint(28,15),
               new DataPoint(29,15.2),
               new DataPoint(30,15.5),
               new DataPoint(31,15.8),
               new DataPoint(32,16),
               new DataPoint(33,16.25),
               new DataPoint(34,16.6),
               new DataPoint(35,16.8),
               new DataPoint(36, 17),
               new DataPoint(37,17.2),
               new DataPoint(38,17.5),
               new DataPoint(39,17.8),
               new DataPoint(40,18),
               new DataPoint(41,18.2),
               new DataPoint(42,18.4),
               new DataPoint(43,18.65),
               new DataPoint(44,19),
               new DataPoint(45,19.2),
               new DataPoint(46,19.4),
               new DataPoint(47,19.6),
               new DataPoint(48,19.8),
               new DataPoint(49,20.15),
               new DataPoint(50,20.4),
               new DataPoint(51,20.6),
               new DataPoint(52,20.8),
               new DataPoint(53,21),
               new DataPoint(54,21.3),
               new DataPoint(55,21.6),
               new DataPoint(56,21.8),
               new DataPoint(57,22),
               new DataPoint(58,22.2),
               new DataPoint(59,22.4),
               new DataPoint(60,22.6),

            };


            // Add default data points to the chart
            AddWeightPoints_For_Boys(chart2, dataPoints1);
            AddWeightPoints_For_Boys(chart2, dataPoints2);

            // Set axis ranges
            chart2.ChartAreas[0].AxisX.Minimum = 1;
            chart2.ChartAreas[0].AxisX.Maximum = 60;
            chart2.ChartAreas[0].AxisY.Minimum = 1;
            chart2.ChartAreas[0].AxisY.Maximum = 25;
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisY.Interval = 1;
        }

        private void AddWeightPoints_For_Boys(Chart chart, List<DataPoint> dataPoints)
        {
            Series month = new Series();
            month.Color = Color.RoyalBlue;
            month.BorderWidth = 3;

            foreach (DataPoint dataPoint in dataPoints)
            {
                month.Points.Add(dataPoint);
            }

            month.ChartType = SeriesChartType.Spline;
            chart1.Series.Add(month);
        }
        public void plotting()
        {
            chart2.Series.Clear();

            if (gender.ToLower() == "male")
            {
                LoadDefaultGraphs_ForBoysWeight();
            }
            else
            {
                LoadDefaultGraphs_Fo_Girls();
            }
        }
        private void LoadDefaultGraphs_Fo_Girls()
        {


            // Default data points for graph 1
            dataPoints1 = new List<DataPoint>
            {
               new DataPoint(0, 2),
               new DataPoint(1,2.6),
               new DataPoint(2,3.4),
               new DataPoint(3,4),
               new DataPoint(4,4.4),
               new DataPoint(5,4.8),
               new DataPoint(6,5),
               new DataPoint(7,5.2),
               new DataPoint(8,5.5),
               new DataPoint(9,5.8),
               new DataPoint(10,6),
               new DataPoint(11,6.2),
               new DataPoint(12,6.4),
               new DataPoint(13,6.6),
               new DataPoint(14,6.7),
               new DataPoint(15,6.85),
               new DataPoint(16,7),
               new DataPoint(17,7.2),
               new DataPoint(18,7.3),
               new DataPoint(19,7.45),
               new DataPoint(20,7.6),
               new DataPoint(21,7.7),
               new DataPoint(22,7.8),
               new DataPoint(23,8.0),
               new DataPoint(24,8.1),
               new DataPoint(25,8.2),
               new DataPoint(26,8.3),
               new DataPoint(27,8.4),
               new DataPoint(28,8.5),
               new DataPoint(29,8.6),
               new DataPoint(30,8.75),
               new DataPoint(31,8.9),
               new DataPoint(32,9),
               new DataPoint(33,9.2),
               new DataPoint(34,9.3),
               new DataPoint(35,9.4),
               new DataPoint(36,9.5),
               new DataPoint(37,9.65),
               new DataPoint(38,9.8),
               new DataPoint(39,9.9),
               new DataPoint(40,10),
               new DataPoint(41,10.2),
               new DataPoint(42,10.3),
               new DataPoint(43,10.4),
               new DataPoint(44,10.5),
               new DataPoint(45,10.65),
               new DataPoint(46,10.8),
               new DataPoint(47,10.9),
               new DataPoint(48,11),
               new DataPoint(49,11.1),
               new DataPoint(50,11.2),
               new DataPoint(51,11.3),
               new DataPoint(52,11.4),
               new DataPoint(53,11.5),
               new DataPoint(54,11.6),
               new DataPoint(55,11.7),
               new DataPoint(56,11.8),
               new DataPoint(57,11.85),
               new DataPoint(58,11.9),
               new DataPoint(59,11.95),
               new DataPoint(60,12),

            };
            // Default data points for graph 2
            dataPoints2 = new List<DataPoint>
            {
               new DataPoint(0, 2.4),
               new DataPoint(1, 3),
               new DataPoint(2,3.7),
               new DataPoint(3,4.4),
               new DataPoint(4,5),
               new DataPoint(5,5.35),
               new DataPoint(6,5.65),
               new DataPoint(7,6),
               new DataPoint(8,6.2),
               new DataPoint(9,6.4),
               new DataPoint(10,6.6),
               new DataPoint(11,6.8),
               new DataPoint(12,7),
               new DataPoint(13,7.2),
               new DataPoint(14,7.45),
               new DataPoint(15,7.65),
               new DataPoint(16,7.8),
               new DataPoint(17,8),
               new DataPoint(18,8.2),
               new DataPoint(19,8.4),
               new DataPoint(20,8.6),
               new DataPoint(21,8.8),
               new DataPoint(22,9),
               new DataPoint(23,9.2),
               new DataPoint(24,9.35),
               new DataPoint(25,9.5),
               new DataPoint(26,9.7),
               new DataPoint(27,9.8),
               new DataPoint(28, 10),
               new DataPoint(29,10.2),
               new DataPoint(30,10.4),
               new DataPoint(31,10.6),
               new DataPoint(32,10.8),
               new DataPoint(33,10.9),
               new DataPoint(34,11),
               new DataPoint(35,11.2),
               new DataPoint(36,11.4),
               new DataPoint(37,11.5),
               new DataPoint(38,11.65),
               new DataPoint(39,11.8),
               new DataPoint(40,11.9),
               new DataPoint(41,12),
               new DataPoint(42,12.2),
               new DataPoint(43,12.3),
               new DataPoint(44,12.4),
               new DataPoint(45,12.5),
               new DataPoint(46,12.65),
               new DataPoint(47,12.8),
               new DataPoint(48,12.9),
               new DataPoint(49,13),
               new DataPoint(50,13),
               new DataPoint(51,13.1),
               new DataPoint(52,13.2),
               new DataPoint(53,13.3),
               new DataPoint(54,13.4),
               new DataPoint(55,13.45),
               new DataPoint(56,13.5),
               new DataPoint(57,13.6),
               new DataPoint(58,13.6),
               new DataPoint(59,13.6),
               new DataPoint(60,13.6),

            };
            // Default data points for graph 3
            dataPoints3 = new List<DataPoint>
            {
               new DataPoint(0,3.2),
               new DataPoint(1, 4.2),
               new DataPoint(2,5),
               new DataPoint(3,5.6),
               new DataPoint(4,6.2),
               new DataPoint(5,6.8),
               new DataPoint(6,7.2),
               new DataPoint(7,7.45),
               new DataPoint(8,7.75),
               new DataPoint(9,8),
               new DataPoint(10,8.35),
               new DataPoint(11,8.6),
               new DataPoint(12,8.8),
               new DataPoint(13,9.1),
               new DataPoint(14,9.3),
               new DataPoint(15,9.6),
               new DataPoint(16,9.8),
               new DataPoint(17,10),
               new DataPoint(18,10.2),
               new DataPoint(19,10.4),
               new DataPoint(20,10.65),
               new DataPoint(21,11),
               new DataPoint(22,11.15),
               new DataPoint(23,11.4),
               new DataPoint(24,11.6),
               new DataPoint(25,11.8),
               new DataPoint(26,12),
               new DataPoint(27,12.15),
               new DataPoint(28,12.4),
               new DataPoint(29,12.6),
               new DataPoint(30,12.8),
               new DataPoint(31,13),
               new DataPoint(32,13.2),
               new DataPoint(33,13.4),
               new DataPoint(34,13.6),
               new DataPoint(35,13.75),
               new DataPoint(36,13.9),
               new DataPoint(37,14),
               new DataPoint(38,14.2),
               new DataPoint(39,14.4),
               new DataPoint(40,14.6),
               new DataPoint(41,14.8),
               new DataPoint(42,15),
               new DataPoint(43,15.2),
               new DataPoint(44,15.4),
               new DataPoint(45,15.5),
               new DataPoint(46,15.65),
               new DataPoint(47,15.8),
               new DataPoint(48,16),
               new DataPoint(49,16.2),
               new DataPoint(50,16.4),
               new DataPoint(51,16.65),
               new DataPoint(52,17),
               new DataPoint(53,17.15),
               new DataPoint(54,17.3),
               new DataPoint(55,17.4),
               new DataPoint(56,17.5),
               new DataPoint(57,17.65),
               new DataPoint(58,17.8),
               new DataPoint(59,17.9),
               new DataPoint(60,18),

            };

            dataPoints4 = new List<DataPoint>
            {
               new DataPoint(0,4.2),
               new DataPoint(1, 5.2),
               new DataPoint(2,6),
               new DataPoint(3,7),
               new DataPoint(4,8),
               new DataPoint(5,8.6),
               new DataPoint(6,9),
               new DataPoint(7,9.4),
               new DataPoint(8,9.8),
               new DataPoint(9,10.2),
               new DataPoint(10,10.6),
               new DataPoint(11,11),
               new DataPoint(12,11.3),
               new DataPoint(13,11.6),
               new DataPoint(14,12),
               new DataPoint(15,12.3),
               new DataPoint(16,12.45),
               new DataPoint(17,12.8),
               new DataPoint(18,13),
               new DataPoint(19,13.35),
               new DataPoint(20,13.6),
               new DataPoint(21,13.9),
               new DataPoint(22,14.2),
               new DataPoint(23,14.45),
               new DataPoint(24,14.8),
               new DataPoint(25,15),
               new DataPoint(26,15.2),
               new DataPoint(27,15.5),
               new DataPoint(28,15.8),
               new DataPoint(29,16),
               new DataPoint(30,16.3),
               new DataPoint(31,16.6),
               new DataPoint(32,17),
               new DataPoint(33,17.2),
               new DataPoint(34,17.5),
               new DataPoint(35,17.7),
               new DataPoint(36,18),
               new DataPoint(37,18.2),
               new DataPoint(38,18.4),
               new DataPoint(39,18.7),
               new DataPoint(40,19),
               new DataPoint(41,19.2),
               new DataPoint(42,19.55),
               new DataPoint(43,19.8),
               new DataPoint(44,20.15),
               new DataPoint(45,20.4),
               new DataPoint(46,20.8),
               new DataPoint(47,21.05),
               new DataPoint(48,21.4),
               new DataPoint(49,21.8),
               new DataPoint(50,22),
               new DataPoint(51,22.25),
               new DataPoint(52,22.6),
               new DataPoint(53,22.85),
               new DataPoint(54,23.2),
               new DataPoint(55,23.4),
               new DataPoint(56,23.65),
               new DataPoint(57,23.99),
               new DataPoint(58,24.2),
               new DataPoint(59,24.4),
               new DataPoint(60,24.6),

            };

            dataPoints5 = new List<DataPoint>
            {
               new DataPoint(0,4.8),
               new DataPoint(1, 6.2),
               new DataPoint(2,7.4),
               new DataPoint(3,8.4),
               new DataPoint(4,9),
               new DataPoint(5,9.8),
               new DataPoint(6,10.4),
               new DataPoint(7,11),
               new DataPoint(8,11.6),
               new DataPoint(9,12),
               new DataPoint(10,12.3),
               new DataPoint(11,12.6),
               new DataPoint(12,13),
               new DataPoint(13,13.4),
               new DataPoint(14,13.8),
               new DataPoint(15,14.2),
               new DataPoint(16,14.45),
               new DataPoint(17,14.8),
               new DataPoint(18,15.2),
               new DataPoint(19,15.4),
               new DataPoint(20,15.6),
               new DataPoint(21,15.85),
               new DataPoint(22,16.2),
               new DataPoint(23,16.45),
               new DataPoint(24,16.8),
               new DataPoint(25,17.2),
               new DataPoint(26,17.55),
               new DataPoint(27,17.8),
               new DataPoint(28,18),
               new DataPoint(29,18.4),
               new DataPoint(30,18.75),
               new DataPoint(31,19),
               new DataPoint(32,19.4),
               new DataPoint(33,19.8),
               new DataPoint(34,20.2),
               new DataPoint(35,20.45),
               new DataPoint(36,20.8),
               new DataPoint(37,21),
               new DataPoint(38,21.4),
               new DataPoint(39,21.8),
               new DataPoint(40,22.2),
               new DataPoint(41,22.6),
               new DataPoint(42,22.85),
               new DataPoint(43,23.2),
               new DataPoint(44,23.45),
               new DataPoint(45,23.8),
               new DataPoint(46,24.2),
               new DataPoint(47,24.6),
               new DataPoint(48,25),
               new DataPoint(49,25.4),
               new DataPoint(50,25.8),
               new DataPoint(51,26.1),
               new DataPoint(52,26.5),
               new DataPoint(53,26.8),
               new DataPoint(54,27),
               new DataPoint(55,27.4),
               new DataPoint(56,27.8),
               new DataPoint(57,28.2),
               new DataPoint(58,28.45),
               new DataPoint(59,28.85),
               new DataPoint(60,29.4),

            };

            // Add default data points to the chart
            AddDataPointsToChart(chart2, dataPoints1);
            AddDataPointsToChart(chart2, dataPoints2);
            AddDataPointsToChart(chart2, dataPoints3);
            AddDataPointsToChart(chart2, dataPoints4);
            AddDataPointsToChart(chart2, dataPoints5);

            // Set axis ranges
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 60;
            chart2.ChartAreas[0].AxisY.Minimum = 1;
            chart2.ChartAreas[0].AxisY.Maximum = 30;
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisY.Interval = 1;

            chart2.Series["Series1"].LegendText = "Severe underweight";
            chart2.Series["Series1"].Color = Color.Red;
            chart2.Series["Series2"].LegendText = "Moderate Underweight";
            chart2.Series["Series2"].Color = Color.Orange;
            chart2.Series["Series3"].LegendText = "Normal";
            chart2.Series["Series3"].Color = Color.Green;
            chart2.Series["Series4"].LegendText = "Possible underweight";
            chart2.Series["Series4"].Color = Color.Black;
            chart2.Series["Series5"].LegendText = "Check weight for weight";
            chart2.Series["Series5"].Color = Color.Cyan;


        }
        private void AddDataPointsToChart(Chart chart, List<DataPoint> dataPoints)
        {
            Series weight = new Series();
            weight.Color = Color.RoyalBlue;
            weight.BorderWidth = 2;

            foreach (DataPoint dataPoint in dataPoints)
            {
                weight.Points.Add(dataPoint);
            }

            weight.ChartType = SeriesChartType.Spline;
            chart2.Series.Add(weight);


        }
        public void Plot_Weight_Graph(List<DataPoint> po)
        {
            Series weight = new Series();
            weight.ChartType = SeriesChartType.Spline;

            foreach (DataPoint dataPoint in po)
            {
                weight.Points.Add(dataPoint);
            }


            weight.MarkerBorderWidth = 10;
            weight.Color = Color.Blue;
            weight.BorderWidth = 5;
            weight.LegendText = "For the child";
            weight.MarkerStyle = MarkerStyle.Circle;

            weight.MarkerColor = Color.Black;
            chart2.Series.Add(weight);
        }




        /*-----------------------graphs for weight functions-----------------*/

        public void Create_Graphs_For_Height()
        {
            double[] Line1 = new double[] {44, 47, 51, 53, 56, 57, 59, 60, 61.5, 62.5, 63.6,
            65, 66, 67, 68, 69, 70, 70.5, 71.5, 72, 73, 74, 75, 76, 76.5, 77, 77.5, 78, 79,
            79.5, 80, 80.9, 81, 82, 82, 83, 83.5, 84, 84.5, 85, 85.5, 86, 86.8, 87, 88,
            88.5, 89, 89.1, 90, 90.4, 90.8, 91, 91.8, 92, 92.5, 93, 93.5, 93.9, 94, 94.5, 95};


            double[] Line2 = new double[]{46, 50,54, 56, 58, 60, 61, 62.5, 63.5,
           65, 66, 67.5, 69, 70, 71, 72, 73, 74, 75, 76, 78, 78.5, 79.5,
           80, 80.5, 81, 81, 82, 82.5, 83, 84, 84.5, 85, 86, 86.5, 87,87.5,
           88, 89.1, 89.5, 90, 90.5, 91, 91.5, 92, 92.5, 93, 93.5, 94,
           95, 95.5, 96.5, 97, 97.5, 98, 98.5, 99, 99, 99.6, 99.8, 100};

            double[] Line3 = new double[] {50, 54, 57, 60, 62, 64, 66, 67, 68, 70, 71, 72.5,
                74, 75, 76, 77, 78, 79.5, 80.5, 81.5, 82.5, 83.5, 84, 85, 86, 87, 87, 88, 89,
                90, 90.5, 91, 92, 92.5, 93, 94, 94.5, 95, 96.5, 97, 97.8, 98.5, 99, 99.5, 100,
                100.5, 101, 102, 102.5, 103, 103.9, 104, 105, 105.5, 106, 106.5, 107, 107.5,
                108, 109, 110};

            double[] Line4 = new double[] { 53, 57,60,64,66,68,70,71,73,74,75,76.5,78,79,80.5,82,83,84,
            85.7,86.5,88,89.5,90.5,92,93,94,94,95,96,97,97.5,98.5,99.5,100,101,102,103,103.5,104.5,105,106,106.7,
            107,108,108.5,109,109.5,110,111,111.5,112,112.9,113.1,113.5,114,115,116,117,117.5,118,119 };

            double[] Line5 = new double[] {55,60, 63,66,68,70,72,74,75,77,78.8, 80,81,82.5,85,85,86.5,88,89,90.5,
            91.5,92.8,94,95,96,97,97,98,99,100,101,101.5,102.5,103.5,104.5,105,106,107,108,109,109.5,110.5,111.5,
            112,113,113.5,114,114.5,115,116,116.5,117,118,119,120,121,121.5,122,123,123.5,124 };

            PlotThem(Line1, gender);
            PlotThem(Line2, gender);
            PlotThem(Line3, gender);
            PlotThem(Line4, gender);
            PlotThem(Line5, gender);

            // Set axis ranges
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 60;
            chart1.ChartAreas[0].AxisY.Minimum = 40;
            chart1.ChartAreas[0].AxisY.Maximum = 145;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 5;

            chart1.Series["Series1"].LegendText = "Severe Stunted";
            chart1.Series["Series1"].Color = Color.Red;
            chart1.Series["Series2"].LegendText = "Moderate Stunted";
            chart1.Series["Series2"].Color = Color.Orange;
            chart1.Series["Series3"].LegendText = "Normal";
            chart1.Series["Series3"].Color = Color.Green;
            chart1.Series["Series4"].LegendText = "Normal";
            chart1.Series["Series4"].Color = Color.Black;
            chart1.Series["Series5"].LegendText = "Possible very tall";
            chart1.Series["Series5"].Color = Color.Cyan;


        }
        public void PlotThem(double[] dataR, string sex)
        {
            Series month = new Series();
            month.Color = Color.RoyalBlue;
            month.BorderWidth = 2;


            List<DataPoint> dataPoints11 = new List<DataPoint>();
            month.ChartType = SeriesChartType.Line;

            if (gender.ToLower() == "male")
            {
                for (int i = 0; i < dataR.Length; i++)
                {
                    DataPoint b = new DataPoint(i, (dataR[i] + 10));
                    dataPoints11.Add(b);

                }

            }
            else
            {
                for (int i = 0; i < dataR.Length; i++)
                {
                    DataPoint b = new DataPoint(i, dataR[i]);
                    dataPoints11.Add(b);

                }
            }



            foreach (DataPoint dataPoint in dataPoints11)
            {
                month.Points.Add(dataPoint);
            }



            chart1.Series.Add(month);


        }

        public void Height_Graph_Plot(List<DataPoint> po)
        {

            Series height = new Series();
            height.ChartType = SeriesChartType.Spline;

            try
            {

                foreach (DataPoint dataPoint in po)
                {
                    height.Points.Add(dataPoint);
                }




            }
            catch (Exception)
            {
                MessageBox.Show("Empty field(s)");
            }


            height.MarkerBorderWidth = 10;
            height.Color = Color.Blue;
            height.BorderWidth = 5;
            height.MarkerStyle = MarkerStyle.Circle;
            height.MarkerColor = Color.Black;
            height.LegendText = "For the child";

            chart1.Series.Add(height);


        }


        public void Reset_buttons()
        {


            btnOPV1.Text = string.Empty;
            btnOPV2.Text = string.Empty;
            btnOPV3.Text = string.Empty;
            btnOPV4.Text = string.Empty;
            btnIPV.Text = string.Empty;
            btnDptBooster1.Text = string.Empty;
            btnBCG1.Text = string.Empty;
            btnBCG2.Text = string.Empty;
            btnHepB.Text = string.Empty;
            btnHPV1.Text = string.Empty;
            btnHPV2.Text = string.Empty;
            btnMeasles1.Text = string.Empty;
            btnMeasles2.Text = string.Empty;
            btnPenta1.Text = string.Empty;
            btnPenta2.Text = string.Empty;
            btnPenta3.Text = string.Empty;
            btnPneumo1.Text = string.Empty;
            btnPneumo2.Text = string.Empty;
            btnPneumo3.Text = string.Empty;
            btnRotavirus1.Text = string.Empty;
            btnRotavirus2.Text = string.Empty;
            btnTD1.Text = string.Empty;
            btnTD2.Text = string.Empty;

            checkBoxBCG.Checked = false;
            checkBoxDPT.Checked = false;
            checkBoxDPT_Hib1.Checked = false;
            checkBoxDPT_Hib2.Checked = false;
            checkBoxDPT_Hib3.Checked = false;
            checkBoxHepB.Checked = false;
            checkBoxHPV1.Checked = false;
            checkBoxHPV2.Checked = false;
            checkBoxMeaslesRubella1.Checked = false;
            checkBoxIPV.Checked = false;
            checkBoxMeaslesRubella2.Checked = false;
            checkBoxOPV1.Checked = false;
            checkBoxOPV2.Checked = false;
            checkBoxOPV3.Checked = false;
            checkBoxOPV4.Checked = false;
            checkBoxPneumococcal_1.Checked = false;
            checkBoxPneumococcal_2.Checked = false;
            checkBoxPneumococcal_3.Checked = false;
            checkBoxRotavirus1.Checked = false;
            checkBoxRotavirus2.Checked = false;
            checkBoxTD1.Checked = false;
            checkBoxTD2.Checked = false;
            checkBoxTyphoid.Checked = false;







        }

        public void Clear()
        {
            foreach (Control c in pnlTreatments.Controls)
            {
                if (c is BunifuMaterialTextbox || c is RichTextBox || c is TextBox)
                {
                    c.Text = string.Empty;


                }
            }

            foreach (Control c in pnlPatient_Reg.Controls)
            {
                if (c is BunifuMaterialTextbox || c is RichTextBox || c is TextBox || c is ComboBox)
                {
                    c.Text = string.Empty;


                }
            }

        }

        public Panel pnlForPatients()
        {
            PatientDGV.DataSource = obj.Patient_load();


            return pnlPatient_Reg;
        }

        public Panel Treatments()
        {
            TDGV.DataSource = obj.Treatments_load();
            return pnlTreatments;
        }

        public Panel Diagnosis()
        {
            DiagnosisGridView.DataSource = obj.Diagnosis_load();

            return pnlDiagnosis;
        }

        public Panel Immunisation()
        {
            IMDGV.DataSource = obj.Immunisation_load();
            return pnl_Immunise;
        }

        public Panel Visuals()
        {
            return pnlVisuals;
        }





        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomLabel2_Click_2(object sender, EventArgs e)
        {
            foreach (Control c in pnlkkkk.Controls)
            {
                if (c is Panel)
                {
                    c.Dock = DockStyle.None;
                    c.Visible = false;
                }

            }

            pnlPatient_Reg.Visible = true;
            pnlPatient_Reg.Dock = DockStyle.Fill;
        }

        private void DASHBOARD_Load(object sender, EventArgs e)
        {


            PatientDGV.DataSource = obj.Patient_load();
            TDGV.DataSource = obj.Treatments_load();
            DiagnosisGridView.DataSource = obj.Diagnosis_load();
            gridAppointments.DataSource = obj.Appointments_Search_Today(docId, "Pending", DateTime.Today);
            bunifuCustomDataGrid1.DataSource = obj.GrowthTable_Load();
            IMDGV.DataSource = obj.Immunisation_load();
            Count();


        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlkkkk.Controls)
            {
                if (c is Panel)
                {
                    c.Dock = DockStyle.None;
                    c.Visible = false;
                }

            }
            pnlDashboard.Visible = true;
            pnlDashboard.Dock = DockStyle.Fill;

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

            try
            {
                string Gender, allergy = "", chronic = "";

                if (Mbtn.Checked == true)
                {
                    Gender = Mbtn.Text;
                }
                else
                {
                    Gender = Fbtn.Text;
                }

                foreach (string s in PAllergic.CheckedItems)
                {
                    allergy += s + "\n";
                }

                foreach (string s in PChronic.CheckedItems)
                {
                    chronic += s + "\n";
                }

                PatientDGV.DataSource = obj.Patient_Insert(txtFName.Text, txtMName.Text, txtLName.Text, DateTime.Parse(DOB.Text), DateTime.Now, txtPAddress.Text, txtPhone.Text, txtPEmail.Text, cbBG.Text, Gender, allergy, chronic);
                Count();
                MessageBox.Show("Record Saved");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Gender, allergy = "", chronic = "";

                if (Mbtn.Checked == true)
                {
                    Gender = Mbtn.Text;
                }
                else
                {
                    Gender = Fbtn.Text;
                }

                foreach (string s in PAllergic.CheckedItems)
                {
                    allergy += s + "\n";
                }

                foreach (string s in PChronic.CheckedItems)
                {
                    chronic += s + "\n";
                }
                PatientDGV.DataSource = obj.Patient_Update(id, txtFName.Text, txtMName.Text, txtLName.Text, DateTime.Parse(DOB.Text), DateTime.Now, txtPAddress.Text, txtPhone.Text, txtPEmail.Text, cbBG.Text, Gender, allergy, chronic);

                Count();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PatientDGV.DataSource = obj.Patient_Delete(id);
                Clear();
                Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.TextLength != 0)
                {
                    PatientDGV.DataSource = obj.Patient_Search(textBox1.Text);
                }
                else
                {
                    PatientDGV.DataSource = obj.Patient_load();
                }
                Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PatientDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index;
                if (e.RowIndex >= 0)
                {
                    index = e.RowIndex;
                    id = Convert.ToInt32(PatientDGV.Rows[index].Cells[0].Value.ToString());
                    txtFName.Text = PatientDGV.Rows[index].Cells["FName"].Value.ToString();
                    txtMName.Text = PatientDGV.Rows[index].Cells["MName"].Value.ToString();
                    txtLName.Text = PatientDGV.Rows[index].Cells["LName"].Value.ToString();

                    if (DateTime.TryParse(PatientDGV.Rows[index].Cells["DOB"].Value.ToString(), out DateTime dateValue))
                    {
                        DOB.Value = dateValue;
                    }
                    if (DateTime.TryParse(PatientDGV.Rows[index].Cells["RegDate"].Value.ToString(), out DateTime dateValue1))
                    {
                        RegDate.Value = dateValue1;
                    }
                    if (PatientDGV.Rows[index].Cells["Gender"].Value.ToString().ToLower() == "male")
                    {
                        Mbtn.Checked = true;
                    }
                    else
                    {
                        Fbtn.Checked = true;
                    }
                    txtFName.Text = PatientDGV.Rows[index].Cells["FName"].Value.ToString();

                    txtPAddress.Text = PatientDGV.Rows[index].Cells["PatAddress"].Value.ToString();
                    txtPhone.Text = PatientDGV.Rows[index].Cells["Phone"].Value.ToString();
                    txtPEmail.Text = PatientDGV.Rows[index].Cells["PatEmail"].Value.ToString();
                    cbBG.Text = PatientDGV.Rows[index].Cells["BG"].Value.ToString();

                }
            }
            catch
            {

            }

        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int n = obj.Patient_Search(txtPATID.Text).Rows.Count;
                if (n > 0)
                {
                    DiagnosisGridView.DataSource = obj.Diagnosis_Insert(txtPATID.Text, txtSymptoms.Text, txtTest.Text, txtPresc.Text, txtResults.Text, docId, txtHIV.Text);
                }
                else
                {
                    MessageBox.Show("Patient not found. Check your ID or the patient is not registered.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !");
            }
            Count();
            bunifuThinButton23_Click(sender, e);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                int n = obj.Patient_Search(txtPATID.Text).Rows.Count;
                if (n > 0)
                {
                    DiagnosisGridView.DataSource = obj.Diagnosis_Update(id, txtPATID.Text, txtSymptoms.Text, txtTest.Text, txtPresc.Text, txtResults.Text, txtHIV.Text);
                }
                else
                {
                    MessageBox.Show("Patient not found. Check your ID or the patient is not registered.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error !");

            }
            Count();
            bunifuThinButton23_Click(sender, e);

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                DiagnosisGridView.DataSource = obj.Diagnosis_Delete(id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error !"); }
            Count();
            bunifuThinButton23_Click(sender, e);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
           
            txtPATID.Text = string.Empty;
            txtPresc.Text = string.Empty;
            txtPresc.Text = string.Empty;
            txtSymptoms.Text = string.Empty;
            
            txtResults.Text = string.Empty;
           
            txtHIV.SelectedText = string.Empty;
            txtTest.SelectedText = string.Empty;
        }

        private void DiagnosisGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                if (index >= 0)
                {
                    id = Convert.ToInt32(DiagnosisGridView.Rows[index].Cells[0].Value.ToString());
                    txtPATID.Text = DiagnosisGridView.Rows[index].Cells[1].Value.ToString();
                    txtSymptoms.Text = DiagnosisGridView.Rows[index].Cells[2].Value.ToString();
                    txtTest.Text = DiagnosisGridView.Rows[index].Cells[3].Value.ToString();
                    txtPresc.Text = DiagnosisGridView.Rows[index].Cells[4].Value.ToString();
                    txtResults.Text = DiagnosisGridView.Rows[index].Cells[5].Value.ToString();
                    txtHIV.Text = DiagnosisGridView.Rows[index].Cells[7].Value.ToString();




                }
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0)
            {
                DiagnosisGridView.DataSource = obj.Diagnosis_Search(textBox2.Text);
            }
            else
            {
                DiagnosisGridView.DataSource = obj.Diagnosis_load();
            }
        }

        private void DIG_INF_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlkkkk.Controls)
            {
                if (c is Panel)
                {
                    c.Dock = DockStyle.None;
                    c.Visible = false;
                }

            }

            pnlDiagnosis.Visible = true;
            pnlDiagnosis.Dock = DockStyle.Fill;
        }


        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = DateTime.Now;
            int n = obj.Patient_Search(txtPatientID.Text).Rows.Count;
            if (n > 0)
            {
                TDGV.DataSource = obj.Treatments_Insert(txtPatientID.Text, richTextBox2.Text, txtMedicine.Text, richTextBox1.Text, docId, date);
                Clear();
            }
            else { MessageBox.Show("Patient not with supplied ID not found"); }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            TDGV.DataSource = obj.Treatments_Update(id, txtPatientID.Text, richTextBox2.Text, txtMedicine.Text, richTextBox1.Text);
            Clear();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            TDGV.DataSource = obj.Treatments_Delete(id);
            Clear();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

            if (bunifuMaterialTextbox2.Text.Length > 0)
            {
                try
                {
                    TDGV.DataSource = obj.Treatments_Search(bunifuMaterialTextbox2.Text);
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
            else
            {
                TDGV.DataSource = obj.Treatments_load();
            }
        }

        private void TDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            try
            {
                if (e.RowIndex >= 0)
                {
                    index = e.RowIndex;
                    id = Convert.ToInt32(TDGV.Rows[index].Cells[0].Value.ToString());
                    txtPatientID.Text = TDGV.Rows[index].Cells[1].Value.ToString();
                    richTextBox2.Text = TDGV.Rows[index].Cells["DISEASE"].Value.ToString();
                    txtMedicine.Text = TDGV.Rows[index].Cells["MEDICINE"].Value.ToString();
                    richTextBox1.Text = TDGV.Rows[index].Cells["DOSAGE"].Value.ToString();

                }
            }
            catch { }
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlkkkk.Controls)
            {
                if (c is Panel)
                {
                    c.Dock = DockStyle.None;
                    c.Visible = false;
                }

            }

            pnlTreatments.Visible = true;
            pnlTreatments.Dock = DockStyle.Fill;
        }
        private void button27_Click(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now;
            int n = obj.Patient_Search(TxtPatientId_Immunisation.Text).Rows.Count;
            string patientID = TxtPatientId_Immunisation.Text;
            if (n > 0)
            {
                IMDGV.DataSource = obj.Immunisation_Insert(TxtPatientId_Immunisation.Text, cmbVaccine.Text, cmbDose.Text, txtBatch.Text, date, docId);


                try
                {

                    string appointment = "";

                    DateTime dob = obj.Patient_Search(patientID).Rows[0].Field<DateTime>("DOB"); //.ToString("dd/MM/yyyy");
                                                                                                 // date = DateTime.Now;

                    string time = DateTime.Now.ToString("HH:mm");
                    date = dob.AddDays(42);
                    string Vaccine = cmbVaccine.Text;



                    if (Vaccine == "BCG")
                    {

                        date = dob.AddDays(6 * 7);

                        appointment = "DTP-Hib-B1 \nOPV 1\nPNEUMOCOCCAL 1\nROTAVIRUS 1";
                        obj.Appointments_Insert(docId, patientID, date, time, appointment, "Pending");
                        MessageBox.Show("Record Saved");
                        button29_Click(sender, e);

                    }

                    if (cmbVaccine.Text == "OPV")
                    {



                        if (cmbDose.Text == "1")
                        {
                            date = dob.AddDays(10 * 7);
                            appointment = "DTP-Hib-B2 \nOPV 2\nPNEUMOCOCCAL 2\nROTAVIRUS 2";
                        }
                        else if (cmbDose.Text == "2")
                        {
                            appointment = "DTP-Hib-B3 \nOPV 3\nPNEUMOCOCCAL 3\n IPV";
                            date = dob.AddDays(14 * 7);

                        }
                        else if (cmbDose.Text == "3")
                        {
                            appointment = "MEASLES RUBELLA 1\nTYPHOID VACCINE";
                            date = dob.AddMonths(9);

                        }
                        else if (cmbDose.Text == "4")
                        {
                            appointment = "Td 1";
                            date = dob.AddYears(5);

                        }
                        obj.Appointments_Insert(docId, patientID, date, time, appointment, "Pending");
                        MessageBox.Show("Record Saved");
                        button29_Click(sender, e);
                    }

                    if (cmbVaccine.Text == "MEASLES RUBELLA" && cmbDose.Text == "1")
                    {
                        appointment = "DTP \nOPV \nMEASLES RUBELLA 2";
                        date = dob.AddMonths(18);
                        obj.Appointments_Insert(docId, patientID, date, time, appointment, "Pending");
                        MessageBox.Show("Record Saved");
                        button29_Click(sender, e);
                    }

                    if (cmbVaccine.Text == "TD")
                    {
                        if (cmbDose.Text == "1")
                        {
                            appointment = "TD 2";
                            date = dob.AddYears(10);
                        }
                        else
                        {
                            appointment = "HPV 1";
                            date = dob.AddYears(10);

                        }
                        obj.Appointments_Insert(docId, patientID, date, time, appointment, "Pending");
                        MessageBox.Show("Record Saved");
                        button29_Click(sender, e);


                    }

                    if (cmbVaccine.Text == "HPV")
                    {
                        if (cmbDose.Text == "1")
                        {
                            appointment = "HPV 2";
                            date = dob.AddYears(11);
                        }
                        obj.Appointments_Insert(docId, patientID, date, time, appointment, "Pending");
                        MessageBox.Show("Record Saved");
                        button29_Click(sender, e);
                    }

                   
                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on saving appointments");
                }
                Count();


            }
            else
            {
                MessageBox.Show("Patient not found. Check your ID or the patient is not registered.");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {

            try
            {
                IMDGV.DataSource = obj.Immunisation_Update(id, cmbVaccine.Text, cmbDose.Text, txtBatch.Text);
                button29_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Count();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                IMDGV.DataSource = obj.Immunisation_Delete(id);
                button29_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Count();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            txtBatch.Text = string.Empty;
            TxtPatientId_Immunisation.Text = string.Empty;
            cmbDose.Text = string.Empty;
            cmbVaccine.Text = string.Empty;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                dataGridView1.Visible = true;
                dataGridView1.DataSource = obj.Immunisation_Track_Search_For_Grid(textBox3.Text);
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Visible = false;
                Reset_buttons();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            string patientID;

            if (e.RowIndex >= 0)
            {

                index = e.RowIndex;


                textBox3.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                patientID = dataGridView1.Rows[index].Cells[0].Value.ToString();


                dataGridView1.Visible = false;

                /*----------------For loading child identification details---------------------*/
                try
                {
                    lblChildName.Text = obj.Patient_Search(patientID).Rows[0].Field<string>("FName") + " " + obj.Patient_Search(patientID).Rows[0].Field<string>("MName");


                    lblDOB.Text = obj.Patient_Search(patientID).Rows[0].Field<DateTime>("DOB").ToString("dd/MM/yyyy");
                    lblSex.Text = obj.Patient_Search(patientID).Rows[0].Field<string>("Gender");
                    lblAllergy.Text = obj.Patient_Search(patientID).Rows[0].Field<string>("PatAllergic");
                    gender = lblSex.Text;

                    lblHIVstatus.Text = "NEGATIVE";
                    if (obj.Diagnosis_Check_HIV_Status(patientID).Rows.Count > 0)
                    {
                        lblHIVstatus.Text = "POSITIVE";
                    }
                    lblChronic.Text = obj.Patient_Search(patientID).Rows[0].Field<string>("PatChronic");

                    //lblHIVstatus.Text = dataGridView1.Rows[0].Cells["HIV STATUS"].Value.ToString(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on fetching from patients table");
                }
                gender = lblSex.Text.ToLower();


                int nH = obj.GrowthTable_Height_Select(patientID).Rows.Count;
                int n = obj.GrowthTable_Weight_Select(patientID).Rows.Count;
                int n1, n4;
                Single n2, n3;

                if (n > 0)
                {
                    List<DataPoint> points = new List<DataPoint>();
                    points = new List<DataPoint>();
                    dataGridView2.DataSource = obj.GrowthTable_Weight_Select(patientID);

                    for (int k = 0; k < n; k++)
                    {

                        try
                        {
                            n1 = Convert.ToInt32(dataGridView2.Rows[k].Cells[0].Value.ToString());

                            n2 = float.Parse(dataGridView2.Rows[k].Cells[1].Value.ToString());

                            points.Add(new DataPoint(n1, n2));

                            // MessageBox.Show("Age = " + n4.ToString() + " Height = " +n3.ToString(),"Error");

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Error");

                        }

                    }

                    chart2.Series.Clear();
                    // Create_Graphs_For_Height();
                    LoadDefaultGraphs_Fo_Girls();

                    Plot_Weight_Graph(points);
                }
                else
                {
                    MessageBox.Show("Number of records = " + n.ToString());
                }

                if (nH > 0)
                {
                    dataGridView1.DataSource = obj.GrowthTable_Height_Select(patientID);
                    List<DataPoint> points = new List<DataPoint>();
                    points = new List<DataPoint>();
                    for (int k = 0; k < n; k++)
                    {

                        try
                        {
                            n4 = Convert.ToInt32(dataGridView1.Rows[k].Cells[0].Value.ToString());

                            n3 = float.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString());
                            points.Add(new DataPoint(n4, n3));

                            // MessageBox.Show("Age = " + n4.ToString() + " Height = " +n3.ToString(),"Error");

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Error");

                        }
                   
                    }
                    chart1.Series.Clear();
                    Create_Graphs_For_Height();
                    Height_Graph_Plot(points);
                }
                else
                {
                    MessageBox.Show("Number of records = " + nH.ToString());
                }




                /*--------------------------------------------------------------------------------------------*/

                /*----------------------for loading immunisation records------------------------------------*/

                Reset_buttons();
                string vaccine, dose, dateI, batch;
                int i = obj.Immunisation_Track_Search(patientID).Rows.Count; int j = 0;

                if (i > 0)
                {

                    try
                    {
                        for (j = 0; j < i; j++)
                        {




                            vaccine = obj.Immunisation_Track_Search(patientID).Rows[j].Field<string>("VACCINE");
                            batch = obj.Immunisation_Track_Search(patientID).Rows[j].Field<string>("BATCH NUMBER");

                            DateTime mdate = obj.Immunisation_Track_Search(patientID).Rows[j].Field<DateTime>("DATE IMMUNISED");
                            dateI = mdate.ToString("dd/MM/yyyy");
                            dose = obj.Immunisation_Track_Search(patientID).Rows[j].Field<int>("DOSE NUMBER").ToString();

                            if (vaccine == "BCG")
                            {
                                btnBCG1.Text = dateI + "\n" + batch;
                                checkBoxBCG.Checked = true;

                            }
                            else if (vaccine == "Hep B" && dose == "1")
                            {
                                btnHepB.Text = dateI + "\n" + batch;
                                checkBoxHepB.Checked = true;
                            }
                            else if (vaccine == "OPV" && dose == "1")
                            {
                                btnOPV1.Text = dateI + "\n" + batch;
                                checkBoxOPV1.Checked = true;
                            }
                            else if (vaccine == "OPV" && dose == "2")
                            {
                                btnOPV2.Text = dateI + "\n" + batch;
                                checkBoxOPV2.Checked = true;

                            }
                            else if (vaccine == "OPV" && dose == "3")
                            {
                                btnOPV3.Text = dateI + "\n" + batch;
                                checkBoxOPV3.Checked = true;

                            }
                            else if (vaccine == "OPV" && dose == "4")
                            {
                                btnOPV4.Text = dateI + "\n" + batch;
                                checkBoxOPV4.Checked = true;

                            }
                            else if (vaccine == "IPV" && dose == "1")
                            {

                                btnIPV.Text = dateI + "\n" + batch;
                                checkBoxIPV.Checked = true;
                            }
                            else if (vaccine == "PENTAVALENT" && dose == "1")
                            {
                                btnPenta1.Text = dateI + "\n" + batch;
                                checkBoxDPT_Hib1.Checked = true;
                            }
                            else if (vaccine == "PENTAVALENT" && dose == "2")
                            {
                                btnPenta2.Text = dateI + "\n" + batch;
                                checkBoxDPT_Hib2.Checked = true;
                            }
                            else if (vaccine == "PENTAVALENT" && dose == "3")
                            {
                                btnPenta3.Text = dateI + "\n" + batch;
                                checkBoxDPT_Hib3.Checked = true;
                            }
                            else if (vaccine == "PNEUMOCOCCAL" && dose == "1")
                            {
                                btnPneumo1.Text = dateI + "\n" + batch;
                                checkBoxPneumococcal_1.Checked = true;

                            }
                            else if (vaccine == "PNEUMOCOCCAL" && dose == "2")
                            {

                                btnPneumo2.Text = dateI + "\n" + batch;
                                checkBoxPneumococcal_2.Checked = true;
                            }
                            else if (vaccine == "PNEUMOCOCCAL" && dose == "3")
                            {
                                btnPneumo3.Text = dateI + "\n" + batch;
                                checkBoxPneumococcal_3.Checked = true;

                            }
                            else if (vaccine == "ROTAVIRUS" && dose == "1")
                            {
                                btnRotavirus1.Text = dateI + "\n" + batch;
                                checkBoxRotavirus1.Checked = true;
                            }
                            else if (vaccine == "ROTAVIRUS" && dose == "2")
                            {
                                btnRotavirus2.Text = dateI + "\n" + batch;
                                checkBoxRotavirus2.Checked = true;
                            }
                            else if (vaccine == "MEASLES RUBELLA" && dose == "1")
                            {
                                btnMeasles1.Text = dateI + "\n" + batch;
                                checkBoxMeaslesRubella1.Checked = true;
                            }
                            else if (vaccine == "MEASLES RUBELLA" && dose == "2")
                            {

                                btnMeasles2.Text = dateI + "\n" + batch;
                                checkBoxMeaslesRubella2.Checked = true;

                            }
                            else if (vaccine == "DPT BOOSTER" && dose == "1")
                            {

                                btnDptBooster1.Text = dateI + "\n" + batch;
                                checkBoxDPT.Checked = true;
                            }
                            else if (vaccine == "TD" && dose == "1")
                            {

                                btnTD1.Text = dateI + "\n" + batch;
                                checkBoxTD1.Checked = true;
                            }
                            else if (vaccine == "TD" && dose == "2")
                            {
                                btnTD2.Text = dateI + "\n" + batch;
                                checkBoxTD2.Checked = true;
                            }
                            else if (vaccine == "HPV" && dose == "1")
                            {
                                btnHPV1.Text = dateI + "\n" + batch;
                                checkBoxHPV1.Checked = true;

                            }
                            else if (vaccine == "HPV" && dose == "2")
                            {
                                btnHPV2.Text = dateI + "\n" + batch;
                                checkBoxHPV2.Checked = true;
                            }
                            else
                            {
                                //done
                            }

                        }
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);

                    }

                    /*
                     
                     
                    BCG
                    Hep B
                    OPV
                    IPV
                    PENTAVALENT
                    PNEUMOCOCCAL
                    ROTAVIRUS
                    MEASLES RUBELLA
                    DPT BOOSTER
                    TD
                    HPV
                     
                     
                    
                     */


                }
                else
                {
                    MessageBox.Show("Record not found");
                }

            }
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text.Length > 0)
            {
                IMDGV.DataSource = obj.Immunisation_Search(bunifuMaterialTextbox1.Text);
            }
            else
            {
                IMDGV.DataSource = obj.Immunisation_load();
            }
        }



        private void IMDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                if (index >= 0)
                {
                    id = Convert.ToInt32(IMDGV.Rows[index].Cells[0].Value.ToString());
                    TxtPatientId_Immunisation.Text = IMDGV.Rows[index].Cells[1].Value.ToString();
                    txtBatch.Text = IMDGV.Rows[index].Cells[4].Value.ToString();
                    cmbDose.Text = IMDGV.Rows[index].Cells[3].Value.ToString();
                    cmbVaccine.Text = IMDGV.Rows[index].Cells[2].Value.ToString();


                }
            }
            catch { }
        }

        private void bunifuCustomLabel42_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            try
            {
                int n = obj.Patient_Search(txtChecID.Text).Rows.Count;
                if (n > 0)
                {
                    string bp = txtBP.Text;
                    string Patid = txtChecID.Text;
                    int month = Convert.ToInt32(txtMonth.Text);
                    float height = float.Parse(txtHeight.Text);
                   
                    float weit = float.Parse(txtWeight.Text);
                    float tem = float.Parse(txtTemp.Text);
                   
                    bunifuCustomDataGrid1.DataSource = obj.GrowthTable_Insert(Patid, month, height, weit, tem, bp);
                    MessageBox.Show("Record Saved");

                }
                else { MessageBox.Show("Patient with supplied ID not found"); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPneumo1_Click(object sender, EventArgs e)
        {

        }

        private void btnPneumo2_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                gridAppointments.DataSource = obj.Appointments_Search_All(docId, comboBoxStatus.Text);

            }
            else
            {
                gridAppointments.DataSource = obj.Appointments_Search_Today(docId, comboBoxStatus.Text, DateTime.Today);

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gridAppointments.DataSource = obj.Appointments_Search_Today(docId, comboBoxStatus.Text, DateTime.Today);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gridAppointments.DataSource = obj.Appointments_Search_All(docId, comboBoxStatus.Text);

        }

        private void bunifuCustomLabel43_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                if (index >= 0)
                {
                    id = Convert.ToInt32(bunifuCustomDataGrid1.Rows[index].Cells[0].Value.ToString());
                    txtChecID.Text = bunifuCustomDataGrid1.Rows[index].Cells[1].Value.ToString();
                    txtMonth.Text = bunifuCustomDataGrid1.Rows[index].Cells[2].Value.ToString();
                    txtHeight.Text = bunifuCustomDataGrid1.Rows[index].Cells[4].Value.ToString();
                    txtWeight.Text = bunifuCustomDataGrid1.Rows[index].Cells[3].Value.ToString();
                    txtTemp.Text = bunifuCustomDataGrid1.Rows[index].Cells[5].Value.ToString();
                    txtBP.Text = bunifuCustomDataGrid1.Rows[index].Cells[6].Value.ToString();


                }
            }
            catch { }
        }

        private void pnlVisuals_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCirclePictureBox1_Click_1(object sender, EventArgs e)
        {
            LOGIN F = new LOGIN();
            CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.Logger = "";
            CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.Save();
            F.Show();
            this.Hide();
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            try
            {
                int n = obj.Patient_Search(txtChecID.Text).Rows.Count;
                if (n > 0)
                {
                    string bp = txtBP.Text;
                    string Patid = txtChecID.Text;
                    int month = Convert.ToInt32(txtMonth.Text);
                    float height = float.Parse(txtHeight.Text);

                    float weit = float.Parse(txtWeight.Text);
                    float tem = float.Parse(txtTemp.Text);

                    bunifuCustomDataGrid1.DataSource = obj.GrowthTable_Update(id,Patid, month, height, weit, tem, bp);
                    MessageBox.Show("Record Updated");

                }
                else { MessageBox.Show("Patient with supplied ID not found"); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid1.DataSource = obj.GrowthTable_Delete(id);

            }
            catch { }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (obj.login(gunaTextBox1.Text, gunaTextBox2.Text, "DOCTOR/NURSE").Rows.Count == 1)
            {
                if (gunaTextBox3.Text == gunaTextBox4.Text)
                {
                    obj.Login_Update(gunaTextBox1.Text, gunaTextBox1.Text, gunaTextBox4.Text);
                    MessageBox.Show("Password successfully changed");
                    // panelRegister.Dock = DockStyle.None;
                    panelRegister.Visible = false;

                    foreach (Control s in panelRegister.Controls)
                    {
                        if (s is GunaTextBox)
                        {
                            s.Text = string.Empty;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Passwords do not match, make \nsure your confirmed password correctly");
                }
            }
            else
            {
                MessageBox.Show("Wrong details supplied");
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            panelRegister.Visible = false;

            foreach (Control s in panelRegister.Controls)
            {
                if (s is GunaTextBox)
                {
                    s.Text = string.Empty;
                }
            }
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {
            panelRegister.Visible = true;
        }

        private void txtFName_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtFName.Text;
            string result = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
            }

            txtFName.Text = result;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtFName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(txtFName, "Invalid input. Only letters are allowed.");
                txtFName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtFName, "");
            }

        }

        private void txtMName_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtMName.Text;
            string result = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
            }

            txtMName.Text = result;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtMName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(txtMName, "Invalid input. Only letters are allowed.");
                txtMName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtMName, "");
            }

        }

        private void txtLName_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtLName.Text;
            string result = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
            }

            txtLName.Text = result;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtLName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(txtLName, "Invalid input. Only letters are allowed.");
                txtLName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtLName, "");
            }

        }

        private void txtPEmail_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtPEmail.Text;
            try
            {
                // Check if the first character is a lowercase letter
                if (!char.IsLower(input[0]))
                {
                    errorProvider1.SetError(txtPEmail, "Email should start with a lowercase letter.");
                    txtPEmail.Focus();
                    return;
                }

                // Check if the email is in the correct format
                if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-z][a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    errorProvider1.SetError(txtPEmail, "Invalid email format.");
                    txtPEmail.Focus();
                }
                else
                {
                    errorProvider1.SetError(txtPEmail, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtPhone_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtPhone.Text;

            // Check if the input starts with +263
            if (!input.StartsWith("+263"))
            {
                errorProvider1.SetError(txtPhone, "Phone number should start with +263.");
                txtPhone.Focus();
                return;
            }

            // Check if the input contains only numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[+0-9]+$"))
            {
                errorProvider1.SetError(txtPhone, "Invalid phone number. Only numbers are allowed.");
                txtPhone.Focus();
            }
            else
            {
                errorProvider1.SetError(txtPhone, "");
            }

        }

        private void txtMonth_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtMonth.Text;

            // Remove non-numeric characters from the input
            txtMonth.Text = System.Text.RegularExpressions.Regex.Replace(input, "[^0-9]", "");

            // Check if the input is a valid integer
            if (!int.TryParse(txtMonth.Text, out int result))
            {
                errorProvider1.SetError(txtMonth, "Invalid input. Only integer values are allowed.");
                txtMonth.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtMonth, "");
            }

        }

        private void txtWeight_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pnlDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlDiagnosis_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
