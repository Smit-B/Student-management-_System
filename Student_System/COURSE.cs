using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Student_System
{
    class COURSE
    {
        MY_DB mydb = new MY_DB();

        public bool insertCourse(string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("insert into course (label,hours_number,description) values(@name,@hrs,@dscr)", mydb.getConnection);

            command.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@hrs", System.Data.SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@dscr", System.Data.SqlDbType.Text).Value = description;

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }


        public bool checkCourseName(string courseName, int courseId = 0)
        {
            SqlCommand command = new SqlCommand("select * from course where label = '@cName' and id <> @cid",mydb.getConnection);

            command.Parameters.Add("@cid", System.Data.SqlDbType.Int).Value = courseId;
            command.Parameters.Add("c@Name", System.Data.SqlDbType.VarChar).Value = courseName;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                mydb.closeConnection();
                return false;
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }


        public bool deleteCourse(int courseId)
        {
            SqlCommand command = new SqlCommand("delete from course where id=@CID", mydb.getConnection);

            command.Parameters.Add("@CID", System.Data.SqlDbType.Int).Value = courseId;
            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public DataTable getAllCourses()
        {
            SqlCommand command = new SqlCommand("select * from course", mydb.getConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public DataTable getCoursesById(int courseID)
        {
            SqlCommand command = new SqlCommand("select * from course where id = @cid", mydb.getConnection);

            command.Parameters.Add("@cid", System.Data.SqlDbType.Int).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool updateCourse(int courseId, string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("update course set label=@name,hours_number=@hrs,description=@dscr where id=@cid", mydb.getConnection);

            command.Parameters.Add("@cid", System.Data.SqlDbType.Int).Value = courseId;
            command.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@hrs", System.Data.SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@dscr", System.Data.SqlDbType.Text).Value = description;

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }


        public string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);

            mydb.openConnection();
            string count = command.ExecuteScalar().ToString();
            mydb.closeConnection();

            return count;
        }

        public string totalCourses()
        {
            return execCount("select count (*) from course");
        }

    }
}
