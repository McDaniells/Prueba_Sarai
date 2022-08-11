using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace grupomas
{
    class DbCall
    {
        private Validaciones validaciones;
        private QueryFactory con;
        private int id_user;
        public DbCall()
        {
            validaciones = new Validaciones();
            DataBase db = new DataBase();
            con = db.databaseCon;            
        }

        public void Init(int idUser)
        {
            id_user = idUser;
            bool flag = true;            

            Console.WriteLine($"Bienvenido, este es el catalogo del sistema vPIC");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Console.WriteLine($"1.- Elements");
                    Console.WriteLine($"2.- Make");
                    Console.WriteLine($"3.- Model");
                    Console.WriteLine($"4.- Manufacturer");
                    Console.WriteLine($"5.- VehicleType");
                    Console.WriteLine($"6.- Wmi");
                    Console.WriteLine($"7.- Usuarios");
                    Console.WriteLine($"8.- Bitacora");
                    Console.WriteLine($"9.- Reporte 1");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Crud_Elements();
                            break;
                        case "2":
                            Crud_Make();
                            break;
                        case "3":
                            Crud_Model();
                            break;
                        case "4":
                            Crud_Manufacturer();
                            break;
                        case "5":
                            Crud_VehicleType();
                            break;
                        case "6":
                            Crud_Wmi();
                            break;
                        case "7":
                            Crud_Usuario();
                            break;
                        case "8":
                            Crud_Event();
                            break;
                        case "9":
                            Reporte_1();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }

        }

        public void Crud_Elements()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a Elements");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Element element = new Element(con, id_user);

                    Console.WriteLine($"1.- Ver Todos o Por ID");
                    Console.WriteLine($"2.- Insertar o Editar");
                    Console.WriteLine($"3.- Eliminar");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            element.Select();
                            break;
                        case "2":
                            element.Insert();
                            break;
                        case "3":
                            element.Delete();
                            break;                        
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }

        public void Crud_Make()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a Make");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Make make = new Make(con, id_user);

                    Console.WriteLine($"1.- Ver Todos o Por ID");
                    Console.WriteLine($"2.- Insertar o Editar");
                    Console.WriteLine($"3.- Eliminar");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            make.Select();
                            break;
                        case "2":
                            make.Insert();
                            break;
                        case "3":
                            make.Delete();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }

        public void Crud_Model()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a Model");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Model model = new Model(con, id_user);

                    Console.WriteLine($"1.- Ver Todos o Por ID");
                    Console.WriteLine($"2.- Insertar o Editar");
                    Console.WriteLine($"3.- Eliminar");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            model.Select();
                            break;
                        case "2":
                            model.Insert();
                            break;
                        case "3":
                            model.Delete();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }

        public void Crud_Manufacturer()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a Manufacturer");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Manufacturer manufacturer = new Manufacturer(con, id_user);

                    Console.WriteLine($"1.- Ver Todos o Por ID");
                    Console.WriteLine($"2.- Insertar o Editar");
                    Console.WriteLine($"3.- Eliminar");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            manufacturer.Select();
                            break;
                        case "2":
                            manufacturer.Insert();
                            break;
                        case "3":
                            manufacturer.Delete();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }

        public void Crud_VehicleType()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a VehicleType");

            String opcion = "";

            while (flag)
            {
                try
                {
                    VehicleType vehicleType = new VehicleType(con, id_user);

                    Console.WriteLine($"1.- Ver Todos o Por ID");
                    Console.WriteLine($"2.- Insertar o Editar");
                    Console.WriteLine($"3.- Eliminar");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            vehicleType.Select();
                            break;
                        case "2":
                            vehicleType.Insert();
                            break;
                        case "3":
                            vehicleType.Delete();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }

        public void Crud_Wmi()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a VehicleType");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Wmi wmi = new Wmi(con, id_user);

                    Console.WriteLine($"1.- Ver Todos o Por ID");
                    Console.WriteLine($"2.- Insertar o Editar");
                    Console.WriteLine($"3.- Eliminar");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            wmi.Select();
                            break;
                        case "2":
                            wmi.Insert();
                            break;
                        case "3":
                            wmi.Delete();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }

        public void Crud_Usuario()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a Usuario");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Usuario usuario = new Usuario(con, id_user);

                    Console.WriteLine($"1.- Ver Todos o Por ID");
                    Console.WriteLine($"2.- Insertar o Editar");
                    Console.WriteLine($"3.- Eliminar");
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            usuario.Select();
                            break;
                        case "2":
                            usuario.Insert();
                            break;
                        case "3":
                            usuario.Delete();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }
        
        public void Crud_Event()
        {
            bool flag = true;

            Console.WriteLine($"Bienvenido a Usuario");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Event bitacora = new Event(con);

                    Console.WriteLine($"1.- Ver Todos o Por ID");                    
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            bitacora.Select();
                            break;                        
                        default:
                            flag = false;
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }
        }

        public void Reporte_1()
        {
            Reporte reporte = new Reporte(con, id_user);

            reporte.Select();
        }
    }
}