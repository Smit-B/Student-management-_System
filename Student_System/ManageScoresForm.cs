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
    public partial class ManageScoresForm : Form
    {
        public ManageScoresForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();
        STUDENT student = new STUDENT();
        COURSE course = new COURSE();
        string data = "score";

        private void ManageScoresForm_Load(object sender, EventArgs e)
        {
            comboBoxCourse.DataSource = course.getAllCourses();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "id";

            dataGridView1.DataSource = score.getStudentsScore(); 
        }

        private void buttonShowStudents_Click(object sender, EventArgs e)
        {
            data = "student";
            SqlCommand command = new SqlCommand("select id,first_name,laste_name,birthdate from students");
            dataGridView1.DataSource = student.getStudents(command);
        }

        private void buttonShowScore_Click(object sender, EventArgs e)
        {
            data = "score";
            dataGridView1.DataSource = score.getStudentsScore();
        }



        private void dataGridView1_Click(object sender, EventArgs e)
        {
            getDataFromDatagridview();
        }


        public void getDataFromDatagridview()
        {

            if (data == "student")
            {
                textBoxStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            else if (data == "score")
            {
                textBoxStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxCourse.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value;
            }
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
                        textBoxScore.Text = "";
                        textBoxDescription.Text = "";
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

        private void buttonRemoveScore_Click(object sender, EventArgs e)
        {
            int studentid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int courseid = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if (MessageBox.Show("Do You Want To Delete This Score ", "Delete Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (score.deleteScore(studentid, courseid))
                {
                    MessageBox.Show("Score Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = score.getStudentsScore();
                    textBoxScore.Text = "";
                    textBoxDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Score Not Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void buttonAvgScore_Click(object sender, EventArgs e)
        {
            AvgScoreByCourseForm avgScrByCrsF = new AvgScoreByCourseForm();
            avgScrByCrsF.Show(this);
        }
    }
}
