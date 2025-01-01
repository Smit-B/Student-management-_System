using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Student_System
{
    class SCORE
    {
        MY_DB mydb = new MY_DB();

        public bool insertScore(int studentid, int courseid, float score, string description)
        {
            SqlCommand command = new SqlCommand("insert into score(studentid,courseid,score,description)values(@sid,@cid,@scr,@dscr)",mydb.getConnection);

            command.Parameters.Add("@sid", System.Data.SqlDbType.Int).Value = studentid;
            command.Parameters.Add("@cid", System.Data.SqlDbType.Int).Value = courseid;
            command.Parameters.Add("@scr", System.Data.SqlDbType.Float).Value = score;
            command.Parameters.Add("@dscr", System.Data.SqlDbType.VarChar).Value = description;

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

        public bool studentScoreExists(int studentid, int courseid)
        {
            SqlCommand command = new SqlCommand("select * from score where studentid=@sid and courseid = @cid",mydb.getConnection);

            command.Parameters.Add("@sid", System.Data.SqlDbType.Int).Value = studentid;
            command.Parameters.Add("@cid", System.Data.SqlDbType.Int).Value = courseid;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);


            if (table.Rows.Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public DataTable getStudentsScore()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText=("select score.studentid,students.first_name,students.laste_name,score.courseid,course.label,score.score from students inner join score on students.id=score.studentid inner join course on score.courseid=course.id");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }


        public bool deleteScore(int studentid,int courseid)
        {
            SqlCommand command = new SqlCommand("delete from score where studentid=@sid and courseid=@cid", mydb.getConnection);

            command.Parameters.Add("@sid", System.Data.SqlDbType.Int).Value = studentid;
            command.Parameters.Add("@cid", System.Data.SqlDbType.Int).Value = courseid;
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


        public DataTable AvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("select course.label,avg(score.score) as 'average score' from course,score where course.id=score.courseid group by course.label");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }


        public DataTable getCourseScores(int courseid)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("select score.studentid, students.first_name, students.laste_name, score.courseid, course.label, score.score from students inner join score on students.id=score.studentid inner join course on score.courseid=course.id where score.courseid=" + courseid);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }


        public DataTable getStudentScores(int studentid)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("select score.studentid, students.first_name, students.laste_name, score.courseid, course.label, score.score from students inner join score on students.id=score.studentid inner join course on score.courseid=course.id where score.studentid=" + studentid);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
