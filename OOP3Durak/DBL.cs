using System;

using CardLib;
using System.Data;
using System.Data.SqlClient;
namespace OOP3Durak
{
    class DBL

    {
        #region "Connection String"

        /// <summary>
        /// Return connection string
        /// </summary>
        /// <returns>Connection string</returns>
        private static string GetConnectionString()

        {
            String conString = "";
            int index;
            index = AppDomain.CurrentDomain.BaseDirectory.ToString().IndexOf("bin");

            string dataFileDir = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index);
            //conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            //    dataFileDir + "App_Data\\DurakDatabase.mdf;Integrated Security=True; Connect Timeout=30";
            return conString;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Function used to select one player from database, uses loginId as the primary key
        /// </summary>
        /// <param name="userName">an  userName stored in the database</param>
        /// <param name="password">a password stored in the database</param>
        /// <returns>a worker object</returns>
        internal static Player Login(string userName, string password)
        {
            // Declare new Player object
            Player returnPlayer = null;

            // Declare new SQL connection
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());

            // Create new SQL command
            SqlCommand command = new SqlCommand("SELECT  * FROM [Player] WHERE [userName] = '" + userName + "' and [password]= '"+password+ "'", dbConnection);

            // Try to connect to the database, create a datareader. If successful, read from the database and fill created row
            // with information from matching record
            try
            {
                dbConnection.Open();
                IDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    returnPlayer = new Player(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5));
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("A database error has been encountered -Database Error: " + ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }

            // Return the populated row
            return returnPlayer;

        }

        /// <summary>
        /// Function to add a new Player to the database
        /// </summary>
        /// <param name="insertPlayer">a worker object to be inserted</param>
        /// <returns>true if successful</returns>
        internal static bool InsertNewRecord(Player insertPlayer)
        {
            // Create return value
            bool returnValue = false;
            //defult value for number of game and durak
            const string DefaultNumberofGame = "0";
            const string DefaultNumberOfDurak = "0";
             
            // Declare the connection
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());
   
            // Create new SQL command and assign it paramaters
            SqlCommand command = new SqlCommand("INSERT INTO Player ([UserName], [Password], [NumberOfGame], [NumberOfDurak], [EmailAddress]) "+
                "VALUES( @userName, @password, @numberofGame, @numberOfdurak, @emailAddress)", dbConnection);
           
            command.Parameters.AddWithValue("@userName", insertPlayer.UserName);
            command.Parameters.AddWithValue("@password", insertPlayer.Password);
            command.Parameters.AddWithValue("@numberofGame", DefaultNumberofGame);
            command.Parameters.AddWithValue("@numberOfdurak", DefaultNumberOfDurak);
            command.Parameters.AddWithValue("@emailAddress", insertPlayer.EmailAddress);


            // Try to insert the new record, return result
            try
            {
                dbConnection.Open();
                returnValue = (command.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
                throw new Exception("A database error has been encountered-Database Error: " + ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }

            // Return the true if this worked, false if it failed
            return returnValue;
        }


        #endregion
    }
}
