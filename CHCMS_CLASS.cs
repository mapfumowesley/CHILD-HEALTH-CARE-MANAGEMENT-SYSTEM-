using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using System.Drawing;



namespace CHILD_HEALTH_CARE_MANAGEMENT_SYSTEM_
{
    internal class CHCMS_CLASS:Form
    {
        
        
        SqlConnection con = new SqlConnection(Properties.Settings.Default.chcmsConnectionString);
        SqlCommand cmd = new SqlCommand();
        
        public DataTable Diagnosis_load()
        {
           
            SqlCommand cmd = new SqlCommand("Select * from DiagnosisTbl", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Diagnosis_load_HIV()
        {

            SqlCommand cmd = new SqlCommand("Select * from DiagnosisTbl where [HIV STATUS]='POSITIVE'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }


        public DataTable Diagnosis_Check_HIV_Status(string pid)
        {

            SqlCommand cmd = new SqlCommand("Select * from DiagnosisTbl where [HIV STATUS] like 'POSITIVE' and [PATIENT ID]= '" + pid + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }





        // Insert into Diagnosis
        public DataTable Diagnosis_Insert(string PatId, string symptoms, string test, string prescription, string results, string Doctor,string HIV)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DiagnosisTbl VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", con);
            //(EmployeeId,EmployeeNumber,[Title],Fisrt_Name,Other_Initials,[Surname],[Nationality],Birth_Place,[Town],[Address],[Mobile_Number],Home_Number,WorkPlace_Number,[EmailAddress],[Status],[Date_Started],[DOB],Marital_Status,[Department],[Position],[Salary],[Leave_Balance])
            cmd.Parameters.AddWithValue("@p1", PatId);
            cmd.Parameters.AddWithValue("@p2", symptoms);
            cmd.Parameters.AddWithValue("@p3", test);
            cmd.Parameters.AddWithValue("@p4", prescription);
            cmd.Parameters.AddWithValue("@p5", results);
            cmd.Parameters.AddWithValue("@p6", Doctor);
            cmd.Parameters.AddWithValue("@p7", HIV);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();


            return Diagnosis_load();

        }

        // Update Diagnosis
        public DataTable Diagnosis_Update(int RECORD_ID,string PatId, string symptoms, string test, string prescription, string results,string hiv)
        {
            SqlCommand cmd = new SqlCommand("Update DiagnosisTbl set [PATIENT ID]='" +PatId + "',SYMPTOMS='" +symptoms + "', TEST='" + test + "',  PRESCRIPTION='" + prescription + "', RESULTS='" + results + "', [HIV STATUS]='" + hiv + "' where [RECORD ID]= '" + RECORD_ID + "'", con);
          
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return Diagnosis_load();

        }

        // Delete from employees
        public DataTable Diagnosis_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from DiagnosisTbl where [RECORD ID]='" + Id + "'", con);
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return Diagnosis_load();

        }

        public DataTable Diagnosis_Search(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select * from DiagnosisTbl where [PATIENT ID] like'%" + PatId + "%'", con);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

           

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }


        public DataTable Patient_load()
        {

            SqlCommand cmd = new SqlCommand("Select * from PatientTbl", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            

            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }





        // Insert into Patient
        public DataTable Patient_Insert(string FName, string MName, string LName, DateTime DOB, DateTime RegDate, string PatAdress, string Phone, string PatEmail, string BG,string Gender, string PatAllergic, string PatChronic)
        {
            int n = Patient_load().Rows.Count + 1000;
            string id = "P" + n.ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO PatientTbl VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p8,@p9,@p10,@p11,@p12,@p13,@p14)", con);

            cmd.Parameters.AddWithValue("@p1", id);
            cmd.Parameters.AddWithValue("@p2", FName);
            cmd.Parameters.AddWithValue("@p3", MName);
            cmd.Parameters.AddWithValue("@p4", LName);
            cmd.Parameters.AddWithValue("@p5", DOB);
            cmd.Parameters.AddWithValue("@p6", RegDate);
            
            cmd.Parameters.AddWithValue("@p8", PatAdress);
            cmd.Parameters.AddWithValue("@p9", Phone);
            cmd.Parameters.AddWithValue("@p10", PatEmail);
            cmd.Parameters.AddWithValue("@p11", BG);
            cmd.Parameters.AddWithValue("@p12", Gender);
            cmd.Parameters.AddWithValue("@p13", PatAllergic);
            cmd.Parameters.AddWithValue("@p14", PatChronic);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
              cmd.ExecuteNonQuery();
            con.Close();


            return Patient_load();

        }

        // Update Diagnosis
        public DataTable Patient_Update(int PatId, string FName, string MName, string LName, DateTime DOB, DateTime RegDate, string PatAdress, string Phone, string PatEmail, string BG, string Gender, string PatAllergic, string PatChronic)
        {
            SqlCommand cmd = new SqlCommand("Update PatientTbl set FName='" + FName + "', MName='" + MName + "',  LName='" + LName+ "', DOB='" + DOB + "', RegDate='" + RegDate + "', PatAddress='" + PatAdress + "', Phone='" + Phone + "', PatEmail='" + PatEmail + "', BG='" + BG + "', Gender='" + Gender + "', PatAllergic='" + PatAllergic + "',PatChronic='" + PatChronic + "' where [RECORD ID]='" + PatId + "'", con);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return Patient_load();

        }

        // Delete from Patients
        public DataTable Patient_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from PatientTbl where [RECORD ID]='" + Id + "'", con);
   
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return Patient_load();

        }

        public DataTable Patient_Search(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select * from PatientTbl where PatId like'%" + PatId + "%'", con);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Doctors_load()
        {

            SqlCommand cmd = new SqlCommand("Select * from DOCTORSTbl", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }





        // Insert into Doctors
        public DataTable Doctors_Insert(string DOC_ID, string FName, string MName, string LName, string Address, string Email, string Phone, string Gender, string Category, string Password)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DOCTORSTbl VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", con);
            cmd.Parameters.AddWithValue("@p1", DOC_ID);
            cmd.Parameters.AddWithValue("@p2", FName);
            cmd.Parameters.AddWithValue("@p3", MName);
            cmd.Parameters.AddWithValue("@p4", LName);
            cmd.Parameters.AddWithValue("@p5", Address);
            cmd.Parameters.AddWithValue("@p6", Email);
            cmd.Parameters.AddWithValue("@p7", Phone);
            cmd.Parameters.AddWithValue("@p8", Gender);
            cmd.Parameters.AddWithValue("@p9", Category);
            cmd.Parameters.AddWithValue("@p10", Password);


            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();


            return Doctors_load();

        }

        // Update DOCTORS
        public DataTable Doctors_Update(int ID, string PRACTIONER_ID, string FName, string MName, string LName, string Address, string Email, string Phone, string Gender, string Category, string Password)
        {
            SqlCommand cmd = new SqlCommand("Update DOCTORSTbl set [PRACTITIONER ID]='" + PRACTIONER_ID + "',FName='" + FName + "', MName='" + MName + "',  LName='" + LName + "', ADDRESS='" + Address + "', EMAIL='" + Email + "', Phone='" + Phone + "', Gender='" + Gender + "', CATEGORY='" + Category + "',PASSWORD='" + Password + "' where [RECORD ID]= '" + ID + "'", con);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();
            return Doctors_load();

        }

        // Delete from DOCTORS
        public DataTable Doctors_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from DOCTORSTbl where [RECORD ID]='" + Id + "'", con);
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return Doctors_load();

        }

        public DataTable Doctors_Search(string FDOC_ID)
        {

            SqlCommand cmd = new SqlCommand("select * from DoctorsTbl where [PRACTITIONER ID] like'%" + FDOC_ID + "%'", con);
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Doctors_Search_login(string FDOC_ID)
        {

            SqlCommand cmd = new SqlCommand("select * from DoctorsTbl where [PRACTITIONER ID]='" + FDOC_ID + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }
        public DataTable Treatments_load()
        {

            SqlCommand cmd = new SqlCommand("Select * from TREATMENTS", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Treatments_Insert(string PatId, string DISEASE ,string MEDICINE, string DOSAGE,string DOCTOR_OR_NURSE, DateTime DATE_ADMINISTERE)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TREATMENTS VALUES(@p2,@p3,@p4,@p5,@p6,@p7)", con);
            // cmd.Parameters.AddWithValue("@p1", ID);
            cmd.Parameters.AddWithValue("@p2", PatId);
            cmd.Parameters.AddWithValue("@p3", DISEASE);
            cmd.Parameters.AddWithValue("@p4", MEDICINE);
            cmd.Parameters.AddWithValue("@p5", DOSAGE);

            cmd.Parameters.AddWithValue("@p6", DOCTOR_OR_NURSE);
            cmd.Parameters.AddWithValue("@p7", DATE_ADMINISTERE);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();


            return Treatments_load();

        }
        public DataTable Treatments_Update(int Id,string PID,string DISEASE, string MEDICINE, string DOSAGE)
        {
            SqlCommand cmd = new SqlCommand("Update TREATMENTS set [PATIENT ID]='" + PID + "', DISEASE='" + DISEASE + "',MEDICINE='" + MEDICINE + "', DOSAGE='" + DOSAGE + "' where [TREATMENT ID]= '" + Id + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();
            return Treatments_load();

        }

        public DataTable Treatments_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from TREATMENTS where [TREATMENT ID]='" + Id + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return Treatments_load();

        }
        public DataTable Treatments_Search(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select * from TREATMENTS where [PATIENT ID] like'%" + PatId + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }



        public DataTable Immunisation_load()
        {

            SqlCommand cmd = new SqlCommand("Select * from IMMUNISATION", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Immunisation_Insert(string PatId, string VACCINE, string DOSE_NUM, string BATCH_NO, DateTime DateOfVaccine, string doctor_or_nurse_id)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO IMMUNISATION VALUES(@p1,@p2,@p3,@p4,@p5,@p6)", con);
            cmd.Parameters.AddWithValue("@p1", PatId);
            cmd.Parameters.AddWithValue("@p2", VACCINE );
            cmd.Parameters.AddWithValue("@p3", DOSE_NUM);
            cmd.Parameters.AddWithValue("@p4", BATCH_NO);
            cmd.Parameters.AddWithValue("@p5", DateOfVaccine);
            cmd.Parameters.AddWithValue("@p6", doctor_or_nurse_id);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();


            return Immunisation_load();

        }
        public DataTable Immunisation_Update(int Id, string VACCINE, string DOSE_NUM, string BATCH_NO)
        {
            SqlCommand cmd = new SqlCommand("Update IMMUNISATION set VACCINE='" + VACCINE + "',[DOSE NUMBER]='" + DOSE_NUM + "', [BATCH NUMBER]='" + BATCH_NO + "' where [RECORD ID]= '" + Id + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();
            return Immunisation_load();

        }

        public DataTable Immunisation_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from IMMUNISATION where [RECORD ID]='" + Id + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return Immunisation_load();

        }
        public DataTable Immunisation_Search(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select * from IMMUNISATION where [PATIENT ID] like'%" + PatId + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Immunisation_Track_Search(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select * from IMMUNISATION where [PATIENT ID] like'%" + PatId + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Immunisation_Track_Search_For_Grid(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select DISTINCT [PATIENT ID] from IMMUNISATION where [PATIENT ID] like'%" + PatId + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }


        // Monthly checkups

        public DataTable GrowthTable_Load()
        {

            SqlCommand cmd = new SqlCommand("select * from [GROWTH TABLE]", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable GrowthTable_Insert(string PatId, int MONTH, float HEIGHT, float weight, float temp, string bp)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [GROWTH TABLE] VALUES(@p2,@p3,@p4,@p5,@p6,@p7)", con);
             cmd.Parameters.AddWithValue("@p2", PatId);
            cmd.Parameters.AddWithValue("@p3", MONTH);
            cmd.Parameters.AddWithValue("@p4", weight);
            cmd.Parameters.AddWithValue("@p5", HEIGHT);
            cmd.Parameters.AddWithValue("@p6", temp);

            cmd.Parameters.AddWithValue("@p7", bp);
            


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return GrowthTable_Load();
          

        }

        public DataTable GrowthTable_Update(int RecordID,string PatId, int MONTH, float HEIGHT, float weight, float temp, string bp)
        {
            SqlCommand cmd = new SqlCommand("Update [GROWTH TABLE] set [PATIENT ID]='" + PatId + "',MONTHS='" + MONTH + "', WEIGHT='" + weight + "', HEIGHT='" + HEIGHT + "', TEMPERATURE='" + temp + "', [BLOOD PRESSURE]='" + bp + "' where [RECORD ID]= '" + RecordID + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return GrowthTable_Load();


        }

        public DataTable GrowthTable_Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from [GROWTH TABLE] where [RECORD ID]='" + Id + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

            return GrowthTable_Load();

        }

        public DataTable GrowthTable_Height_Select(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select MONTHS,HEIGHT from [GROWTH TABLE] where [PATIENT ID]='" + PatId + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable GrowthTable_Weight_Select(string PatId)
        {

            SqlCommand cmd = new SqlCommand("select MONTHS,WEIGHT from [GROWTH TABLE] where [PATIENT ID]='" + PatId + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }



        public void Appointments_Insert(string DOC,string PatId, DateTime date, string time, string reason, string status)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO APPOINTMENTS VALUES(@p2,@p3,@p4,@p5,@p6,@p7)", con);
            cmd.Parameters.AddWithValue("@p2", DOC);
            cmd.Parameters.AddWithValue("@p3", PatId);
            cmd.Parameters.AddWithValue("@p4", date);
            cmd.Parameters.AddWithValue("@p5", time);
            cmd.Parameters.AddWithValue("@p6", reason);

            cmd.Parameters.AddWithValue("@p7", status);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();




        }


        public DataTable Appointments_Search_All(string DOC,string Status)
        {

            SqlCommand cmd = new SqlCommand("select * from APPOINTMENTS where [DOCTOR/NURSE]='" + DOC + "' AND STATUS LIKE '%" + Status + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Appointments_Search_Today(string DOC, string Status, DateTime date)
        {

            SqlCommand cmd = new SqlCommand("select * from APPOINTMENTS where [DOCTOR/NURSE]='" + DOC + "' AND [DATE FOR APPOINTMENT]='" + date + "' AND STATUS LIKE '%" + Status + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }


        public DataTable Appointments_Admin_Search_All( string Status)
        {

            SqlCommand cmd = new SqlCommand("select * from APPOINTMENTS where STATUS LIKE '%" + Status + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public DataTable Appointments_Admin_Search_Today(string Status, DateTime date)
        {

            SqlCommand cmd = new SqlCommand("select * from APPOINTMENTS where [DATE FOR APPOINTMENT]='" + date + "' AND STATUS LIKE '%" + Status + "%'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

        public void Login_Insert(string id, string password,  string category)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Login VALUES(@p2,@p3,@p4)", con);
            cmd.Parameters.AddWithValue("@p2", id);
            cmd.Parameters.AddWithValue("@p3", password);
            cmd.Parameters.AddWithValue("@p4", category);
          


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Login_Update(string id, string newId, string password)
        {
            SqlCommand cmd = new SqlCommand("Update Login set PASSWORD='"+password +"',ID='"+newId +"' WHERE ID='"+ id +"'", con);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Login_Delete(string id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Login WHERE ID='" + id + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable login(string username, string password,string category)
        {

            SqlCommand cmd = new SqlCommand("select * from Login where ID='" + username + "' AND PASSWORD='" + password + "' AND CATEGORY='" + category + "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();



            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;

        }

















        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CHCMS_CLASS
            // 
            this.ClientSize = new System.Drawing.Size(1118, 570);
            this.Name = "CHCMS_CLASS";
            this.Load += new System.EventHandler(this.CHCMS_CLASS_Load);
            this.ResumeLayout(false);

        }

        private void CHCMS_CLASS_Load(object sender, EventArgs e)
        {
           

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
