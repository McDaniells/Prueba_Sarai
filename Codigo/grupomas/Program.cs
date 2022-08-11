using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace grupomas
{
    class Program
    {
        static void Main(string[] args)
        {            
            DataBase db = new DataBase();
            Usuario usuario = new Usuario(db.databaseCon,1);
            bool flag = true;            
            
            while (flag)
            {
                try
                {
                    String user = "";
                    String pass = "";
                    int id_user = 0;

                    Console.WriteLine("Ingrese el usuario:");
                    user = Console.ReadLine();

                    Console.WriteLine("Ingrese el password:");
                    pass = Console.ReadLine();

                    id_user = usuario.Login(user, pass);

                    if (id_user > 0)
                    {
                        Sistema(id_user);
                    }
                    else
                    {
                        Console.WriteLine("Los datos no son los correctos");
                        Console.WriteLine("-----------------------------------------------");
                    }

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }
            } 

        }

        public static void Sistema(int id_user)
        {
            ApiCall mainApi = new ApiCall();
            DbCall mainDB = new DbCall();
            DataBase db = new DataBase();
            Usuario usuario = new Usuario(db.databaseCon, 1);
            bool flag = true;

            while (flag)
            {
                try
                {
                    String opcion = "";                    

                    Console.WriteLine("1. Sistema DB:");
                    Console.WriteLine("2. API:");
                    Console.WriteLine("0. Salir:");
                    opcion = Console.ReadLine();

                    if (opcion == "1")
                    {
                        mainDB.Init(id_user);                        
                    }
                    else if (opcion == "2")
                    {
                        mainApi.Init(id_user);
                    }
                    else
                    {
                        flag = false;
                    }

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }
            }
        }

    }
}
