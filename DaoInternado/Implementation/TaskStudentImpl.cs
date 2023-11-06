using DaoInternado.Interfaces;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DaoInternado.Implementation
{
    public class TaskStudentImpl : BaseImpl, ITaskStudent
    {
        public int Delete(TaskStudent t)
        {
            throw new NotImplementedException();
        }

        public int DeleteTask(int t)
        {
            query = @"UPDATE TaskStudent SET statusTask='Rechazada'
                      WHERE idTaskStudent=@id";
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

        public TaskStudent GetTaskStudent(int id)
        {
            TaskStudent t = null;
            query = @"SELECT idTaskStudent, description,expireDate
                    FROM TaskStudent
                    WHERE idTaskStudent = @id AND estado = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new TaskStudent(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        DateTime.Parse(table.Rows[0][2].ToString())
                        );
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar obtener los datos de TASKSTUDENT", ex);
            }
            return t;
        }

        public TaskStudent GetTaskStudentDelete(int id)
        {
            TaskStudent t = null;
            query = @"SELECT idTaskStudent, description,date,expireDate, idStudent
                    FROM TaskStudent
                    WHERE idTaskStudent = @id AND estado = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new TaskStudent(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        DateTime.Parse(table.Rows[0][2].ToString()),
                        DateTime.Parse(table.Rows[0][3].ToString()),
                        int.Parse(table.Rows[0][4].ToString()));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar obtener los datos de TASKSTUDENT", ex);
            }
            return t;
        }

        public TaskStudent Get(int id)
        {
            TaskStudent t = null;
            query = @"SELECT ts.idTaskStudent, ts.description, ts.date, ts.expireDate, ts.image, ts.fileStudent, ts.statusTask
              FROM TaskStudent ts
              WHERE ts.idTaskStudent=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    int taskId = int.Parse(table.Rows[0]["idTaskStudent"].ToString());
                    string description = table.Rows[0]["description"].ToString();
                    DateTime date = DateTime.Parse(table.Rows[0]["date"].ToString());
                    DateTime expireDate = DateTime.Parse(table.Rows[0]["expireDate"].ToString());
                    byte[] image = table.Rows[0]["image"] != DBNull.Value ? (byte[])table.Rows[0]["image"] : null;
                    byte[] fileStudent = table.Rows[0]["fileStudent"] != DBNull.Value ? (byte[])table.Rows[0]["fileStudent"] : null;
                    string statusTask = table.Rows[0]["statusTask"].ToString();
                    /*int idStudent = int.Parse(table.Rows[0]["idStudent"].ToString());
                    int idDoctor = int.Parse(table.Rows[0]["idDoctor"].ToString());*/
                    t = new TaskStudent(taskId, description, date, expireDate, image, fileStudent, statusTask/*, idDoctor, idStudent0*/);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;

        }


        /*public TaskStudent Get(int id)
        {
            TaskStudent t= null;
            query = @"  SELECT ts.idTaskStudent,ts.description,ts.date,ts.expireDate,ts.statusTask,
                        d.name,s.name
                        FROM taskStudent ts
                        INNER JOIN Person d ON ts.idDoctor = d.idPerson
                        INNER JOIN Person s ON ts.idStudent = s.idPerson
                        WHERE ts.idTaskStudent=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new TaskStudent(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), 
                        DateTime.Parse(table.Rows[0][2].ToString()),DateTime.Parse(table.Rows[0][3].ToString()),
                        //table.Rows[0][4] != DBNull.Value ? (byte[])table.Rows[0][4] : null,
                        //table.Rows[0][5] != DBNull.Value ? (byte[])table.Rows[0][5] : null,
                        //table.Rows[0][4].ToString(), table.Rows[0][5].ToString(),
                        //(byte[])table.Rows[0][4], (byte[])table.Rows[0][5],
                        table.Rows[0][4].ToString(),
                        int.Parse(table.Rows[0][5].ToString()), 
                        int.Parse(table.Rows[0][6].ToString()));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return t;
        }*/

        public int Insert(TaskStudent t)
        {
            query = @"  INSERT INTO TaskStudent (description,date,expireDate,statusTask,idDoctor,idStudent)
                        VALUES (@description,@date,@expireDate,@statusTask,@idDoctor,@idStudent)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@date", t.Date);
            command.Parameters.AddWithValue("@expireDate", t.ExpireDate);
            command.Parameters.AddWithValue("@statusTask", t.Status);
            command.Parameters.AddWithValue("@idDoctor", t.IdDoctor);
            command.Parameters.AddWithValue("@idStudent", t.IdStudent);

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
            throw new NotImplementedException();
        }

        public DataTable SelectStudent(int id)
        {
            query = @"  SELECT ts.idTaskStudent, ts.description AS Descripcion,ts.date AS Fecha,ts.expireDate AS 'Fecha de Expiracion',ts.image AS Imagen,ts.fileStudent AS Archivo,
                        ts.statusTask AS 'Estado Tarea',d.name AS 'Doctor Asignado',s.name AS 'Estudiante Asignado'
                        FROM taskStudent AS ts
                        INNER JOIN Person AS d ON ts.idDoctor = d.idPerson
                        INNER JOIN Person AS s ON ts.idStudent = s.idPerson
                        WHERE ts.idStudent=@id AND ts.statusTask !='Rechazada'
                        ORDER BY 2";
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
        public DataTable ReportStudent()
        {
            query = @"  SELECT MAX(ts.idTaskStudent) AS idTaskStudent,MAX(s.name) AS 'Estudiante Asignado', MAX(ts.description) AS Descripcion, MAX(ts.statusTask) AS 'Estado Tarea',
                            MAX(d.name) AS 'Doctor Asignado' , MAX(h.name) AS 'Hospital Asignado',
                            SUM(CASE WHEN ts.statusTask = 'Terminada' THEN 1 ELSE 0 END) AS 'Tareas Terminadas'
	                        FROM taskStudent AS ts
	                        INNER JOIN Person d ON ts.idDoctor = d.idPerson
	                        INNER JOIN Person s ON ts.idStudent = s.idPerson
	                        INNER JOIN Student st ON st.idStudent = s.idPerson
	                        INNER JOIN Hospital h ON st.idHospital = h.idHospital
	                        GROUP BY s.idPerson
	                        ORDER BY 2";
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


        public DataTable SelectCompletedTask(int id)
        {
            query = @"  SELECT ts.idTaskStudent, ts.description AS Descripcion,ts.date AS Fecha,ts.expireDate AS 'Fecha de Expiracion',ts.image AS Imagen,ts.fileStudent AS Archivo,
                        ts.statusTask AS 'Estado Tarea',d.name AS 'Doctor Asignado',s.name AS 'Estudiante Asignado'
                        FROM taskStudent AS ts
                        INNER JOIN Person AS d ON ts.idDoctor = d.idPerson
                        INNER JOIN Person AS s ON ts.idStudent = s.idPerson
                        WHERE ts.idStudent=@id AND ts.statusTask ='Terminada'
                        ORDER BY 2";
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



        public DataTable SelectAllStudent()
        {
            query = @"  SELECT ts.idTaskStudent, ts.description AS Descripcion,ts.date AS Fecha,ts.expireDate AS 'Fecha de Expiracion',ts.image AS Imagen,ts.fileStudent AS Archivo,
                        ts.statusTask AS 'Estado Tarea',d.name AS 'Doctor Asignado',s.name AS 'Estudiante Asignado'
                        FROM taskStudent AS ts
                        INNER JOIN Person AS d ON ts.idDoctor = d.idPerson
                        INNER JOIN Person AS s ON ts.idStudent = s.idPerson
                        
                        ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            //command.Parameters.AddWithValue("@id", id);

            try
            {
                return ExecuteDataTableCommand(command);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Update(TaskStudent t)
        {
            query = @"UPDATE TaskStudent 
                     SET description=@description,expireDate=@expireDate,updateDate=CURRENT_TIMESTAMP
                     WHERE idTaskStudent = @id AND estado = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@expireDate", t.ExpireDate);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateStart(int t)
        {
            query = @"UPDATE TaskStudent SET statusTask='Aceptada',dateAccepted=CURRENT_TIMESTAMP
                      WHERE idTaskStudent=@id";
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


        public int UpdateTask(int id,byte[] img, byte[] file)
        {
            query = @"UPDATE TaskStudent SET statusTask='Terminada',image=@image,fileStudent=@fileStudent
                      WHERE idTaskStudent=@id";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@image",img);
            command.Parameters.AddWithValue("@fileStudent", file);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //Consulta por estado de la tarea
        public DataTable SelectStatus(string status)
        {
            query = @"SELECT ts.idTaskStudent, ts.description AS Descripcion,ts.date AS Fecha,ts.expireDate AS 'Fecha de Expiracion',ts.image AS Imagen,ts.fileStudent AS Archivo,
                        ts.statusTask AS 'Estado Tarea',d.name AS 'Doctor Asignado',s.name AS 'Estudiante Asignado'
                        FROM taskStudent AS ts
                        INNER JOIN Person AS d ON ts.idDoctor = d.idPerson
                        INNER JOIN Person AS s ON ts.idStudent = s.idPerson
						WHERE ts.statusTask = @statusTask
						ORDER BY 2";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@statusTask", status);

            try
            {
                return ExecuteDataTableCommand(command);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetTask(int id)
        {
            query = @"SELECT ts.idTaskStudent, ts.description AS Descripcion,ts.date AS Fecha,ts.expireDate AS 'Fecha de Expiracion',ts.image AS Imagen,ts.fileStudent AS Archivo,
                        ts.statusTask AS 'Estado Tarea',s.name AS 'Estudiante Asignado'
                        FROM taskStudent AS ts
                        INNER JOIN Person AS d ON ts.idDoctor = d.idPerson
                        INNER JOIN Person AS s ON ts.idStudent = s.idPerson
                        WHERE ts.idDoctor=@id
                        ORDER BY 2";

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


        public DataTable selectAllStudentforDoctor(int id)
        {

            query = @"SELECT ts.idTaskStudent, ts.description AS Descripcion,ts.date AS Fecha,ts.expireDate AS 'Fecha de Expiracion',ts.image AS Imagen,ts.fileStudent AS Archivo,
                        ts.statusTask AS 'Estado Tarea',d.name AS 'Doctor Asignado',s.name AS 'Estudiante Asignado'
                        FROM taskStudent AS ts
                        INNER JOIN Person AS d ON ts.idDoctor = d.idPerson
                        INNER JOIN Person AS s ON ts.idStudent = s.idPerson
                        WHERE ts.idDoctor=@id
                        ORDER BY 2";

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

        public DataTable selectbyName(string name)
        {
            query = @"SELECT MAX(ts.idTaskStudent) AS idTaskStudent, MAX(s.name) AS 'Estudiante Asignado',
                       MAX(ts.description) AS Descripcion, MAX(ts.statusTask) AS 'Estado Tarea', 
                       MAX(d.name) AS 'Doctor Asignado', MAX(h.name) AS 'Hospital Asignado', 
                       SUM(CASE WHEN ts.statusTask = 'Terminada' THEN 1 ELSE 0 END) AS 'Tareas Terminadas' 
                       FROM taskStudent AS ts
                       INNER JOIN Person d ON ts.idDoctor = d.idPerson
                       INNER JOIN Person s ON ts.idStudent = s.idPerson
                       INNER JOIN Student st ON st.idStudent = s.idPerson
                       INNER JOIN Hospital h ON st.idHospital = h.idHospital
                       WHERE s.name = @name
                       GROUP BY s.idPerson 
                       ORDER BY 2";

            // WHERE s.name LIKE @name + '%' "" +

            SqlCommand commnad = CreateBasicCommand(query);
            commnad.Parameters.AddWithValue ("@name", name);

            try
            {
                return ExecuteDataTableCommand(commnad);

            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
