/**
 * @author Oghenefejiro Abohweyere
 * @description Holds the class that allows working with text records
 * @since 2020-04-12
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace GameLog
{
    /// <summary>
    /// Provides the functionality to treat text files
    /// as data storage for user data.
    /// </summary>
	public class TextUserDataHandler
	{
        /// <summary>
        /// Where to read user data from
        /// </summary>
        private string readFilePath;

        /// <summary>
        /// Where to write user data to
        /// </summary>
        private string writeFilePath;

        /// <summary>
        /// Character/string that separates fields
        /// </summary>
        private char delimiter = ';';

        /// <summary>
        /// Position of the name in the record
        /// </summary>
        private static int namePos = 0;

        /// <summary>
        /// Position of the password in the record
        /// </summary>
        private static int pwdPos = 1;

        /// <summary>
        /// Position of the wins in the record
        /// </summary>
        private static int winsPos = 2;

        /// <summary>
        /// Position of the ties in the record
        /// </summary>
        private static int tiesPos = 3;

        /// <summary>
        /// Position of the losses in the record
        /// </summary>
        private static int lossesPos = 4;

        /// <summary>
        /// Key of the id in the dictionary that represents a record
        /// </summary>
        private static readonly string idKey = "I";

        /// <summary>
        /// Key of the name in the dictionary that represents a record
        /// </summary>
        private static readonly string nameKey = "User Name";

        /// <summary>
        /// Key of the password in the dictionary that represents a record
        /// </summary>
        private static readonly string pwdKey = "Password";

        /// <summary>
        /// Key of the wins in the dictionary that represents a record
        /// </summary>
        private static readonly string winsKey = "Wins";

        /// <summary>
        /// Key of the losses in the dictionary that represents a record
        /// </summary>
        private static readonly string lossesKey = "Losses";

        /// <summary>
        /// Key of the ties/draws in the dictionary that represents a record
        /// </summary>
        private static readonly string tiesKey = "Draws";

        /// <summary>
        /// List of all the records retrieved from the user data file
        /// </summary>
        private List<Dictionary<string, string>> records;

        /// <summary>
        /// List of all the records retrieved from the user data file
        /// </summary>
        public List<Dictionary<string, string>> Records { get => records; set => records = value; }

        /// <summary>
        /// Where to read user data from
        /// </summary>
        public string ReadFilePath { get => readFilePath; set => readFilePath = value; }

        /// <summary>
        /// Where to write user data to
        /// </summary>
        public string WriteFilePath { get => writeFilePath; set => writeFilePath = value; }

        /// <summary>
        /// Key of the name in the dictionary that represents a record
        /// </summary>
        public static string NameKey => nameKey;

        /// <summary>
        /// Key of the password in the dictionary that represents a record
        /// </summary>
        public static string PwdKey => pwdKey;

        /// <summary>
        /// Key of the wins in the dictionary that represents a record
        /// </summary>
        public static string WinsKey => winsKey;

        /// <summary>
        /// Key of the losses in the dictionary that represents a record
        /// </summary>
        public static string LossesKey => lossesKey;

        /// <summary>
        /// Key of the ties/draws in the dictionary that represents a record
        /// </summary>
        public static string TiesKey => tiesKey;

        /// <summary>
        /// Character/string that separates fields
        /// </summary>
        public char Delimiter{ get => delimiter; set => delimiter = value; }

        /// <summary>
        /// Initialize TextDataReader and load records into memory
        /// </summary>
        /// <param name="readFilePath">path of the read file</param>
        public TextUserDataHandler(string readFilePath = null, string writeFilePath = null)
        {
            this.ReadFilePath = readFilePath;
            this.WriteFilePath = writeFilePath;
            Records = getRecords();
            if (Records is null)
            {
                Records = new List<Dictionary<string, string>>();
            }
        }

        /// <summary>
        /// Hash the password
        /// </summary>
        /// <param name="plainPassword">unhashed password</param>
        /// <returns>hashed password</returns>
        private string hashPassword(string plainPassword)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            byte[] hashBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(plainPassword));

            sha1.Clear();
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Writes all the records to the file
        /// </summary>
        public void UpdateAll()
        {
            FileStream fileStream = File.Create(WriteFilePath);
            foreach(Dictionary<string, string> record in Records)
            {
                string[] line = new string[5];
                line[namePos] = record[NameKey];
                line[pwdPos] = record[PwdKey];
                line[winsPos] = record[WinsKey];
                line[lossesPos] = record[LossesKey];
                line[tiesPos] = record[TiesKey];

                string joinedLine = string.Join(Delimiter.ToString(), line)+"\n";

                fileStream.Write(Encoding.ASCII.GetBytes(joinedLine), 0, joinedLine.Length);
            }
            fileStream.Close();
        }

        /// <summary>
        /// Append record to file
        /// </summary>
        /// <param name="record">user record</param>
        private void Append(Dictionary<string, string> record)
        {
            Records.Add(record);

            StreamWriter fileStream = File.AppendText(WriteFilePath);

            string[] line = new string[6];
            line[namePos] = record[NameKey];
            line[pwdPos] = record[PwdKey];
            line[winsPos] = record[WinsKey];
            line[lossesPos] = record[LossesKey];
            line[tiesPos] = record[TiesKey];

            string joinedLine = string.Join(Delimiter.ToString(), line);

            fileStream.WriteLine(joinedLine);

            fileStream.Close();
        }

        /// <summary>
        /// Refresh/reload records in case something has changed
        /// </summary>
        public void reload()
        {
            Records = getRecords();
        }

        /// <summary>
        /// Tries to log the user in.
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="password">user's password</param>
        /// <returns>id of user's record if found; otherwise null</returns>
        public Nullable<int> login(string username, string password)
        {
            Nullable<int> id = null;

            if (!(Records is null))
            {
                Dictionary<string, string> userRecord = Records.Find(record => (record[NameKey] == username && record[PwdKey] == hashPassword(password)));
                if(!(userRecord is null))
                {
                    id = getId(userRecord);
                }
            }
            return id;
        }

        /// <summary>
        /// Returns if the name exists
        /// </summary>
        /// <param name="name">user name to check</param>
        /// <returns>true if the user name exists; otherwise false</returns>
        public bool nameExists(string name)
        {
            bool exists = false;
            if(!(Records is null))
            {
                Dictionary<string, string> userRecord = Records.Find(record =>record[NameKey] == name);
                if(!(userRecord is null))
                {
                    exists = true;
                }
            }

            return exists;
        }

        /// <summary>
        /// Get name from record
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>name associated with the supplied user id</returns>
        public string getName(int id)
        {
            string name = null;
            if(!(Records is null))
            {
                name = Records[id][NameKey];
            }

            return name;
        }

        /// <summary>
        /// Set name of record with the supplied id
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="name">name to associate with the supplied id</param>
        public void setName(int id, string name)
        {
            if (!(Records is null))
            {
                Records[id][NameKey] = name;
            }
        }

        /// <summary>
        /// Get password from record
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>password of the user with the user id</returns>
        public string getPassword(int id)
        {
            string password = null;
            if (!(Records is null))
            {
                password = Records[id][PwdKey];
            }

            return password;
        }

        /// <summary>
        /// Set the password of the id of the record
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="password">new password</param>
        public void setPassword(int id, string password)
        {
            if (!(Records is null))
            {
                Records[id][PwdKey] = hashPassword(password);
            }
        }

        /// <summary>
        /// Tries to retrieve the number of games from a record
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Number of games played by the user associated with the id if the id exists: otherwise null</returns>
        public Nullable<int> getNumberOfGames(int id)
        {
            Nullable<int> nGames = null;

            if (!(Records is null))
            {
                nGames = getWins(id) + getLosses(id) + getTies(id);
            }

            return nGames;
        }

        /// <summary>
        /// Get the number of wins
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Number of wins if the user exists; otherwise null</returns>
        public Nullable<int> getWins(int id)
        {
            Nullable<int> wins = null;

            if (!(Records is null))
            {
                wins = int.Parse(Records[id][WinsKey]);
            }

            return wins;
        }

        /// <summary>
        /// Set the number of wins of the record with the supplied id
        /// </summary>
        /// <param name="id">user name</param>
        /// <param name="wins">new number of wins</param>
        public void setWins(int id, int wins)
        {
            if (!(Records is null))
            {
                Records[id][WinsKey] = wins.ToString();
            }
        }

        /// <summary>
        /// Get the number of losses
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Number of losses if the user exists; otherwise null</returns>
        public Nullable<int> getLosses(int id)
        {
            Nullable<int> losses = null;

            if (!(Records is null))
            {
                losses = int.Parse(Records[id][LossesKey]);
            }

            return losses;
        }

        /// <summary>
        /// Set losses of record with the supplied id
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="losses">new number of losses</param>
        public void setLosses(int id, int losses)
        {
            if (!(Records is null))
            {
                Records[id][LossesKey] = losses.ToString();
            }
        }

        /// <summary>
        /// Get number of ties from records
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Number of ties if the user exists; otherwise null</returns>
        public Nullable<int> getTies(int id)
        {
            Nullable<int> ties = null;
            if (!(Records is null))
            {
                ties = int.Parse(Records[id][TiesKey]);
            }

            return ties;
        }

        /// <summary>
        /// Set the number of ties for the record with the supplied id
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="ties">new number of ties/draws</param>
        public void setTies(int id, int ties)
        {
            if (!(Records is null))
            {
                Records[id][TiesKey] = ties.ToString();
            }
        }

        /// <summary>
        /// Get the id of the user which is also the position in "Records"
        /// </summary>
        /// <param name="record">user record</param>
        /// <returns>id if the record is not null; otherwise null</returns>
        public Nullable<int> getId(Dictionary<string, string> record)
        {
            Nullable<int> id = null;
            if (!(record is null))
            {
                id = int.Parse(record[idKey]);
            }

            return id;
        }

        /// <summary>
        /// Gets the records from the text file
        /// </summary>
        /// <returns>list of all retrieved records</returns>
        public List<Dictionary<string, string>> getRecords()
        {
            List<Dictionary<string, string>> mirrorRecords = null;

            if(!(ReadFilePath is null))
            {
                mirrorRecords = new List<Dictionary<string, string>>();
                if (!File.Exists(ReadFilePath))
                {
                    FileStream stream = File.Create(ReadFilePath);
                    stream.Close();
                }
                int count = 0;
                foreach(string line in File.ReadLines(this.ReadFilePath))
                {
                    string[] rawRecord = line.Split(this.Delimiter);
                    Dictionary<string, string> record = new Dictionary<string, string>();
                    record[NameKey] = rawRecord[namePos];
                    record[PwdKey] = rawRecord[pwdPos];
                    record[WinsKey] = rawRecord[winsPos];
                    record[LossesKey] = rawRecord[lossesPos];
                    record[TiesKey] = rawRecord[tiesPos];
                    record[idKey] = count.ToString();

                    count++;
                    mirrorRecords.Add(record);
                }
            }
            return mirrorRecords;
        }

        /// <summary>
        /// Inserts another record into the file
        /// </summary>
        /// <param name="name">user name of the user to insert</param>
        /// <param name="password">plain password of the user to insert</param>
        /// <param name="losses">number of losses of the user to inser</param>
        /// <param name="wins">number of wins of the user to insert</param>
        /// <param name="ties">number of ties/draws of the user to insert</param>
        /// <returns>true if the record was inserted successfully; otherwise false</returns>
        public bool insert(string name, string password, int losses, int wins, int ties)
        {
            bool inserted = false;
            if (!nameExists(name))
            {
                Dictionary<string, string> record = new Dictionary<string, string>();
                record[TextUserDataHandler.idKey] = Records.Count.ToString();
                record[TextUserDataHandler.NameKey] = name;
                record[TextUserDataHandler.PwdKey] = hashPassword(password);
                record[TextUserDataHandler.TiesKey] = ties.ToString();
                record[TextUserDataHandler.WinsKey] = wins.ToString();
                record[TextUserDataHandler.LossesKey] = losses.ToString();

                Append(record);
                inserted = true;
            }

            return inserted;
        }
    }
}
