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

namespace Student_System
{
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();
        COURSE course = new COURSE();
        STUDENT student = new STUDENT();

        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            comboBoxCourse.DataSource = course.getAllCourses();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "id";

            SqlCommand command = new SqlCommand("select id, first_name,laste_name from students ");
            dataGridView1.DataSource = student.getStudents(command);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBoxStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void buttonAddScore_Click(object sender, EventArgs e)
        {
            try
            {
                int studentid = Convert.ToInt32(textBoxStudentID.Text);
                int courseid = Convert.ToInt32(comboBoxCourse.SelectedValue);
                float scoreValue = Convert.ToSingle(textBoxScore.Text);
                string description = textBoxDescription.Text;

                if (!score.studentScoreExists(studentid, courseid))
                {
                    if (score.insertScore(studentid, courseid, scoreValue, description))
                    {
                        MessageBox.Show("Student Score Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student Score Not Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The Score For THis Course Are Already Set", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
