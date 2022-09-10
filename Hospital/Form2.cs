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
    public partial class Form2 : Form
    {
        public Form2(int patid)
        {
            InitializeComponent();
            idToolStripTextBox.Text =Convert.ToString(patid);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Appointment". При необходимости она может быть перемещена или удалена.
            this.appointmentTableAdapter.Fill(this.hospital_BDDataSet.Appointment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Doctor". При необходимости она может быть перемещена или удалена.
            this.doctorTableAdapter.Fill(this.hospital_BDDataSet.Doctor);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospital_BDDataSet.Doc_View_for_Pat". При необходимости она может быть перемещена или удалена.
            this.doc_View_for_PatTableAdapter.Fill(this.hospital_BDDataSet.Doc_View_for_Pat);


        }

        private void patientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd= new Random();
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Input_App @Номер_кабинета, @Дата, @Время_приёма, @Pat_id, @Doc_id;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Номер_кабинета", rnd.Next(1, 500) );
                command.Parameters.AddWithValue("Дата", dateTimePicker1.Value);
                command.Parameters.AddWithValue("Время_приёма", dateTimePicker2.Value);
                command.Parameters.AddWithValue("Pat_id", Convert.ToInt32(idToolStripTextBox.Text));
                command.Parameters.AddWithValue("Doc_id", Convert.ToInt32(comboBox1.SelectedValue));
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            try
            {
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void app_for_PatDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void doc_View_for_PatDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void app_for_PatDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void fillToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
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
                this.app_PatTableAdapter.Fill(this.hospital_BDDataSet.App_Pat, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void doc_View_for_PatDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
