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
    class Reporte
    {
        private Validaciones validaciones;
        private QueryFactory con;
        private Event bitacora;
        private int UserId;

        public Reporte(QueryFactory db_con, int userid)
        {
            validaciones = new Validaciones();
            con = db_con;
            bitacora = new Event(con);
            UserId = userid;
        }

        public void Select()
        {
            try
            {                
                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Query("Reporte_1").Get(transaction);

                    foreach (var I in query)
                    {
                        Console.WriteLine($"WId: {I.WId}");
                        Console.WriteLine($"\tWmi: {I.Wmi}");
                        Console.WriteLine($"\tManu Name: {I.MName}");
                        Console.WriteLine($"\tType: {I.VTName}");
                        Console.WriteLine($"");
                    }

                    transaction.Commit();

                    Excel oCreadorExcel = new Excel("Reporte_1.xlsx");
                    oCreadorExcel.CrearExcel(query);

                    Correo correo = new Correo();

                    correo.EnviarCorreo("D:/Users/volos/source/repos/grupomas/Excel/Reporte_1.xlsx");
                }

                con.Connection.Close();

                bitacora.Insert($"Select", "Reporte 1", UserId);                                

                Console.WriteLine($"------------------------------------------------");

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }
    }
}
