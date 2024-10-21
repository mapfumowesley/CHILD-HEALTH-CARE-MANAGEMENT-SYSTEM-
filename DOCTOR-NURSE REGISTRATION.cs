using Bunifu.Framework.UI;
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
    public partial class DOCTOR_NURSE_REGISTRATION : Form
    {
        public void Clear()
        {
            foreach (Control c in this.Controls)
            {
                if (c is BunifuMaterialTextbox || c is RichTextBox)
                {
                    ((BunifuMaterialTextbox)c).Text = string.Empty;

                }
            }
        }
        public DOCTOR_NURSE_REGISTRATION()
        {
            InitializeComponent();
        }
        CHCMS_CLASS obj = new CHCMS_CLASS();
        public int Id;
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DNDGV.DataSource = obj.Doctors_Delete(Id);
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            string Gender;

            if (DNMbtn.Checked == true)
            {
                Gender = DNMbtn.Text;
            }
            else
            {
                Gender = DNFbtn.Text;
            }
            DNDGV.DataSource = obj.Doctors_Insert(Convert.ToInt32(txtDNID.Text),txtDNName.Text,txtDNMName.Text,txtDNLName.Text,txtDNAddress.Text,txtDNEmail.Text,txtDNPhone.Text,Gender,cbCategory.Text,txtPass.Text);

            Clear();   
        }

        private void DOCTOR_NURSE_REGISTRATION_Load(object sender, EventArgs e)
        {
            DNDGV.DataSource = obj.Doctors_load();
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                DNDGV.DataSource = obj.Doctors_Search(textBox1.Text);
            }
            else
            {
                DNDGV.DataSource = obj.Doctors_load();
            }
        }

        private void DNDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DNDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                Id = Convert.ToInt32(DNDGV.Rows[index].Cells[0].Value.ToString());
                txtDNName.Text = DNDGV.Rows[index].Cells["FName"].Value.ToString();
                txtDNMName.Text = DNDGV.Rows[index].Cells["MName"].Value.ToString();
                txtDNLName.Text = DNDGV.Rows[index].Cells["LName"].Value.ToString();
                txtDNAddress.Text = DNDGV.Rows[index].Cells["Address"].Value.ToString();
                txtDNEmail.Text = DNDGV.Rows[index].Cells["Email"].Value.ToString();
                txtDNPhone.Text = DNDGV.Rows[index].Cells["Phone"].Value.ToString();
                DNFbtn.Text = DNDGV.Rows[index].Cells["GENDER"].Value.ToString();
                DNMbtn.Text = DNDGV.Rows[index].Cells["GENDER"].Value.ToString();
                cbCategory.Text = DNDGV.Rows[index].Cells["CATEGORY"].Value.ToString();
                txtPass.Text = DNDGV.Rows[index].Cells["PASSWORD"].Value.ToString();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            string Gender;

            if (DNMbtn.Checked == true)
            {
                Gender = DNMbtn.Text;
            }
            else
            {
                Gender = DNFbtn.Text;
            }
            DNDGV.DataSource = obj.Doctors_Update(Id, txtDNName.Text, txtDNMName.Text, txtDNLName.Text, txtDNAddress.Text, txtDNEmail.Text, txtDNPhone.Text, Gender, cbCategory.Text, txtPass.Text);
            Clear();

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            ADMIN_DASHBOARD f = new ADMIN_DASHBOARD();
            f.Show();
            this.Hide();
        }

        private void bunifuCustomLabel12_Click(object sender, EventArgs e)
        {

        }

        private void PAT_INF_Click(object sender, EventArgs e)
        {

        }

        private void DIG_INF_Click(object sender, EventArgs e)
        {

        }

        private void PAT_REG_Click(object sender, EventArgs e)
        {

        }
    }
}
