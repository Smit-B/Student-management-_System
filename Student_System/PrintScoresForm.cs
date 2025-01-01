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
    public partial class PrintScoresForm : Form
    {
        public PrintScoresForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();
        COURSE course = new COURSE();
        STUDENT student = new STUDENT();

        private void PrintScoresForm_Load(object sender, EventArgs e)
        {
            //students data
            dataGridView1.DataSource = student.getStudents(new SqlCommand("select id,first_name,laste_name from students"));
            
            //score data
            dataGridViewStudentsScore.DataSource = score.getStudentsScore();

            //course data
            listBoxCourses.DataSource = course.getAllCourses();
            listBoxCourses.DisplayMember = "label";
            listBoxCourses.ValueMember = "id";
        }



        private void listBoxCourses_Click(object sender, EventArgs e)
        {
            dataGridViewStudentsScore.DataSource = score.getCourseScores(int.Parse(listBoxCourses.SelectedValue.ToString()));
        }


        //students display
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridViewStudentsScore.DataSource = score.getStudentScores(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
        }


        private void labelReset_Click(object sender, EventArgs e)
        {
            dataGridViewStudentsScore.DataSource = score.getStudentsScore();
        }




        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Scores-list.txt";

            using (var writer = new StreamWriter(path))
            {
                int col1Width = 5;
                int col2Width = 15;
                int col3Width = 15;
                int col4Width = 15;
                int col5Width = 15;
                int col6Width = 15;

                // Loop through rows
                for (int i = 0; i < dataGridViewStudentsScore.Rows.Count; i++)
                {
                    writer.Write(CenterText(dataGridViewStudentsScore.Rows[i].Cells[0].Value.ToString(), col1Width));
                    writer.Write("| " + CenterText(dataGridViewStudentsScore.Rows[i].Cells[1].Value.ToString(), col2Width));
                    writer.Write("| " + CenterText(dataGridViewStudentsScore.Rows[i].Cells[2].Value.ToString(), col3Width));
                    writer.Write("| " + CenterText(dataGridViewStudentsScore.Rows[i].Cells[3].Value.ToString(), col4Width));
                    writer.Write("| " + CenterText(dataGridViewStudentsScore.Rows[i].Cells[4].Value.ToString(), col5Width));
                    writer.Write("| " + CenterText(dataGridViewStudentsScore.Rows[i].Cells[5].Value.ToString(), col6Width));


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
