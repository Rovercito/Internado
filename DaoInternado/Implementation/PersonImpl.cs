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
    public class PersonImpl : BaseImpl, IPerson
    {
        public int Delete(Person t)
        {
            query = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
                      WHERE idPerson=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.IdPerson);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Person Get(int id)
        {
            Person p = null;
            query = @"SELECT id,name,lastName,secondLastName,phone,email,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP)
                      FROM Person
                      WHERE idPerson=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPerson", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    p = new Person(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(), int.Parse(table.Rows[0][4].ToString()), table.Rows[0][5].ToString(),
                        byte.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString()), DateTime.Parse(table.Rows[0][8].ToString()));

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return p;
        }

        public int Insert(Person t)
        {
            query = @"INSERT INTO Person (name,lastName,secondLastName,phone,email)
                      VALUES(@name,@lastName,@secondLastName,@phone,@email)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@email", t.Email);

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
            query = @"SELECT idPerson,name AS Nombre,lastName AS Apellido,secondLastName AS 'Segundo Apellido',phone AS Telefono, email AS Correo
                      FROM Person
                      WHERE status=1
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

        public int Update(Person t)
        {
            query = @"UPDATE Person SET name=@name,lastName=@lastName,secondLastName=@secondLastName,phone=@phone,email=@email,lastUpdate=CURRENT_TIMESTAMP
                     WHERE idPerson=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@id", t.IdPerson);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
