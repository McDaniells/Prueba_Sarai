using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace grupomas
{
    class Validaciones
    {
		public bool ValidarFecha(String dateTime)
        {
			bool flag;
			DateTime dt;

			if	(
					DateTime.TryParseExact(dateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)
				)
			{
				flag = true;
			}
			else
			{
				flag = false;
			}

			return flag;
		}

		public bool ValidarEntero(String numero)
		{
			bool flag;
			int dt;

			if (
					int.TryParse(numero, out dt)
				)
			{
				flag = true;
			}
			else
			{
				flag = false;
			}

			return flag;
		}
	}
}
