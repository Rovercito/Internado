using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Implementation
{
    public class ReportImpl : BaseImpl
    {

        public DataTable reportDoctor()
        {
            query = @"SELECT  P.name AS Doctor, P1.name as Estudiante,  H.name as Hospital, TS.statusTask as Estado,
                              TS.description as Descripción, TS.image as Imagen, TS.fileStudent as Archivo 
                            FROM Doctor D  
                            LEFT JOIN Person P ON D.idDoctor = P.idPerson
                            LEFT JOIN Student S ON D.idDoctor = S.idDoctor
                            LEFT JOIN Person P1 ON S.idStudent = P1.idPerson
                            LEFT JOIN Hospital H ON D.idHospital = H.idHospital
                            LEFT JOIN TaskStudent TS ON S.idStudent = TS.idStudent
                            GROUP BY P.name, P1.name, H.name, TS.statusTask, TS.description, TS.image, TS.fileStudent";

            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
            }catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable reportDoctorbyName(string nameDoctor)
        {
             string query = @"SELECT  P.name AS Doctor, P1.name as Estudiante,  H.name as Hospital, TS.statusTask as Estado,
                              TS.description as Descripción, TS.image as Imagen, TS.fileStudent as Archivo 
                            FROM Doctor D  
                            LEFT JOIN Person P ON D.idDoctor = P.idPerson
                            LEFT JOIN Student S ON D.idDoctor = S.idDoctor
                            LEFT JOIN Person P1 ON S.idStudent = P1.idPerson
                            LEFT JOIN Hospital H ON D.idHospital = H.idHospital
                            LEFT JOIN TaskStudent TS ON S.idStudent = TS.idStudent
                            WHERE P.name = @nameDoctor
                            GROUP BY P.name, P1.name, H.name, TS.statusTask, TS.description, TS.image, TS.fileStudent";


            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nameDoctor", nameDoctor);

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
