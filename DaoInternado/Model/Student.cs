using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Model
{
    public class Student : Person
    {
        #region Properties
        public int IdStudent { get; set; }
        public string Speciality { get; set; }
        public int DoctorID { get; set; }
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
        /// <param name="doctorID"></param>
        /// <param name="hospitalID"></param>
        public Student(string name, string lastName, string secondLastName, int phone, string email, string speciality, int doctorID, int hospitalID)
          : base(name, lastName, secondLastName, phone, email)
        {
            Speciality = speciality;
            DoctorID = doctorID;
            HospitalID = hospitalID;
        }

        public Student(int IdPerson, string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate, string speciality, int doctorID, int hospitalID)
            : base(IdPerson, name, lastName, secondLastName, phone, email, status, registerDate, lastUpdate)
        {
            Speciality = speciality;
            DoctorID = doctorID;
            HospitalID = hospitalID;
        }


        public Student(string name, string lastName, string secondLastName, int phone, string email, byte status, DateTime registerDate, DateTime lastUpdate, string speciality, int doctorID, int hospitalID)
            : base(name, lastName, secondLastName, phone, email, status, registerDate, lastUpdate)
        {
            Speciality = speciality;
            DoctorID = doctorID;
            HospitalID = hospitalID;
        }
        #endregion
    }
}
