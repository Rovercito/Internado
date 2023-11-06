using DaoInternado.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DaoInternado.Model
{
    public class TaskStudent
    {
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpireDate { get; set; }
        public byte[] Image { get; set; }
        public byte[] FileStudent { get; set; }
        public string Status{ get; set;}
        public int IdDoctor { get; set;}
        public int IdStudent { get; set;}
        #endregion

        #region Constructor
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="expireDate"></param>
        /// <param name="status"></param>
        /// <param name="doctorId"></param>
        /// <param name="studentId"></param>
        public TaskStudent(int id, string description, DateTime date, DateTime expireDate, byte[] image, byte[] fileStudent, string status, int idDoctor, int idStudent)
        {
            Id = id;
            Description = description;
            Date = date;
            ExpireDate = expireDate;
            Image = image;
            FileStudent = fileStudent;
            Status = status;
            IdDoctor = idDoctor;
            IdStudent = idStudent;
        }

        public TaskStudent(int id, string description, DateTime date, DateTime expireDate, byte[] image, byte[] fileStudent, string status)
        {
            Id = id;
            Description = description;
            Date = date;
            ExpireDate = expireDate;
            Image = image;
            FileStudent = fileStudent;
            Status = status;
         
        }

        public TaskStudent(int id, string description, DateTime date, DateTime expireDate, int idStudents)
        {
            Id = id;
            Description = description;
            Date = date;
            ExpireDate = expireDate;
            IdStudent = idStudents;
        }

        public TaskStudent(int id, string description, DateTime expireDate)
        {
            Id = id;
            Description = description;
            ExpireDate = expireDate;

        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="expireDate"></param>
        /// <param name="status"></param>
        /// <param name="doctorId"></param>
        /// <param name="studentId"></param>
        public TaskStudent(string description, DateTime date, DateTime expireDate, byte[] image, byte[] fileStudent, string status, int idDoctor, int idStudent)
        {
            Description = description;
            Date = date;
            ExpireDate = expireDate;
            Image = image;
            FileStudent = fileStudent;
            Status = status;
            IdDoctor = idDoctor;
            IdStudent = idStudent;
        }

        public TaskStudent(string description, DateTime date, DateTime expireDate, string statusTask, int idDoctor, int idStudent)
        {
            Description = description;
            Date = date;
            ExpireDate = expireDate;
            Status = statusTask;
            IdDoctor = idDoctor;
            IdStudent = idStudent;
        }

        public TaskStudent()
        {
        }
        #endregion
    }
}
