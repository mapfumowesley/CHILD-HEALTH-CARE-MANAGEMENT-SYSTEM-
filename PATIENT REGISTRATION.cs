using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_
{
    public partial class PATIENT_REGISTRATION : Form

    {
        public PATIENT_REGISTRATION()
        {
            InitializeComponent();
           
        }
        public void Clear()
        {
            foreach (Control c in this.Controls)
            {
                if (c is BunifuMaterialTextbox || c is RichTextBox || c is TextBox || c is ComboBox || c is CheckedListBox)
                {
                    ((BunifuMaterialTextbox)c).Text = string.Empty;

                }
            }
        }

        CHCMS_CLASS obj = new CHCMS_CLASS();
        public int id;
        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void PATIENT_REGISTRATION_Load(object sender, EventArgs e)
        {
            PatientDGV.DataSource = obj.Patient_load();
        }

        private void txtPI_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            string Gender, allergy = null, chronic = null;

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
            PatientDGV.DataSource = obj.Patient_Update(id,txtFName.Text, txtMName.Text, txtLName.Text, DateTime.Parse(DOB.Text), DateTime.Now, txtPAge.Text, txtPAddress.Text, txtPhone.Text, txtPEmail.Text, cbBG.Text, Gender, allergy, chronic);
        }
        
        private void Addbtn_Click(object sender, EventArgs e)
        {
            string Gender, allergy=null, chronic=null;

            if(Mbtn.Checked==true)
            {
                Gender = Mbtn.Text;
            }
            else
            {
                Gender=Fbtn.Text;
            }

           foreach(string s in PAllergic.CheckedItems)
            {
                allergy += s + "\n";
            }

            foreach (string s in PChronic.CheckedItems)
            {
                chronic += s + "\n";
            }

          PatientDGV.DataSource = obj.Patient_Insert(txtFName.Text,txtMName.Text,txtLName.Text,DateTime.Parse(DOB.Text),DateTime.Now,txtPAge.Text,txtPAddress.Text, txtPhone.Text, txtPEmail.Text, cbBG.Text,Gender, allergy,chronic);
            
        }

        private void PAllergic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel16_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            PatientDGV.DataSource = obj.Patient_Delete(id);
        }

        private void PatientDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                id = Convert.ToInt32(PatientDGV.Rows[index].Cells[0].Value.ToString());
                txtFName.Text = PatientDGV.Rows[index].Cells["FName"].Value.ToString();
                txtMName.Text = PatientDGV.Rows[index].Cells["MName"].Value.ToString();
                txtLName.Text = PatientDGV.Rows[index].Cells["LName"].Value.ToString();
                
                if (DateTime.TryParse(PatientDGV.Rows[index].Cells["DOB"].Value.ToString(),out DateTime dateValue))
                 {
                 DOB.Value = dateValue;
                }
                if (DateTime.TryParse(PatientDGV.Rows[index].Cells["RegDate"].Value.ToString(), out DateTime dateValue1))
                {
                    RegDate.Value = dateValue1;
                }
                txtFName.Text = PatientDGV.Rows[index].Cells["FName"].Value.ToString();
                txtPAge.Text = PatientDGV.Rows[index].Cells["PatAge"].Value.ToString();
                txtPAddress.Text = PatientDGV.Rows[index].Cells["PatAddress"].Value.ToString();
                txtPhone.Text = PatientDGV.Rows[index].Cells["Phone"].Value.ToString();
                txtPEmail.Text = PatientDGV.Rows[index].Cells["PatEmail"].Value.ToString();
                
            }


        }

        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.TextLength != 0)
            {
                PatientDGV.DataSource = obj.Patient_Search(textBox1.Text);
            }
            else
            {
                PatientDGV.DataSource = obj.Patient_load();
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DIG_INF_Click(object sender, EventArgs e)
        {
            DIAGNOSIS dIAGNOSIS = new DIAGNOSIS();
            dIAGNOSIS.Show();
            this.Hide();
        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            TREATMENTS_FORM tREATMENTS_FORM = new TREATMENTS_FORM();
            tREATMENTS_FORM.Show();
            this.Hide();
        }

        private void PAT_REG_Click(object sender, EventArgs e)
        {

        }
    }
}
