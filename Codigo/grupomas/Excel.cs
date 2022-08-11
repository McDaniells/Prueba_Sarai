using System;
using System.Collections.Generic;
using System.Text;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grupomas
{
    class Excel
    {
        private string rutaArchivoCompleta = "";

        public Excel(string nombreArchivo)
        {
            //obtenemos la ruta de nuestro programa y concatenamos el nombre del archivo a crear
            rutaArchivoCompleta = "path/to/Excel/" + nombreArchivo;

        }

        public void CrearExcel(IEnumerable<dynamic> data)
        {
            try
            {
                SLDocument sl = new SLDocument();

                var asList = data.ToList();                               

                for (int i = 1; i < asList.Count; i++)
                {
                    int j = 1;
                    var singledata = asList[i];
                    foreach (var item in singledata)
                    {
                        sl.SetCellValue(i, j, item.Value);                        
                        j += 1;
                    }
                    
                }
             
                sl.SaveAs(rutaArchivoCompleta);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio una Excepción: " + ex.Message);
            }

        }
    }
}
