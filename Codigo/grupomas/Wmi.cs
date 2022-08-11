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
    class Wmi
    {
        private Validaciones validaciones;
        private QueryFactory con;
        private Event bitacora;
        private int UserId;
        public Wmi(QueryFactory db_con, int userid)
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
                    var query = con.Select("exec SP_Wmi_sel @ID", new
                    {
                        ID = id
                    }, transaction);

                    foreach (var I in query)
                    {
                        Console.WriteLine($"Wmi: {I.Wmi}");
                        Console.WriteLine($"\tId: {I.Id}");
                        Console.WriteLine($"\tManName: {I.ManName}");
                        Console.WriteLine($"\tMakeName: {I.MakeName}");
                        Console.WriteLine($"\tVTName: {I.VTName}");
                        Console.WriteLine($"");
                    }

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Select id: {id}", "SP_Wmi_sel", UserId);

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
                    var query = con.Select("exec SP_Wmi_del @ID", new
                    {
                        ID = id
                    }, transaction);

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Delete id: {id}", "SP_Wmi_del", UserId);

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
                String Wmi;
                String id;
                String ManufacturerId;
                String MakeId;
                String VehicleTypeId;

                Console.WriteLine($"Ingrese el ID para editar o 0 si quiere desea insertar un nuevo registro");
                id = Console.ReadLine();

                if (!validaciones.ValidarEntero(id)) throw new Exception("El ID debe ser un numero");

                Console.WriteLine($"Ingrese el Wmi");
                Wmi = Console.ReadLine();

                Console.WriteLine($"Ingrese el ID de manufactura");
                ManufacturerId = Console.ReadLine();

                if (!validaciones.ValidarEntero(ManufacturerId)) throw new Exception("El ID debe ser un numero");

                Console.WriteLine($"Ingrese el ID de Make");
                MakeId = Console.ReadLine();

                if (!validaciones.ValidarEntero(MakeId)) throw new Exception("El ID debe ser un numero");

                Console.WriteLine($"Ingrese el ID de VehicleType");
                VehicleTypeId = Console.ReadLine();

                if (!validaciones.ValidarEntero(VehicleTypeId)) throw new Exception("El ID debe ser un numero");

                con.Connection.Open();

                using (var transaction = con.Connection.BeginTransaction())
                {
                    var query = con.Select("exec SP_Wmi_ups @Wmi, @ID, @ManufacturerId, @MakeId, @VehicleTypeId, @CreatedOn, @UpdatedOn", new
                    {
                        Wmi = Wmi,
                        ID = id,
                        ManufacturerId = ManufacturerId,
                        MakeId = MakeId,
                        VehicleTypeId = VehicleTypeId,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                    }, transaction);

                    transaction.Commit();
                }

                con.Connection.Close();

                bitacora.Insert($"Ins/Upd", "SP_Wmi_ups", UserId);

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
