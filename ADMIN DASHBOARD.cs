using Bunifu.Framework.UI;
using Guna.UI.WinForms;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_
{
    public partial class ADMIN_DASHBOARD : Form
    {
       
        public ADMIN_DASHBOARD()
        {
            InitializeComponent();
        }


        DASHBOARD ds= new DASHBOARD();
        CHCMS_CLASS obj = new CHCMS_CLASS();
        public int Id;
        public string docID;

        public void Count()
        {
            Label1.Text = obj.Patient_load().Rows.Count.ToString();
            Label2.Text = obj.Doctors_load().Rows.Count.ToString();
            Label3.Text = obj.Diagnosis_load_HIV().Rows.Count.ToString();
            lblFullfilled.Text = obj.Appointments_Admin_Search_All("Fullfilled").Rows.Count.ToString();
            lblPending.Text = obj.Appointments_Admin_Search_All("Pending").Rows.Count.ToString();
            lblMissed.Text = obj.Appointments_Admin_Search_All("Missed").Rows.Count.ToString();

        }

            public void Clear()
        {
            foreach (Control c in this.Controls)
            {
                if (c is BunifuMaterialTextbox || c is RichTextBox)
                {
                    //c.Text= string.Empty;
                    ((BunifuMaterialTextbox)c).Text = string.Empty;

                }
                if (c is RichTextBox)
                {
                    // ((RichTextBox)c).Text = string.Empty;

                }
            }
        }

        public void Save()
        {

        }
        private void visualShow()
        {
            Panel p = new Panel();
            p = ds.Visuals();
            tabPage7.Controls.Add (p);
            p.Visible = true;
            p.Dock= DockStyle.Fill;
            
        }

       

        private void PAT_INF_Click(object sender, EventArgs e)
        {
            
        }

        private void DIG_INF_Click(object sender, EventArgs e)
        {
            //DIAGNOSIS f = new DIAGNOSIS();
            //f.Show();
           // this.Hide();
          
        }

       

        
       

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {
            LOGIN f = new LOGIN();
            f.Show();   
            this.Hide();
        }

      
        private void bunifuThinButton29_Click(object sender, EventArgs e)
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
            string password = txtDNID.Text + "@chcms" + DateTime.Now.Year.ToString();
            DNDGV.DataSource = obj.Doctors_Insert(txtDNID.Text, txtDNName.Text, txtDNMName.Text, txtDNLName.Text, txtDNAddress.Text, txtDNEmail.Text, txtDNPhone.Text, Gender, cbCategory.Text,password);
            obj.Login_Insert(txtDNID.Text, password, "DOCTOR/NURSE");
            Clear();
            Count();
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
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
            string password = txtDNID.Text + "@chcms" + DateTime.Now.Year.ToString();
            
            DNDGV.DataSource = obj.Doctors_Update(Id, txtDNID.Text, txtDNName.Text, txtDNMName.Text, txtDNLName.Text, txtDNAddress.Text, txtDNEmail.Text, txtDNPhone.Text, Gender, cbCategory.Text, password);
            obj.Login_Update(docID,txtDNID.Text, password);
            Clear();
            Count();
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            try
            {
                DNDGV.DataSource = obj.Doctors_Delete(Id);
                obj.Login_Delete(docID);
                Clear();
            }
            catch { }
            Count();
        }

        private void DNDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                Id = Convert.ToInt32(DNDGV.Rows[index].Cells[0].Value.ToString());
                docID = DNDGV.Rows[index].Cells["PASSWORD"].Value.ToString();
                txtDNName.Text = DNDGV.Rows[index].Cells["FName"].Value.ToString();
                txtDNMName.Text = DNDGV.Rows[index].Cells["MName"].Value.ToString();
                txtDNLName.Text = DNDGV.Rows[index].Cells["LName"].Value.ToString();
                txtDNAddress.Text = DNDGV.Rows[index].Cells["Address"].Value.ToString();
                txtDNEmail.Text = DNDGV.Rows[index].Cells["Email"].Value.ToString();
                txtDNPhone.Text = DNDGV.Rows[index].Cells["Phone"].Value.ToString();
                DNFbtn.Text = DNDGV.Rows[index].Cells["GENDER"].Value.ToString();
                DNMbtn.Text = DNDGV.Rows[index].Cells["GENDER"].Value.ToString();
                cbCategory.Text = DNDGV.Rows[index].Cells["CATEGORY"].Value.ToString();
                 }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.TextLength != 0)
            {
                DNDGV.DataSource = obj.Doctors_Search(textBox3.Text);
            }
            else
            {
                DNDGV.DataSource = obj.Doctors_load();
            }
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                dataGridView1.DataSource = obj.Patient_load();
            }
            else
            {
                dataGridView1.DataSource = obj.Patient_Search(textBox1.Text);

            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                dataGridView1.DataSource = obj.Treatments_load();
            }
            else
            {
                dataGridView1.DataSource = obj.Treatments_Search(textBox1.Text);

            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                dataGridView1.DataSource = obj.Diagnosis_load();
            }
            else
            {
                dataGridView1.DataSource = obj.Diagnosis_Search(textBox1.Text);

            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                dataGridView1.DataSource = obj.Immunisation_load();
            }
            else
            {
                dataGridView1.DataSource = obj.Immunisation_Search(textBox1.Text);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = (int)e.RowIndex;
            if(Id >=0)
            {
                textBox1.Text= dataGridView1.Rows[Id].Cells[1].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {

                if (textBox1.Text.Length == 0)
                {
                    dataGridView1.DataSource = obj.Patient_load();
                }
                else
                {
                    dataGridView1.DataSource = obj.Patient_Search(textBox1.Text);

                }



            }
            else if(radioButton2.Checked==true)
            {
                if (textBox1.Text.Length == 0)
                {
                    dataGridView1.DataSource = obj.Treatments_load();
                }
                else
                {
                    dataGridView1.DataSource = obj.Treatments_Search(textBox1.Text);

                }

            }
            else if(radioButton3.Checked==true)
            {
                if (textBox1.Text.Length == 0)
                {
                    dataGridView1.DataSource = obj.Diagnosis_load();
                }
                else
                {
                    dataGridView1.DataSource = obj.Diagnosis_Search(textBox1.Text);

                }
            }
            else
            {
                if (textBox1.Text.Length == 0)
                {
                    dataGridView1.DataSource = obj.Immunisation_load();
                }
                else
                {
                    dataGridView1.DataSource = obj.Immunisation_Search(textBox1.Text);

                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void ADMIN_DASHBOARD_Load(object sender, EventArgs e)
        {
            visualShow();
            Count();
            Label1.Text = obj.Patient_load().Rows.Count.ToString();
            Label2.Text = obj.Doctors_load().Rows.Count.ToString();
            Label2.Text = obj.Diagnosis_load_HIV().Rows.Count.ToString();
            DNDGV.DataSource = obj.Doctors_load();

            dataGridView1.DataSource = obj.Patient_load();
            gridAppointments.DataSource = obj.Appointments_Admin_Search_All("Pending");


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtDNEmail_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void DNDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0)
            {
               DNDGV.DataSource = obj.Doctors_Search(textBox2.Text);

            }
            else
            {
                DNDGV.DataSource = obj.Doctors_load();

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if(textBox4.Text.Length > 0)
            {
                gridAppointments.DataSource = obj.Appointments_Search_All(textBox4.Text, comboBoxStatus.Text);
            }
            else
            {
                gridAppointments.DataSource = obj.Appointments_Admin_Search_All(comboBoxStatus.Text);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                gridAppointments.DataSource = obj.Appointments_Search_Today(textBox4.Text,comboBoxStatus.Text, DateTime.Now);
            }
            else
            {
                gridAppointments.DataSource = obj.Appointments_Admin_Search_Today(comboBoxStatus.Text, DateTime.Now);

            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                if (textBox4.Text.Length > 0)
                {
                    gridAppointments.DataSource = obj.Appointments_Search_All(textBox4.Text, comboBoxStatus.Text);
                }
                else
                {
                    gridAppointments.DataSource = obj.Appointments_Admin_Search_All(comboBoxStatus.Text);
                }
            }
            else
            {
                if (textBox4.Text.Length > 0)
                {
                    gridAppointments.DataSource = obj.Appointments_Search_Today(textBox4.Text, comboBoxStatus.Text, DateTime.Now);
                }
                else
                {
                    gridAppointments.DataSource = obj.Appointments_Admin_Search_Today(comboBoxStatus.Text, DateTime.Now);

                }
            }
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            LOGIN f = new LOGIN();
            this.Hide();
            f.Show();
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            tabPage4.Select();
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

            tabPage7.Select();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if(obj.login(gunaTextBox1.Text,gunaTextBox2.Text,"ADMIN").Rows.Count == 1)
            {
                if(gunaTextBox3.Text== gunaTextBox4.Text)
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

        private void gunaLabel1_Click(object sender, EventArgs e)
        {
            //panelRegister.Dock = DockStyle.None;
            panelRegister.Visible = true;
        }

        private void txtDNName_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtDNName.Text;
            string result = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
            }

            txtDNName.Text = result;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDNName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(txtDNName, "Invalid input. Only letters are allowed.");
                txtDNName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtDNName, "");
            }

        }

        private void txtDNMName_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtDNMName.Text;
            string result = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
            }

            txtDNMName.Text = result;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDNMName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(txtDNMName, "Invalid input. Only letters are allowed.");
                txtDNMName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtDNMName, "");
            }


        }

        private void txtDNLName_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtDNLName.Text;
            string result = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
            }

            txtDNLName.Text = result;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDNLName.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(txtDNLName, "Invalid input. Only letters are allowed.");
                txtDNLName.Focus();
            }
            else
            {
                errorProvider1.SetError(txtDNLName, "");
            }

        }

        private void txtDNPhone_OnValueChanged(object sender, EventArgs e)
        {
            string input = txtDNPhone.Text;

            // Check if the input starts with +263
            if (!input.StartsWith("+263"))
            {
                errorProvider1.SetError(txtDNPhone, "Phone number should start with +263.");
                txtDNPhone.Focus();
                return;
            }

            // Check if the input contains only numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[+0-9]+$"))
            {
                errorProvider1.SetError(txtDNPhone, "Invalid phone number. Only numbers are allowed.");
                txtDNPhone.Focus();
            }
            else
            {
                errorProvider1.SetError(txtDNPhone, "");
            }

        }
    }
    
}
