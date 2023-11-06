using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Tools
{
    public class ValidationDoctor
    {
        public string Send(string user, string password, string apellido, string email)
        {
            string message = "Estimado"+ user +" " + apellido +",\n\n"
            + "Le informamos que su usuario ha sido creado exitosamente.\n"
            + "A continuación, encontrará los detalles de inicio de sesión:\n\n"
            + "Nombre de usuario temporal: " + user + "\n"
            + "Contraseña temporal: " + password + "\n\n"
            + "Por favor, siga las siguientes instrucciones para comenzar a utilizar su cuenta:\n"
            + "1. Ingrese al sitio web: http://localhost:8888/Login.aspx.\n"
            + "2. Utilice su nombre de usuario y contraseña temporales para iniciar sesión.\n"
            + "3. Cambie su contraseña temporal por una contraseña segura y única.\n\n"
            + "Le recomendamos encarecidamente que cambie su contraseña temporal tan pronto como sea posible por motivos de seguridad. Si necesita ayuda o tiene alguna pregunta, no dude en ponerse en contacto con nuestro equipo de soporte.\n\n"
            + "¡Gracias por unirse a nuestra plataforma!\n\n";
            

            try
            {
                var person = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("colorinshopcontacto@gmail.com", "vapqpysxkwexunrc")
                };
                var emailS = new MailMessage("colorinshopcontacto@gmail.com", email);

                emailS.Subject = "Asunto: " + DateTime.Now.ToString();
                //emailS.Body = "Usuario creado exitosamente\nusuario temporal es: " + user + "\ncontrasena temporal: " + password
                emailS.Body = message;
                person.Send(emailS);

                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
