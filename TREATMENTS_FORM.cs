using Bunifu.Framework.UI;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_
{
    public partial class TREATMENTS_FORM : Form
    {
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
        public TREATMENTS_FORM()
        {
            InitializeComponent();
        }
        CHCMS_CLASS obj = new CHCMS_CLASS();
        int Id;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PAT_REG_Click(object sender, EventArgs e)
        {
            PATIENT_REGISTRATION pATIENT_REGISTRATION = new PATIENT_REGISTRATION(); 
            pATIENT_REGISTRATION.Show();
            this.Hide();
        }

        private void DIG_INF_Click(object sender, EventArgs e)
        {
            DIAGNOSIS dIAGNOSIS = new DIAGNOSIS();  
            dIAGNOSIS.Show();
            this.Hide();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            
            TDGV.DataSource = obj.Treatments_Insert(Convert.ToInt32(txtPatientID.Text),richTextBox2.Text, txtMedicine.Text,richTextBox1.Text);
            Clear();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            TDGV.DataSource = obj.Treatments_Update(Convert.ToInt32(txtPatientID.Text), richTextBox2.Text, txtMedicine.Text, richTextBox1.Text);
            Clear();
        }

        private void txtDNPhone_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            TDGV.DataSource = obj.Treatments_Delete(Id);
            Clear();
        }

        private void TREATMENTS_FORM_Load(object sender, EventArgs e)
        {

            TDGV.DataSource = obj.Treatments_load();
        }

        private void TDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                Id = Convert.ToInt32(TDGV.Rows[index].Cells[0].Value.ToString());
                txtPatientID.Text = Convert.ToString(Id);
                richTextBox2.Text = TDGV.Rows[index].Cells["DISEASE"].Value.ToString();
                txtMedicine.Text = TDGV.Rows[index].Cells["MEDICINE"].Value.ToString();
                richTextBox1.Text = TDGV.Rows[index].Cells["DOSAGE"].Value.ToString();
                            
            }
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

            if (bunifuMaterialTextbox2.Text.Length > 0)
            {
                try
                {
                    TDGV.DataSource = obj.Treatments_Search(Convert.ToInt32(bunifuMaterialTextbox2.Text));
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
    }
}
