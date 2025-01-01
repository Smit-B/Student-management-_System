using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_System
{
    public partial class PrintStudentsForm : Form
    {
        public PrintStudentsForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();

        private void PrintStudentsForm_Load(object sender, EventArgs e)
        {
            fillGird(new SqlCommand("select * from students"));

            if (radioButtonNo.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        public void fillGird(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);

            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string query;

            if (radioButtonYes.Checked)
            {
                string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                if (radioButtonMale.Checked)
                {
                    query = "select * from students where birthdate BETWEEN '" + date1 + "' and '" + date2 + "' and gender='Male'";
                }
                else if (radioButtonFemale.Checked)
                {
                    query = "select * from students where birthdate BETWEEN '" + date1 + "' and '" + date2 + "' and gender='Female'";
                }
                else
                {
                    query = "select * from students where birthdate BETWEEN '" + date1 + "' and '" + date2 + "'";
                }

                command = new SqlCommand(query);
                fillGird(command);
            }
            else
            {
                if (radioButtonMale.Checked)
                {
                    query = "select * from students where gender='Male'";
                }
                else if (radioButtonFemale.Checked)
                {
                    query = "select * from students where gender='Female'";
                }
                else
                {
                    query = "select * from students";
                }

                command = new SqlCommand(query);
                fillGird(command);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\students-list.txt";

            using (var writer = new StreamWriter(path))
            {
                DateTime bdate;

                // Define fixed column widths
                int col1Width = 5;
                int col2Width = 15;
                int col3Width = 15;
                int col4Width = 15;
                int col5Width = 15;
                int col6Width = 15;
                int col7Width = 15;

                // Loop through rows
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    writer.Write(CenterText(dataGridView1.Rows[i].Cells[0].Value.ToString(), col1Width));
                    writer.Write("| " + CenterText(dataGridView1.Rows[i].Cells[1].Value.ToString(), col2Width));
                    writer.Write("| " + CenterText(dataGridView1.Rows[i].Cells[2].Value.ToString(), col3Width));

                    // Format the birthdate
                    bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);
                    writer.Write("| " + CenterText(bdate.ToString("yyyy-MM-dd"), col4Width));

                    writer.Write("| " + CenterText(dataGridView1.Rows[i].Cells[4].Value.ToString(), col5Width));
                    writer.Write("| " + CenterText(dataGridView1.Rows[i].Cells[5].Value.ToString(), col6Width));
                    writer.Write("| " + CenterText(dataGridView1.Rows[i].Cells[6].Value.ToString(), col7Width));

                    writer.WriteLine("");
                    writer.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                }

                writer.Close();
                MessageBox.Show("Data Exported");
            }
        }

        private string CenterText(string text, int width)
        {
            // If the text is empty or null, return a space-filled string
            if (string.IsNullOrEmpty(text)) return new string(' ', width);

            int paddingLeft = (width - text.Length) / 2;
            int paddingRight = width - text.Length - paddingLeft;

            return new string(' ', paddingLeft) + text + new string(' ', paddingRight);
        }
    }
}
