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
    class Element
    {
        private Validaciones validaciones;
        private QueryFactory con;
        private Event bitacora;
        private int UserId;
        public Element(QueryFactory db_con, int userid)
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
                String id = "";
                Console.WriteLine($"Ingrese el ID o 0 si quiere ver todos");
                id = Console.ReadLine();

                if (!validaciones.ValidarEntero(id)) throw new Exception("El ID debe ser un numero");

                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Element_sel @ID", new
                    {
                        ID = id
                    }, transaction);

                    foreach (var I in query)
                    {
                        Console.WriteLine($"Name: {I.Name}");
                        Console.WriteLine($"\tCode: {I.Code}");
                        Console.WriteLine($"");
                    }

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Select id: {id}", "SP_Element_sel", UserId);

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
                    var query = con.Select("exec SP_Element_del @ID", new
                    {
                        ID = id
                    }, transaction);
                   
                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Delete id: {id}", "SP_Element_del", UserId);

                Console.WriteLine($"Se Borro de manera exitosa!");
                Console.WriteLine($"------------------------------------------------");

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }

        public void Insert()
        {
            try
            {
                String id = "";
                String name = "";
                String code = "";
                String description = "";                

                Console.WriteLine($"Ingrese el ID para editar o 0 si quiere desea insertar un nuevo registro");
                id = Console.ReadLine();

                if (!validaciones.ValidarEntero(id)) throw new Exception("El ID debe ser un numero");

                Console.WriteLine($"Ingrese el Nombre");
                name = Console.ReadLine();

                Console.WriteLine($"Ingrese el codigo");
                code = Console.ReadLine();

                Console.WriteLine($"Ingrese la descripcion");
                description = Console.ReadLine();

                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Element_ups @Name, @ID, @Code, @Description", new
                    {
                        Name = name,
                        ID = id,
                        Code = code,
                        Description = description
                    }, transaction);    

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Ins/Upd", "SP_Element_ups", UserId);

                Console.WriteLine($"La operacion se completo de manera exitosa!");
                Console.WriteLine($"------------------------------------------------");

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }
    }
}
