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
using Guna.UI.WinForms;

namespace CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
        CHCMS_CLASS obj = new CHCMS_CLASS();

        bool register(string username, string password,string code)
        {
            int n = CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.passcodes.Count;

            for(int i = 0; i < n;i++)
            {
                if (CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.passcodes[i] == code)
                {
                    if (CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.passcodeState[i]=="unused")
                    {
                        
                        // MessageBox.Show("You have been registered as an admin");
                        if (obj.login(username, password, "ADMIN").Rows.Count == 0)
                        {
                            obj.Login_Insert(username, password, "ADMIN");
                            return true;

                        }
                        else
                        {
                           return false;
                        }
                    }
                  
                    return false;
                    
                }
            }
            return false;
        }


        bool login(string username, string password,string category) {
            /*int n = CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.users.Count;
            for (int i = 0; i < n; i++)
            {
                if (CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.users[i]==username && CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.passwords[i]==password && CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.category[i]==category)
                {
                    CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.Logger = username;
                    CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.Save();
                    return true;
                }
            }*/

            if(obj.login(username,password,category).Rows.Count==1) 
                return true;

            return false;
        
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
        private void gunaButton1_Click(object sender, EventArgs e)
        {

           if (gunaComboBox1.Text == "DOCTOR/NURSE")
            {
                if(txtPwd.TextLength >0 && txtLogin.TextLength > 0)
                {
                    if(login(txtLogin.Text, txtPwd.Text, gunaComboBox1.Text))
                    {

                        DASHBOARD f = new DASHBOARD();
                        f.docId= txtLogin.Text;
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong details", "Login Failed");
                    }
                }
                else
                {
                    MessageBox.Show("User ID & Password cannot be empty", "Login Failed");
                }


            }
           else if (gunaComboBox1.Text == "ADMIN")
            {
                if (txtPwd.TextLength > 0 && txtLogin.TextLength > 0)
                {
                    if (login(txtLogin.Text, txtPwd.Text, gunaComboBox1.Text))
                    {

                        ADMIN_DASHBOARD f = new ADMIN_DASHBOARD();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong details", "Login Failed");
                    }
                }
                else
                {
                    MessageBox.Show("User ID & Password cannot be empty", "Login Failed");
                }
            }
            else
            {
                MessageBox.Show("Select user type", "Login Failed");
            }

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            obj.Patient_load();
            CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.passwords = new System.Collections.Specialized.StringCollection();
            CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.category = new System.Collections.Specialized.StringCollection();
            CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_.Properties.Settings.Default.users = new System.Collections.Specialized.StringCollection(); 
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            errorProvider2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

          
            


        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {
            panelRegister.Dock = DockStyle.Fill;
            panelRegister.Visible = true;
            panelLogin.Visible = false;
            panelLogin.Dock = DockStyle.None;
            foreach (Control s in panelLogin.Controls)
            {
                if (s is GunaTextBox)
                {
                    s.Text = string.Empty;
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            panelRegister.Dock = DockStyle.None;
            panelRegister.Visible= false;
            panelLogin.Visible = true;
            panelLogin.Dock= DockStyle.Fill;
            foreach(Control s in panelRegister.Controls)
            {
                if(s is GunaTextBox)
                {
                    s.Text= string.Empty;
                }
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if(gunaTextBox1.TextLength>0 && gunaTextBox2.TextLength > 0 && gunaTextBox3.TextLength > 0 && gunaTextBox4.TextLength > 0)
            {
                if(gunaTextBox3.Text == gunaTextBox4.Text)
                {
                    if(register(gunaTextBox2.Text, gunaTextBox4.Text, gunaTextBox1.Text))
                    {
                        MessageBox.Show("You have been successfully registered as an admin","Admin Registration");
                        panelRegister.Dock = DockStyle.None;
                        panelRegister.Visible = false;
                        panelLogin.Visible = true;
                        panelLogin.Dock = DockStyle.Fill;
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
                        MessageBox.Show("Failed to register, passcode not recognised", "Admin Registration");
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do not match");
                }

            }
            else
            {
                MessageBox.Show("Null values cannot be accepted","Empty Field(s)");
            }
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
