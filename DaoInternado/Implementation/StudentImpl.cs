using DaoInternado.Interfaces;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Implementation
{
    public class StudentImpl : BaseImpl, IStudent
    {
        public int Delete(Student t)
        {
            throw new NotImplementedException();
        }

        public int Delete(int t)
        {
            query = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
                      WHERE idPerson=@id";
            //SqlCommand command = CreateBasicCommand(query);
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", t);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ComboBoxStudent()
        {
            query = @"  SELECT S.idStudent AS id, P.name AS name
                        FROM Student S
                        INNER JOIN Person P ON S.idStudent = P.idPerson
                        WHERE P.status=1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Student Get(int id)
        {
            Student s = null;
            query = @"    SELECT P.idPerson,P.name,P.lastName,P.secondLastName,P.phone,P.email,P.status,P.registerDate,ISNULL(P.lastUpdate,CURRENT_TIMESTAMP),S.speciality, S.idDoctor,S.idHospital
                          FROM Person P
                          INNER JOIN Student S ON P.idPerson=S.idStudent
                          WHERE P.idPerson=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    s = new Student(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(), int.Parse(table.Rows[0][4].ToString()), table.Rows[0][5].ToString(),
                        byte.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString()), DateTime.Parse(table.Rows[0][8].ToString()),
                         table.Rows[0][9].ToString(), int.Parse(table.Rows[0][10].ToString()), int.Parse(table.Rows[0][11].ToString()));

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return s;
        }

        public int Insert(Student t)
        {
           
            query = @"INSERT INTO Person(name,lastName,secondLastName,phone,email)
            VALUES(@name,@lastName,@secondLastName,@phone,@email)";

            string query2 = @"INSERT INTO Student(idStudent,speciality,idDoctor,idHospital)
	                Values(@idStudent,@speciality,@doctorID,@hospitalID)";

            List<SqlCommand> commands = CreateBasicCommand2(query, query2);

            commands[0].Parameters.AddWithValue("@name", t.Name);
            commands[0].Parameters.AddWithValue("@lastName", t.LastName);
            commands[0].Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            commands[0].Parameters.AddWithValue("@phone", t.Phone);
            commands[0].Parameters.AddWithValue("@email", t.Email);

            int id = int.Parse(GetGenerateIDTable("Person"));

            commands[1].Parameters.AddWithValue("@idStudent", id);
            commands[1].Parameters.AddWithValue("@speciality", t.Speciality);
            commands[1].Parameters.AddWithValue("@doctorID", t.DoctorID);
            commands[1].Parameters.AddWithValue("@hospitalID", t.HospitalID);

            

            return ExecuteNBasicCommand(commands);
        }


        public int Insert2(User u, Student s)
        {
            query = @"INSERT INTO Person(name,lastName,secondLastName,phone,email)
            VALUES(@name,@lastName,@secondLastName,@phone,@email)";


            string query2 = @"INSERT INTO [User](idPerson,users,password,role)
	                Values(@idUser,@users,HASHBYTES('MD5',@password),@role)";

            string query3 = @"INSERT INTO Student(idStudent,speciality,doctorID,hospitalID)
	                Values(@idStudent,@speciality,@doctorID,@hospitalID)";



            List<SqlCommand> commands = CreateBasicCommand3(query, query2, query3);

            commands[0].Parameters.AddWithValue("@name", u.Name);
            commands[0].Parameters.AddWithValue("@lastName", u.LastName);
            commands[0].Parameters.AddWithValue("@secondLastName", u.SecondLastName);
            commands[0].Parameters.AddWithValue("@phone", u.Phone);
            commands[0].Parameters.AddWithValue("@email", u.Email);


            int id = int.Parse(GetGenerateIDTable("Person"));

            commands[1].Parameters.AddWithValue("@idUser", id);
            commands[1].Parameters.AddWithValue("@users", u.UserName);
            commands[1].Parameters.AddWithValue("@password", u.Password).SqlDbType = SqlDbType.VarChar;
            commands[1].Parameters.AddWithValue("@role", u.Role);


            commands[2].Parameters.AddWithValue("@idStudent", id);
            commands[2].Parameters.AddWithValue("@speciality", s.Speciality);
            commands[2].Parameters.AddWithValue("@especialidad", s.DoctorID);
            commands[2].Parameters.AddWithValue("@especialidad", s.HospitalID);

            return ExecuteNBasicCommand(commands);
        }

        public DataTable ComboBox()
        {
            query = @"  SELECT D.idDoctor AS id,P.name AS name
                        FROM Doctor D
                        INNER JOIN Person P ON D.idDoctor=P.idPerson
                        WHERE P.status=1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ComboBox2()
        {
            query = @" SELECT idHospital AS id,name
                       FROM Hospital
                       WHERE status=1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"  SELECT P.idPerson, P.name AS Nombre, P.lastName AS Apellido, P.secondLastName AS 'Segundo Apellido', P.phone AS Telefono, P.email AS Correo, S.speciality AS Specialidad, D.name AS 'Doctor Asignado', H.name AS 'Hospital Asignado'
                        FROM Student S
                        INNER JOIN Person P ON S.idStudent = P.idPerson
                        LEFT JOIN Hospital H ON S.idHospital = H.idHospital
                        LEFT JOIN Person D ON S.idDoctor = D.idPerson
                        WHERE P.status = 1
                        ORDER BY 2;";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update2(Student t, int id)
        {
            query = @"  UPDATE Person SET name=@name,lastName=@lastName,secondLastName=@secondLastName,phone=@phone,email=@email
                        WHERE idPerson=@id";

            string query2 = @"  UPDATE Student SET speciality=@speciality,idDoctor=@doctorID,idHospital=@HospitalID
                                WHERE idStudent=@id";

            //int id = int.Parse(GetGenerateIDTable("Person"));

            List<SqlCommand> commands = CreateBasicCommand2(query, query2);
            commands[0].Parameters.AddWithValue("@id", id);
            commands[0].Parameters.AddWithValue("@name", t.Name);
            commands[0].Parameters.AddWithValue("@lastName", t.LastName);
            commands[0].Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            commands[0].Parameters.AddWithValue("@phone", t.Phone);
            commands[0].Parameters.AddWithValue("@email", t.Email);
            

            commands[1].Parameters.AddWithValue("@id", id);
            commands[1].Parameters.AddWithValue("@speciality", t.Speciality);
            commands[1].Parameters.AddWithValue("@doctorID", t.DoctorID);
            commands[1].Parameters.AddWithValue("@hospitalID", t.HospitalID);

            try
            {
                return ExecuteNBasicCommand(commands);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Student t)
        {
            throw new NotImplementedException();
        }
    }
}
