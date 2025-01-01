using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_System
{
    public partial class PrintCoursesForm : Form
    {
        public PrintCoursesForm()
        {
            InitializeComponent();
        }

        private void PrintCoursesForm_Load(object sender, EventArgs e)
        {
            COURSE course = new COURSE();
            dataGridView1.DataSource = course.getAllCourses();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Courses-list.txt";

            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }


                // Loop through rows
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    {

                        writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }
                        writer.WriteLine("");
                    writer.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                }

                writer.Close();
                MessageBox.Show("Data Exported");
            }
        }

       
    }
}
