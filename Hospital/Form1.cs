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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void doctorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.doctorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospital_BDDataSet);

        }

        private void doctorBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.doctorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospital_BDDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void doctorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void doc_View_for_PatDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "exec Input_Pat @Фамилия, @Имя, @Отчество, @Пол, @Дата_рождения, @Телефон;";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Фамилия", textBox1.Text);
                command.Parameters.AddWithValue("Имя", textBox2.Text);
                command.Parameters.AddWithValue("Отчество", textBox3.Text);
                command.Parameters.AddWithValue("Пол", comboBox1.Text);
                command.Parameters.AddWithValue("Дата_рождения", dateTimePicker1.Value);        
                command.Parameters.AddWithValue("Телефон", textBox4.Text);
                command.ExecuteNonQuery();

                string sql1= "Select top 1 Pat_id from Patient order by Pat_id DESC";
                SqlCommand command1 = new SqlCommand(sql1, connect);
                int id=(int)command1.ExecuteScalar();
                Form5 newForm = new Form5(id, this);
                newForm.Show();
                this.Hide();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool flag = false ;
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "Select dbo.Check_Pat(@Patid)";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Patid", textBox5.Text);
                command.ExecuteNonQuery();
                flag = (bool)command.ExecuteScalar();
                if (flag == false) throw new Exception("Такого пациента не существует");
                this.Hide();
                Form5 newForm = new Form5(Convert.ToInt32(textBox5.Text), this);
                newForm.Show();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка! {ex.Message}"); }
            connect.Close();
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "Select dbo.Check_Doc(@Docid)";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Docid", textBox6.Text);
                command.ExecuteNonQuery();
                flag = (bool)command.ExecuteScalar();
                if (flag == false) throw new Exception("Врача с таким id не существует");
                this.Hide();
                Form3 newForm = new Form3(Convert.ToInt32(textBox6.Text));
                newForm.Show();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка! {ex.Message}"); }
            connect.Close();

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text == "0000")
                {
                    Form4 newForm = new Form4();
                    newForm.Show();
                    this.Hide();
                }
                else throw new Exception("Пароль неверный");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка! {ex.Message}");
            }
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
