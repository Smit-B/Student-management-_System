﻿using System;
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
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            string courseLabel = textBoxLabel.Text;
            int hours = (int)numericUpDownHours.Value;
            string description = textBoxDescription.Text;

            COURSE course = new COURSE();
            if (courseLabel.Trim() == "")
            {
                MessageBox.Show(" Add a Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (course.checkCourseName(courseLabel))
            {
                if (course.insertCourse(courseLabel, hours, description))
                {
                    MessageBox.Show(" New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Course Not Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This Course Name Already Exists", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
