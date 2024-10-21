using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_
{
    public partial class DIAGNOSIS : Form
    {
        public DIAGNOSIS()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            foreach (Control c in this.Controls)
            {
                if (c is BunifuMaterialTextbox || c is RichTextBox || c is TextBox)
                {
                    ((BunifuMaterialTextbox)c).Text = string.Empty;

                }
            }
        }

        private void DIAGNOSIS_Load(object sender, EventArgs e)
        {
            weightBindingSource.DataSource = new List<Weight>();
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            if (txtPATID.Text != " ")
            {
               
                
                
                //DiagnosisDGV.DataSource = ds2.Tables[0];
            }
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {
            CHARTS_PANEL.Visible = false;
        }

        private void gunaShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CHARTS_PANEL_Click(object sender, EventArgs e)
        {
            weightBindingSource.DataSource = new List<Weight>();
        }

        private void charts_Click(object sender, EventArgs e)
        {
            CHARTS_PANEL.Visible=true;
        }

        
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void resultsbtn_Click_1(object sender, EventArgs e)
        {

                var objchart = chart1.ChartAreas[0];
                objchart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                objchart.AxisX.Minimum = 1;
                objchart.AxisX.Maximum = 60;

                objchart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                objchart.AxisY.Minimum = 1;
                objchart.AxisY.Maximum = 22;
                chart1.Series.Clear();

                Random random = new Random();

                foreach (Weight w in weightBindingSource.DataSource as List<Weight>)
                {
                    chart1.Series.Add(w.child);
                    chart1.Series[w.child].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    chart1.Series[w.child].Legend = "Legend1";
                    chart1.Series[w.child].ChartArea = "ChartArea1";
                    chart1.Series[w.child].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

                    for (int i = 1; i <= 12; i++)
                    {
                        chart1.Series[w.child].Points.AddXY(i, Convert.ToInt32(w[$"M{i}"]));
                    }
                }
       
        }

        private void bunifuCustomLabel8_Click_1(object sender, EventArgs e)
        {
            CHARTS_PANEL.Visible = false;
        }

        private void DIG_INF_Click(object sender, EventArgs e)
        {

        }

        private void PAT_REG_Click(object sender, EventArgs e)
        {
            PATIENT_REGISTRATION f = new PATIENT_REGISTRATION();
            f.Show();   
            this.Hide();
        }

        private void bunifuCustomLabel12_Click(object sender, EventArgs e)
        {
            TREATMENTS_FORM form = new TREATMENTS_FORM();
            form.Show();
            this.Hide();

        }

        private void resultsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHIV_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
