using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Implementation
{
    public class GraphicsImpl : BaseImpl
    {
        public int ObtenerCantidadDoctores()
        {
            int cantidadDoctores = 0;
            query = "SELECT COUNT(*) FROM Doctor";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                command.Connection.Open();
                cantidadDoctores = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return cantidadDoctores;
        }


        public int ObtenerCantidadEstudiantes()
        {
            int cantidadDoctores = 0;
            query = "SELECT COUNT(*) FROM Student";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                command.Connection.Open();
                cantidadDoctores = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return cantidadDoctores;
        }

        public int ObtenerCantidadHospital()
        {
            int cantidadDoctores = 0;
            query = "SELECT COUNT(*) FROM Hospital";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                command.Connection.Open();
                cantidadDoctores = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return cantidadDoctores;
        }
    }
}
