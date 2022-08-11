using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using SqlKata;
using SqlKata.Execution;
using System.Data.SqlClient;
using SqlKata.Compilers;

namespace grupomas
{
    class DataBase
    {
        public QueryFactory databaseCon;
        public DataBase()
        {
            try
            {
                var connection = new SqlConnection("Data Source=LAPTOP-LM74J74L\\SQLEXPRESS;Initial Catalog=PruebaGPM;User Id=sa;Password=meiif6bnm");
                var compiler = new SqlServerCompiler();

                databaseCon = new QueryFactory(connection, compiler);

                /*
                db.Connection.Open();

                using (var transaction = db.Connection.BeginTransaction())
                {
                    var elementQ = db.Query("Element").Select("Id", "Name", "Code", "Description").Get(transaction);

                    foreach (var elemItem in elementQ)
                    {
                        Console.WriteLine(elemItem.Name);
                    }
                }
                */
                    
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }            
        }
    }
}
