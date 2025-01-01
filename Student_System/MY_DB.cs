using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student_System
{
    class MY_DB
    {
        private SqlConnection con = new SqlConnection("Data Source=smit;Initial Catalog=Student_db;Persist Security Info=True;User ID=SA;Password=sqlserver");

       public SqlConnection getConnection
       {
           get
           {
               return con;
           }
       }

           public void openConnection()
           {
               if(con.State==ConnectionState.Closed)
               {
                   con.Open();
               }
           }
           public void closeConnection()
           {
               if (con.State == ConnectionState.Open)
               {
                   con.Close();
               }
           }
       
    }
}
