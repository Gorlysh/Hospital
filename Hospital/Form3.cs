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
    public partial class Form3 : Form
    {
        public Form3(int docid)
        {
            InitializeComponent();
            idToolStripTextBox.Text = Convert.ToString(docid);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            try
            {
                this.pat_ViewTableAdapter.Fill(this.hospital_BDDataSet.Pat_View, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            try
            {
                this.app_DocTableAdapter.Fill(this.hospital_BDDataSet.App_Doc, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            try
            {
                this.privateInfoTableAdapter.Fill(this.hospital_BDDataSet.PrivateInfo, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            try
            {
                this.docTableAdapter.Fill(this.hospital_BDDataSet.Doc, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void idToolStripTextBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.pat_ViewTableAdapter.Fill(this.hospital_BDDataSet.Pat_View, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
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
                this.app_DocTableAdapter.Fill(this.hospital_BDDataSet.App_Doc, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "Exec dbo.Update_App @AppId, @Дата";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("AppId", Convert.ToInt32(comboBox1.Text));
                command.Parameters.AddWithValue("Дата", dateTimePicker1.Value);
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            try
            {
                this.app_DocTableAdapter.FillBy(this.hospital_BDDataSet.App_Doc, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            try
            {
                this.app_DocTableAdapter.Fill(this.hospital_BDDataSet.App_Doc, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "Select * from dbo.PatFull (@PatId)";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("PatId", Convert.ToInt32(comboBox2.SelectedValue));
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }

            try
            {
                this.patFullTableAdapter.Fill(this.hospital_BDDataSet.PatFull, ((int)(System.Convert.ChangeType(comboBox2.SelectedValue, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            connect.Close();
        }
 

        private void patFullDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.privateInfoTableAdapter.Fill(this.hospital_BDDataSet.PrivateInfo, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.privateInfoTableAdapter.Fill(this.hospital_BDDataSet.PrivateInfo, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-NLC89LU\\SQLEXPRESS;Initial Catalog=Hospital_BD;Integrated Security=True"); connect.Open();
            string sql = "Exec dbo.Update_PrivInf @Id, @Диагноз, @Стоимость";

            SqlCommand command = new SqlCommand(sql, connect);
            try
            {
                command.Parameters.AddWithValue("Id", Convert.ToInt32(comboBox3.SelectedValue));
                command.Parameters.AddWithValue("Диагноз", textBox1.Text);
                command.Parameters.AddWithValue("Стоимость", Convert.ToInt32(textBox2.Text));
                command.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Ошибка!"); }
            connect.Close();

            try
            {
                this.privateInfoTableAdapter.Fill(this.hospital_BDDataSet.PrivateInfo, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.app_DocTableAdapter.FillBy1(this.hospital_BDDataSet.App_Doc, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void app_DocDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.docTableAdapter.Fill(this.hospital_BDDataSet.Doc, ((int)(System.Convert.ChangeType(idToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void docDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
