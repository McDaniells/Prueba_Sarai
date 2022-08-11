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
    class Event
    {
        private Validaciones validaciones;
        private QueryFactory con;
        public Event(QueryFactory db_con)
        {
            validaciones = new Validaciones();
            con = db_con;
        }

        public void Select()
        {
            try
            {
                String id = "";
                Console.WriteLine($"Ingrese el ID usuario o 0 si quiere ver todos");
                id = Console.ReadLine();

                if (!validaciones.ValidarEntero(id)) throw new Exception("El ID debe ser un numero");

                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Event_sel @ID", new
                    {
                        ID = id
                    }, transaction);

                    foreach (var I in query)
                    {
                        Console.WriteLine($"EventName: {I.EventName}");
                        Console.WriteLine($"\tTableName: {I.TableName}");
                        Console.WriteLine($"\tName: {I.Name}");
                        Console.WriteLine($"");
                    }

                    transaction.Commit();
                }

                con.Connection.Close();

                Console.WriteLine($"------------------------------------------------");

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }

        public void Delete()
        {
            try
            {
                String id = "";
                Console.WriteLine($"Ingrese el ID que desea borrar");
                id = Console.ReadLine();

                if (!validaciones.ValidarEntero(id)) throw new Exception("El ID debe ser un numero");

                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Event_del @ID", new
                    {
                        ID = id
                    }, transaction);

                    transaction.Commit();
                }

                con.Connection.Close();

                Console.WriteLine($"Se Borro de manera exitosa!");
                Console.WriteLine($"------------------------------------------------");

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }

        public void Insert(String EventName, String TableName, int UserId)
        {
            try
            {
                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Event_ups @EventName,@TableName,@UserId,@ID", new
                    {
                        EventName = EventName,
                        TableName = TableName,
                        UserId = UserId,
                        ID = 0
                    }, transaction);

                    transaction.Commit();
                }

                con.Connection.Close();

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }
    }
}
