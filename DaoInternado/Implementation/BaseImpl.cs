using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoInternado.Model;

namespace DaoInternado.Implementation
{
    public class BaseImpl
    {
        string connectionString = @"workstation id=dbInternado.mssql.somee.com;packet size=4096;user id=JayLoKing_SQLLogin_1;pwd=trt8r1wjwc;data source=dbInternado.mssql.somee.com;persist security info=False;initial catalog=dbInternado;";
        //string connectionString = "Server = LAPTOP-AOP1NU2T; Database=dbInternado;User Id = sa; Password=Rover";

        internal string query = "";
        public SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }

        public string GetGenerateIDTable(string table)
        {
            query = "SELECT IDENT_CURRENT('" + table + "') + IDENT_INCR('" + table + "')";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                command.Connection.Open();
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int GetLastPersonID()
        {
            string query = "SELECT MAX(idPerson) FROM [Person]";
            int lastID = 0;

            SqlCommand command = CreateBasicCommand(query);
            try
            {
                command.Connection.Open();
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    lastID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return lastID;
        }


        public SqlCommand CreateBasicCommand(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            return command;
        }

        public List<SqlCommand> CreateBasicCommand2(string sql1, string sql2)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command1 = new SqlCommand(sql1, connection);
            commands.Add(command1);

            SqlCommand command2 = new SqlCommand(sql2, connection);
            commands.Add(command2);

            return commands;
        }

        public List<SqlCommand> CreateBasicCommand3(string sql1, string sql2,string sql3)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command1 = new SqlCommand(sql1, connection);
            commands.Add(command1);

            SqlCommand command2 = new SqlCommand(sql2, connection);
            commands.Add(command2);

            SqlCommand command3 = new SqlCommand(sql3, connection);
            commands.Add(command3);

            return commands;
        }

        public int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public int ExecuteNBasicCommand(List<SqlCommand> commands)
        {
            SqlCommand command0 = commands[0];
            int n = 0;
            try
            {
                command0.Connection.Open();
                foreach (SqlCommand item in commands)
                {
                    n += item.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command0.Connection.Close();
            }
            return n;
        }

        public DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                command.Connection.Close();
            }

            return table;
        }
    }
}
