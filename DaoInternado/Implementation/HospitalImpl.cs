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
    public class HospitalImpl : BaseImpl, IHospital
    {
        public int Delete(Hospital h)
        {
            query = @"UPDATE Hospital SET status=0,lastUpdate=CURRENT_TIMESTAMP
                      WHERE idHospital=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", h.HospitalID);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable LoadComboBoxHospital()
        {
            query = @"SELECT idHospital, name
                      FROM Hospital
                      WHERE status = 1";

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


        public DataTable GetReportHospital(int id)
        {
            query = @"SELECT
                            H.idHospital,
                            H.name AS Hospital,
                            H.description AS Direccion,
                            H.phone AS Telefono,
                            H.email AS 'Correo Electronico',
                            ISNULL(P.name, 'Sin Doctor') AS 'Doctor Cabezera',
                            ISNULL(COUNT(S.idStudent), 0) AS 'Total de Estudiantes Asignados'
                        FROM Hospital H
                        INNER JOIN Doctor D ON D.idHospital = H.idHospital
                        LEFT JOIN Student S ON S.idHospital = H.idHospital AND S.idDoctor = D.idDoctor
                        INNER JOIN Person P ON P.idPerson = D.idDoctor
                        WHERE H.status = 1 AND H.idHospital = @id
                        GROUP BY
                            H.idHospital, H.name, H.description, H.phone, H.email, D.idDoctor, P.name
                        ORDER BY 1;";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                return ExecuteDataTableCommand(command);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectReport()
        {
            query = @"SELECT
                            H.idHospital,
                            H.name AS Hospital,
                            H.description AS Direccion,
                            H.phone AS Telefono,
                            H.email AS 'Correo Electronico',
                            P.name AS 'Doctor Cabezera',
                            ISNULL(COUNT(S.idStudent), 0) AS 'Total de Estudiantes Asignados'
                        FROM Hospital H
                        INNER JOIN Doctor D ON D.idHospital = H.idHospital
                        LEFT JOIN Student S ON S.idHospital = H.idHospital AND S.idDoctor = D.idDoctor
                        INNER JOIN Person P ON P.idPerson = D.idDoctor
                        WHERE H.status = 1
                        GROUP BY
                            H.idHospital, H.name, H.description, H.phone, H.email, D.idDoctor, P.name
                        ORDER BY 1;";

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


        public Hospital GetHospital(int id)
        {
            Hospital h = null;
            query = @"SELECT idHospital, name, latitude, longitude, phone, description, email, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP) 
                    FROM Hospital
                    WHERE idHospital = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    h = new Hospital(int.Parse(table.Rows[0][0].ToString()), 
                        table.Rows[0][1].ToString(), 
                        float.Parse(table.Rows[0][2].ToString()),
                        float.Parse(table.Rows[0][3].ToString()), 
                        int.Parse(table.Rows[0][4].ToString()), 
                        table.Rows[0][5].ToString(),
                        table.Rows[0][6].ToString(),
                        byte.Parse(table.Rows[0][7].ToString()),
                        DateTime.Parse(table.Rows[0][8].ToString()), 
                        DateTime.Parse(table.Rows[0][9].ToString()));

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return h;
        }

        public int Insert(Hospital h)
        {
            query = @"INSERT INTO Hospital([name], latitude, longitude, phone,[description],email)
                      VALUES (@name, @latitude, @longitude, @phone, @description, @email)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", h.NameHospital );
            command.Parameters.AddWithValue("@latitude", h.Latitude);
            command.Parameters.AddWithValue("@longitude", h.Longitude );
            command.Parameters.AddWithValue("@phone", h.Phone );
            command.Parameters.AddWithValue("@description",h.Description );
            command.Parameters.AddWithValue("@email", h.Email);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT idHospital, name AS 'Nombre del Hospital', latitude AS 'Latitud', longitude AS 'Longitud', phone AS 'Telefono', description AS 'Descripcion del Hospital', email AS 'Correo Electronico' 
                    FROM Hospital
                    WHERE status = 1
                    ORDER BY 1 DESC";
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

        public int Update(Hospital h)
        {
            query = @"UPDATE Hospital 
                     SET name=@name,latitude=@latitude,longitude=@longitude,phone=@phone,[description]=@description,email=@email,lastUpdate=CURRENT_TIMESTAMP
                     WHERE idHospital = @id AND [status]=1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", h.HospitalID);
            command.Parameters.AddWithValue("@name", h.NameHospital);
            command.Parameters.AddWithValue("@latitude", h.Latitude);
            command.Parameters.AddWithValue("@longitude", h.Longitude);
            command.Parameters.AddWithValue("@phone", h.Phone);
            command.Parameters.AddWithValue("@description", h.Description);
            command.Parameters.AddWithValue("@email", h.Email);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetReportForNameHospitalREPORT()
        {
            query = @"SELECT
                        H.idHospital,
                        H.name AS Hospital,
                        P.name AS 'Doctor Cabezera',
                        SP.name AS 'Estudiantes Asignados'
                        FROM Hospital H
                        INNER JOIN Doctor D ON D.idHospital = H.idHospital
                        LEFT JOIN Student S ON S.idHospital = H.idHospital AND S.idDoctor = D.idDoctor
                        INNER JOIN Person P ON P.idPerson = D.idDoctor
                        INNER JOIN Person SP ON SP.idPerson = S.idStudent
                        WHERE H.status = 1
                        GROUP BY
                        H.idHospital, H.name, P.name,SP.name
                        ORDER BY 1;";

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
    }
}

