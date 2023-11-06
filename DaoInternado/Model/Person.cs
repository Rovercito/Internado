using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Model
{
    public class Person : BaseModel
    {
        #region Properties
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="idPerson"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="secondLastName"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        public Person(string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate)
            : base(status, registerDate, lastUpdate)
        {
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            Phone = phone;
            Email = email;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idPerson"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="secondLastName"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        public Person(int idPerson, string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate)
         : base(status, registerDate, lastUpdate)
        {
            IdPerson = idPerson;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            Phone = phone;
            Email = email;
        }


        public Person(string name, string lastName, string secondLastName, int phone, string email)
        {
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            Phone = phone;
            Email = email;
        }

        public Person()
        {

        }
        #endregion

    }
}
