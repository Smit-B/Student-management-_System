
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Student_System
{
    class STUDENT
    {
        MY_DB db = new MY_DB();
        public bool insertStudent(string fname, string lname, DateTime bdate, string phone, string gender, string address, MemoryStream picture)
        {
            SqlCommand command =new SqlCommand("insert into students(first_name,laste_name,birthdate,gender,phone,address,picture)values(@fn,@ln,@bdt,@gdr,@phn,@adrs,@pic)",db.getConnection);

            command.Parameters.Add("@fn", System.Data.SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", System.Data.SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", System.Data.SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", System.Data.SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", System.Data.SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", System.Data.SqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", System.Data.SqlDbType.VarBinary).Value = picture.ToArray();

            db.openConnection();

             if(command.ExecuteNonQuery() == 1)
             {
                 db.closeConnection();
                 return true;
             }
            else
             {
                 db.closeConnection();
                 return false;
             }
        }

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }

        public bool updateStudent(int id, string fname, string lname, DateTime bdate, string phone, string gender, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("update students set first_name=@fn, laste_name=@ln, birthdate=@bdt, gender=@gdr, phone=@phn, address=@adrs, picture=@pic where id=@id ", db.getConnection);
        
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", System.Data.SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", System.Data.SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", System.Data.SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", System.Data.SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", System.Data.SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", System.Data.SqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", System.Data.SqlDbType.VarBinary).Value = picture.ToArray();

            db.openConnection();

             if(command.ExecuteNonQuery() == 1)
             {
                 db.closeConnection();
                 return true;
             }
            else
             {
                 db.closeConnection();
                 return false;
             }
        }

        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("delete from students where  id=@studentID ", db.getConnection);

            command.Parameters.Add("@studentID", System.Data.SqlDbType.Int).Value = id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, db.getConnection);

            db.openConnection();
            string count = command.ExecuteScalar().ToString();
            db.closeConnection();

            return count;
        }

        public string totalStudent()
        {
            return execCount("select count (*) from students");
        }

        public string totalMaleStudent()
        {
            return execCount("select count (*) from students where gender = 'Male'");
        }

        public string totalFemaleStudent()
        {
            return execCount("select count (*) from students where gender = 'Female'");
        }
    }
}
