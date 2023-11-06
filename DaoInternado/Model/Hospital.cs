using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DaoInternado.Model
{
    public class Hospital : BaseModel
    {
        public int HospitalID { get; set; }
        public string NameHospital { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Phone { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

        public Hospital(int hospitalID, string nameHospital, float latitude, float longitude, int phone, string description, string email, byte status, DateTime registerDate, DateTime lastUpdate)
         : base(status, registerDate, lastUpdate)
        {
            HospitalID = hospitalID;
            NameHospital = nameHospital;
            Latitude = latitude;
            Longitude = longitude;
            Phone = phone;
            Description = description;
            Email = email;
        }

        public Hospital(string nameHospital, float latitude, float longitude, int phone, string description, string email, byte status, DateTime registerDate, DateTime lastUpdate)
            : base(status, registerDate, lastUpdate)
        {
            
            NameHospital = nameHospital;
            Latitude = latitude;
            Longitude = longitude;
            Phone = phone;
            Description = description;
            Email = email;
        }

        public Hospital(string nameHospital, float latitude, float longitude, int phone, string description, string email)
        {

            NameHospital = nameHospital;
            Latitude = latitude;
            Longitude = longitude;
            Phone = phone;
            Description = description;
            Email = email;
        }


        public Hospital() { }
       
    }
}
