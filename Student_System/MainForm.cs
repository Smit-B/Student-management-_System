using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStdF = new AddStudentForm();
            addStdF.Show();
        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentsListForm stdListF = new studentsListForm();
            stdListF.Show(this);
        }

        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsForm stcF = new StaticsForm();
            stcF.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm upDelStdf =new UpdateDeleteStudentForm();
            upDelStdf.Show(this);
        }

        private void mangeStudentFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentsForm mngStdF = new ManageStudentsForm();
            mngStdF.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStudentsForm prStdF = new PrintStudentsForm();
            prStdF.Show();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseForm addCrsF = new AddCourseForm();
            addCrsF.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm rmvCrsF = new RemoveCourseForm();
            rmvCrsF.Show(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm editCrsF = new EditCourseForm();
            editCrsF.Show(this);
        }

        private void mangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCoursesForm mngCrsF = new ManageCoursesForm();
            mngCrsF.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCoursesForm prCrsF = new PrintCoursesForm();
            prCrsF.Show(this);
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm addScrF = new AddScoreForm();
            addScrF.Show(this);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm rmvScrF = new RemoveScoreForm();
            rmvScrF.Show(this);
        }

        private void managScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoresForm mngScrF = new ManageScoresForm();
            mngScrF.Show(this);
        }

        private void avgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvgScoreByCourseForm avgScrByCrsF = new AvgScoreByCourseForm();
            avgScrByCrsF.Show(this);
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintScoresForm prScrF = new PrintScoresForm();
            prScrF.Show(this);
        }
    }
}
