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
    public partial class Form5 : Form
    {
        Form1 fr;
        public Form5(int patid, Form1 a)
        {
            InitializeComponent();
            idToolStripTextBox1.Text = Convert.ToString(patid);
            fr = a;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Doctor". При необходимости она может быть перемещена или удалена.
            this.doctorTableAdapter.Fill(this.hospital_BDDataSet.Doctor);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Appointment". При необходимости она может быть перемещена или удалена.
            this.appointmentTableAdapter.Fill(this.hospital_BDDataSet.Appointment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Patient". При необходимости она может быть перемещена или удалена.
            this.patientTableAdapter.Fill(this.hospital_BDDataSet.Patient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Doc_View_for_Pat". При необходимости она может быть перемещена или удалена.
            this.doc_View_for_PatTableAdapter.Fill(this.hospital_BDDataSet.Doc_View_for_Pat);
            try
            {
                this.patTableAdapter.Fill(this.hospital_BDDataSet.Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            try
            {
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fr.Visible = true;
            Random rnd = new Random();
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Input_App @Номер_кабинета, @Дата, @Время_приёма, @Pat_id, @Doc_id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Номер_кабинета", rnd.Next(1, 500));
                command.Parameters.AddWithValue("Дата", dateTimePicker1.Value);
                command.Parameters.AddWithValue("Время_приёма", dateTimePicker2.Value);
                command.Parameters.AddWithValue("Pat_id", Convert.ToInt32(idToolStripTextBox1.Text));
                command.Parameters.AddWithValue("Doc_id", Convert.ToInt32(comboBox1.SelectedValue));
                command.ExecuteNonQuery();

            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            try
            {
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Delete_App @App_Id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("App_Id", Convert.ToInt32(comboBox2.SelectedValue));
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            try
            {
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.patTableAdapter.Fill(this.hospital_BDDataSet.Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void doc_View_for_PatDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.patTableAdapter.Fill(this.hospital_BDDataSet.Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Update_Pat @App_Id, @tel;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("App_Id", Convert.ToInt32(idToolStripTextBox1.Text));
                command.Parameters.AddWithValue("tel", textBox1.Text);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            try
            {
                this.patTableAdapter.Fill(this.hospital_BDDataSet.Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            try
            {
                this.patTableAdapter.Fill(this.hospital_BDDataSet.Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.doc_View_for_PatTableAdapter.Fill(this.hospital_BDDataSet.Doc_View_for_Pat);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void app_PatDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
