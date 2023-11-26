using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DaoInternado.Tools
{
    public class ValidationHospital
    {
        public bool ValidateVOID(string cont1, string cont2, string cont3, string cont4)
        {
            if (cont1 == "" || cont2 == "" || cont3 == "" || cont4 == "")
            {
                return false;
            }
            else
            {

                return true;
            }

        }

        public bool ValidatePhone(string num)
        {

            foreach (char c in num)
            {
                if (!char.IsLetterOrDigit(c) || c == '-' || c == ' ')
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidateEmail(string email)
        {
            string patron = @"^[a-zA-Z0-9]+@[a-z]+\.[a-z]+(?:\.[a-z]+)?$";

            if (!Regex.IsMatch(email, patron))
            {
                return false;
            }
            else
            {
                int positionAroba = email.IndexOf("@");
                string[] dominios = new string[] { "gmail.com", "yahoo.com", "est.univalle.edu", "hotmail.com", "univalle.edu", "outlook.es", "outlook.com" };
                string dominio = email.Substring(positionAroba + 1);

                if (!dominios.Contains(dominio))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }
    }
}
