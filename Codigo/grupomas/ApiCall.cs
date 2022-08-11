using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace grupomas
{
    class ApiCall
    {
        private Validaciones validaciones;
        private int id_user;

        public ApiCall()
        {
            validaciones = new Validaciones();
            
        }

        public void Init(int idUser)
        {
            id_user = idUser;
            bool flag = true;

            Console.WriteLine($"Bienvenido, estos son los llamados que puedes hacer a la API de vPIC");

            String opcion = "";

            while (flag)
            {
                try
                {
                    Console.WriteLine($"1.- Get All Makes");
                    Console.WriteLine($"2.- Get Parts");
                    Console.WriteLine($"3.- Get All Manufacturers");
                    Console.WriteLine($"4.- Get Manufacturer Details");                    
                    Console.WriteLine($"0.- Salir");

                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            GetAllMakes();
                            break;
                        case "2":
                            GetParts();
                            break;
                        case "3":
                            GetAllManufacturers();
                            break;
                        case "4":
                            GetManufacturersDetails();
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
                catch(Exception err)
                {
                    Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
                }
            }

        }

        private void GetAllMakes() 
        {
            

            try
            {
                String uri = "https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json";
                var resp = ApiCallMet(uri);

                foreach (var item in resp.Results)
                {
                    Console.WriteLine($"Make_ID: {item.Make_ID} \t Make_Name: {item.Make_Name}");
                }

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }


        }

        private void GetParts()
        {
            try
            {
                String type = "";
                String fromDate = "";
                String toDate = "";

                Console.WriteLine($"Ingrese el tipo:");
                type = Console.ReadLine();

                Console.WriteLine($"Ingrese la fecha de inicio (dd-MM-yyyy) :");
                fromDate = Console.ReadLine();

                if (!validaciones.ValidarFecha(fromDate))
                {
                    throw new Exception("Debe ingresar una fecha valida");
                }

                Console.WriteLine($"Ingrese la fecha fin (dd-MM-yyyy) :");
                toDate = Console.ReadLine();

                if (!validaciones.ValidarFecha(toDate))
                {
                    throw new Exception("Debe ingresar una fecha valida");
                }                

                String uri = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetParts?type={type}&fromDate={fromDate}&{toDate}=5/5/2015&format=json";
                var resp = ApiCallMet(uri);

                foreach (var item in resp.Results)
                {
                    Console.WriteLine($"LetterDate: {item.LetterDate} \t ManufacturerId: {item.ManufacturerId} \t ManufacturerName: {item.ManufacturerName} \t Name: {item.Name}");
                }

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }

        private void GetAllManufacturers()
        {


            try
            {
                String uri = "https://vpic.nhtsa.dot.gov/api/vehicles/getallmanufacturers?format=json";
                var resp = ApiCallMet(uri);

                foreach (var item in resp.Results)
                {
                    Console.WriteLine($"Country: {item.Country} \t Mfr_CommonName: {item.Mfr_CommonName} \t Mfr_ID: {item.Mfr_ID} \t Mfr_Name: {item.Mfr_Name}");

                    foreach (var itemDetail in item.VehicleTypes)
                    {
                        Console.WriteLine($"\t\tVehicleTypeName: {itemDetail.Name}");
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }


        }

        private void GetManufacturersDetails()
        {
            try
            {
                String type = "";                

                Console.WriteLine($"Ingrese el id, el nombre completo o parcial de manufacturero:");
                type = Console.ReadLine();

                String uri = $"https://vpic.nhtsa.dot.gov/api/vehicles/getmanufacturerdetails/{type}?format=json";
                var resp = ApiCallMet(uri);

                foreach (var item in resp.Results)
                {
                    Console.WriteLine($"Address: {item.Address} \t Mfr_CommonName: {item.Mfr_CommonName} \t PostalCode: {item.PostalCode}");

                    foreach (var itemDetail in item.VehicleTypes)
                    {
                        Console.WriteLine($"\t\tVehicleTypeName: {itemDetail.Name}");
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine($"Oh no! Ocurrio un error: {err.ToString()}");
            }
        }



        private dynamic ApiCallMet(string uri)
        {

            HttpClient _httpClient = new HttpClient();

            var _http_response = _httpClient.GetAsync(uri);
            _http_response.Wait();

            var _read_response = _http_response.Result.Content.ReadAsStringAsync();
            _read_response.Wait();

            var data = JsonConvert.DeserializeObject<dynamic>(_read_response.Result);

            if (data.Message != "Response returned successfully")
            {
                throw new Exception("Response error");
            }

            return data;
        }
    }
}
