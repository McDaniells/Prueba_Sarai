# Prueba_Sarai

## Notas
### Clase Correo
En la clase Correo, en la parte de:
    mail.From = new MailAddress("");
poner el correo desde el cual se mandara el correo.
Despues en:
    mail.To.Add("");
poner el destinatario. En la linea 26:
    SmtpServer.Credentials = new System.Net.NetworkCredential("user", "password");
Se deberan poner las credenciales del correo

### Clase Excel
En la clase Excel, en el metodo constructor, se debera poner la ruta hacia la carpeta Excel que esta en raiz

### Usuario
El backup de la base de datos tiene un usuario, el cual su username es *daniel* y el password es *daniel*