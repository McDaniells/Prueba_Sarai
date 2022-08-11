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
    class Usuario
    {
        private Validaciones validaciones;
        private QueryFactory con;
        private Event bitacora;
        private int UserId;
        public Usuario(QueryFactory db_con, int userid)
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
                    var query = con.Select("exec SP_Usuario_sel @ID", new
                    {
                        ID = id
                    }, transaction);

                    foreach (var I in query)
                    {
                        Console.WriteLine($"Name: {I.Name}");
                        Console.WriteLine($"\tLastName: {I.LastName}");
                        Console.WriteLine($"\tUserName {I.UserName}");
                        Console.WriteLine($"");
                    }

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Select id: {id}", "SP_Usuario_sel", UserId);

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
                    var query = con.Select("exec SP_Usuario_del @ID", new
                    {
                        ID = id
                    }, transaction);

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Delete id: {id}", "SP_Usuario_del", UserId);

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
                String lastname = "";
                String username = "";
                String password = "";


                Console.WriteLine($"Ingrese el ID para editar o 0 si quiere desea insertar un nuevo registro");
                id = Console.ReadLine();

                if (!validaciones.ValidarEntero(id)) throw new Exception("El ID debe ser un numero");

                Console.WriteLine($"Ingrese el Nombre");
                name = Console.ReadLine();

                Console.WriteLine($"Ingrese el apellido");
                lastname = Console.ReadLine();

                Console.WriteLine($"Ingrese el username");
                username = Console.ReadLine();

                Console.WriteLine($"Ingrese el password");
                password = Console.ReadLine();

                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Usuario_ups @Name,@UserName,@PassWord,@ID,@LastName,@CreatedOn,@UpdatedOn", new
                    {
                        Name = name,
                        UserName = username,
                        PassWord = password,
                        ID = id,
                        LastName = lastname,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                    }, transaction);

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Ins/Upd", "SP_Usuario_ups", UserId);

                Console.WriteLine($"La operacion se completo de manera exitosa!");
                Console.WriteLine($"------------------------------------------------");

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }

        public int Login(String user, String pass)
        {
            int resp = 0;

            try
            {
                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Usuario_login @user,@password", new
                    {
                        user = user,
                        password = pass
                    }, transaction);

                    foreach (var I in query)
                    {
                        resp = Convert.ToInt32(I.status.ToString());
                    }

                    transaction.Commit();
                }

                con.Connection.Close();                

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }

            return resp;
        }
    }
}
