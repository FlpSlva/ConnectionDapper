using System;
using Microsoft.Data.SqlClient;

namespace ConnectionDapper
{
     class Program
    {
        static void Main(string[] args)
        {
             SqlConnection con = new SqlConnection();
             con.ConnectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";
             
            using(var connection = new SqlConnection(con.ConnectionString))
            {
               
            }

        }
    }
}