using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.PrivInf". При необходимости она может быть перемещена или удалена.
            this.privInfTableAdapter.Fill(this.hospital_BDDataSet.PrivInf);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Sch_Doc_View". При необходимости она может быть перемещена или удалена.
            this.sch_Doc_ViewTableAdapter.Fill(this.hospital_BDDataSet.Sch_Doc_View);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Appointment". При необходимости она может быть перемещена или удалена.
            this.appointmentTableAdapter.Fill(this.hospital_BDDataSet.Appointment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.DocInfo". При необходимости она может быть перемещена или удалена.
            this.docInfoTableAdapter.Fill(this.hospital_BDDataSet.DocInfo);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Doc_Info". При необходимости она может быть перемещена или удалена.
            this.doc_InfoTableAdapter.Fill(this.hospital_BDDataSet.Doc_Info);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Pat_Info". При необходимости она может быть перемещена или удалена.
            this.pat_InfoTableAdapter.Fill(this.hospital_BDDataSet.Pat_Info);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Doctor". При необходимости она может быть перемещена или удалена.
            this.doctorTableAdapter.Fill(this.hospital_BDDataSet.Doctor);
            this.patientTableAdapter.Fill(this.hospital_BDDataSet.Patient);
        }
    



        private void patientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospital_BDDataSet);

        }

        private void patientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void patientDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.patientTableAdapter.Fill(this.hospital_BDDataSet.Patient);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Delete_Pat @Id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", comboBox1.SelectedValue);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            this.patientTableAdapter.Fill(this.hospital_BDDataSet.Patient);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Input_Pat @Фамилия, @Имя, @Отчество, @Пол, @Дата_рождения, @Телефон;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Фамилия", textBox1.Text);
                command.Parameters.AddWithValue("Имя", textBox2.Text);
                command.Parameters.AddWithValue("Отчество", textBox3.Text);
                command.Parameters.AddWithValue("Пол", textBox4.Text);
                command.Parameters.AddWithValue("Дата_рождения", dateTimePicker1.Value);
                command.Parameters.AddWithValue("Телефон", textBox5.Text);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            this.patientTableAdapter.Fill(this.hospital_BDDataSet.Patient);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.doctorTableAdapter.Fill(this.hospital_BDDataSet.Doctor);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Delete_Doc @Id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", comboBox2.SelectedValue);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            this.doctorTableAdapter.Fill(this.hospital_BDDataSet.Doctor);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Input_Doc @Фамилия, @Имя, @Отчество, @Специальность;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Фамилия", textBox10.Text);
                command.Parameters.AddWithValue("Имя", textBox9.Text);
                command.Parameters.AddWithValue("Отчество", textBox8.Text);
                command.Parameters.AddWithValue("Специальность", textBox7.Text);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            this.doctorTableAdapter.Fill(this.hospital_BDDataSet.Doctor);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Update_Doc @Id, @Spec;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", comboBox3.SelectedValue);
                command.Parameters.AddWithValue("Spec", textBox6.Text);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            this.doctorTableAdapter.Fill(this.hospital_BDDataSet.Doctor);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.doc_InfoTableAdapter.Fill(this.hospital_BDDataSet.Doc_Info);
            this.pat_InfoTableAdapter.Fill(this.hospital_BDDataSet.Pat_Info);
            this.docInfoTableAdapter.Fill(this.hospital_BDDataSet.DocInfo);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.sch_Doc_ViewTableAdapter.Fill(this.hospital_BDDataSet.Sch_Doc_View);
            this.appointmentTableAdapter.Fill(this.hospital_BDDataSet.Appointment);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Delete_App @Id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", comboBox4.SelectedValue);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();
            this.sch_Doc_ViewTableAdapter.Fill(this.hospital_BDDataSet.Sch_Doc_View);
            this.appointmentTableAdapter.Fill(this.hospital_BDDataSet.Appointment);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Input_App @Номер_кабинета, @Дата, @Время_приёма, @Pat_id, @Doc_id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Номер_кабинета", Convert.ToInt32(textBox15.Text));
                command.Parameters.AddWithValue("Дата", dateTimePicker3.Value);
                command.Parameters.AddWithValue("Время_приёма", dateTimePicker4.Value);
                command.Parameters.AddWithValue("Pat_id", comboBox5.SelectedValue);
                command.Parameters.AddWithValue("Doc_id", comboBox6.SelectedValue);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();
            this.sch_Doc_ViewTableAdapter.Fill(this.hospital_BDDataSet.Sch_Doc_View);
            this.appointmentTableAdapter.Fill(this.hospital_BDDataSet.Appointment);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.privInfTableAdapter.Fill(this.hospital_BDDataSet.PrivInf);
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Delete_PrivInf @Id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", comboBox7.SelectedValue);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();
            this.privInfTableAdapter.Fill(this.hospital_BDDataSet.PrivInf);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Delete_PrivInf @Id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", comboBox8.SelectedValue);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();
            this.privInfTableAdapter.Fill(this.hospital_BDDataSet.PrivInf);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Update_PrivInf @Id, @Diag, @Pay;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", comboBox7.SelectedValue);
                command.Parameters.AddWithValue("Diag", textBox12.Text);
                command.Parameters.AddWithValue("Pay", Convert.ToInt32(textBox11.Text));
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();
            this.privInfTableAdapter.Fill(this.hospital_BDDataSet.PrivInf);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Input_PrivInf @Id, @Diag, @Pay;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", Convert.ToInt32(textBox16.Text));
                command.Parameters.AddWithValue("Diag", textBox14.Text);
                command.Parameters.AddWithValue("Pay", Convert.ToInt32(textBox13.Text));
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();
            this.privInfTableAdapter.Fill(this.hospital_BDDataSet.PrivInf);
        }
    }
}
