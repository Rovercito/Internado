using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DaoInternado.Model
{
    public class User: Person
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public User(string password)
        {
            
            Password = password;
            
        }

        public User(string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate, string userName, string password, string role)
            : base(name, lastName, secondLastName, phone, email, status, registerDate, lastUpdate)
        {
            //Id = id;
            UserName = userName;
            Password = password;
            Role = role;
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
        /// <param name=""></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        public User(int idPerson,string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate, string userName, string password, string role)
            : base(idPerson,name, lastName, secondLastName, phone, email, status, registerDate, lastUpdate)
        {
            //Id = id;
            UserName = userName;
            Password = password;
            Role = role;
        }
        public User()
        {
            
        }
    }
}
