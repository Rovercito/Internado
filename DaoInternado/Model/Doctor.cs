using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Model
{
    public class Doctor:Person
    {
        #region Properties
        public int IdDoctor { get; set; }
        public string Speciality { get; set; }
        public int HospitalID { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="secondLastName"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="speciality"></param>
        /// <param name="hospitalID"></param>
        public Doctor(string name, string lastName, string secondLastName, int phone, string email, string speciality, int hospitalID)
           : base(name, lastName, secondLastName, phone, email)
        {
            Speciality = speciality;
            HospitalID = HospitalID;
            HospitalID = hospitalID;
        }

        public Doctor(int IdPerson, string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate, string speciality, int hospitalID)
            : base(IdPerson, name, lastName, secondLastName, phone, email, status, registerDate, lastUpdate)
        {
            Speciality = speciality;
            HospitalID = hospitalID;
        }


        public Doctor(string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate, string speciality, int hospitalID)
            : base(name, lastName, secondLastName, phone, email, status, registerDate, lastUpdate)
        {
            Speciality = speciality;
            HospitalID = hospitalID;
        }
        #endregion

    }
}
