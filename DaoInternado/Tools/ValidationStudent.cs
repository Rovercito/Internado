using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DaoInternado.Tools
{
    public class ValidationStudent
    {
        public bool IsOnlyLetters(string input)
        {
            string patron = @"^[\p{L}\sñÑáéíóúÁÉÍÓÚ]+$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(input);
        }
        public bool IsOnlyNumbers(string input)
        {
            Regex regex = new Regex(@"^\d+$");
            bool isNumeric = regex.IsMatch(input);

            return isNumeric;
        }
        public bool ValidateEmail(string input)
        {
            string patron = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            bool esValido = Regex.IsMatch(input, patron);

            return esValido;

        }
        public bool IsValidIdentificationNumber(string input)
        {
            Regex regex = new Regex(@"\b\d+(?:-\w+)?\b");
            bool esValido = regex.IsMatch(input);

            return esValido;
        }

        public string Send(string user, string password, string email)
        {
            string message = "";
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
                emailS.Body = "Usuario creado exitosamente\nusuario temporal es: " + user + "\ncontrasena temporal: " + password;
                person.Send(emailS);

                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool VlPrice(string texto)
        {
            string patron = @"^\d+([,]\d{1,2})?$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(texto);
        }
        public bool VlSize(string texto)
        {
            string patron = @"^[a-zA-Z0-9]+$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(texto);
        }

        public bool VlBrand(string texto)
        {
            string patron = @"^(?! )(?!.* $)[a-zA-Z0-9'ñÑ\sáéíóúÁÉÍÓÚ&äëïöüÄËÏÖÜ-]+$";

            Regex regex = new Regex(patron);
            return regex.IsMatch(texto);
        }

        public bool VlEspace(string texto)
        {
            if (!string.IsNullOrWhiteSpace(texto) && texto.Trim().Contains(" "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VlAdress(string texto)
        {
            string patron = @"^[a-zA-Z0-9,#'°ñäëïöüáéíóú¿¡\""\s]+$";

            bool esValido = Regex.IsMatch(texto, patron);

            return esValido;
        }

        public bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
