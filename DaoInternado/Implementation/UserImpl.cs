using DaoInternado.Interfaces;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace DaoInternado.Implementation
{
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(User t)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(User t)
        {
            query = @"  INSERT INTO [User] (idPerson,users,password,role)
                        VALUES (@idUser,@username,HASHBYTES('MD5',@password),@role)";

            int id = GetLastPersonID();

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idUser", id);
            command.Parameters.AddWithValue("@username", t.UserName);
            command.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@role", t.Role);

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

        public DataTable Login(string userName, string password)
        {
            query = @" SELECT idPerson,users,password,role
                       FROM [User]
                       WHERE users=@username AND password=HASHBYTES('MD5',@password)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int ChangePassword(User u)
        {
            query = @"UPDATE [User] SET password=HASHBYTES('MD5',@newPassword)
                      WHERE idPerson = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@newPassword",u.Password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@id", SessionClass.SessionID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable Exists(string email)
        {
            string query = @"SELECT P.email
                                    FROM Person P
                                    INNER JOIN [User] U ON U.idPerson=P.idPerson
                                    WHERE P.email=@email AND P.status=1
";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@email", email);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ForgotPassword(string email, string password)
        {
            query = @"  UPDATE [User]
                        SET password = HASHBYTES('MD5',@password)
                        WHERE idPerson IN (SELECT p.idPerson FROM Person AS p WHERE p.email = @email);";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            //command.Parameters.AddWithValue("@newPassw", newPassw).SqlDbType = SqlDbType.VarChar;

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
