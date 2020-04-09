using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameLog
{
	public class TextUserDataHandler
	{
        private string readFilePath;
        private string writeFilePath;

        private char delimiter = ';';

        private static int namePos = 0;
        private static int pwdPos = 1;
        private static int nGamesPos = 2;
        private static int winsPos = 3;
        private static int tiesPos = 4;
        private static int lossesPos = 5;

        private static readonly string idKey = "I";
        private static readonly string nameKey = "F";
        private static readonly string pwdKey = "P";
        private static readonly string nGamesKey = "NG";
        private static readonly string winsKey = "W";
        private static readonly string lossesKey = "L";
        private static readonly string tiesKey = "T";

        private List<Dictionary<string, string>> records;

        public List<Dictionary<string, string>> Records { get => records; set => records = value; }
        public string ReadFilePath { get => readFilePath; set => readFilePath = value; }
        public string WriteFilePath { get => writeFilePath; set => writeFilePath = value; }

        public static string NameKey => nameKey;

        public static string PwdKey => pwdKey;

        public static string NGamesKey => nGamesKey;

        public static string WinsKey => winsKey;

        public static string LossesKey => lossesKey;

        public static string TiesKey => tiesKey;

        public char Delimiter{ get => delimiter; set => delimiter = value; }

        /// <summary>
        /// Initialize TextDataReader and load records into memory
        /// </summary>
        /// <param name="readFilePath"></param>
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
        /// Writes all the records to the file
        /// </summary>
        public void UpdateAll()
        {
            FileStream fileStream = File.Create(WriteFilePath);
            foreach(Dictionary<string, string> record in Records)
            {
                string[] line = new string[6];
                line[namePos] = record[NameKey];
                line[nGamesPos] = record[NGamesKey];
                line[pwdPos] = record[PwdKey];
                line[winsPos] = record[WinsKey];
                line[lossesPos] = record[LossesKey];
                line[tiesPos] = record[TiesKey];

                string joinedLine = string.Join(Delimiter.ToString(), line);

                fileStream.Write(Encoding.ASCII.GetBytes(joinedLine), 0, joinedLine.Length);
            }
            fileStream.Close();
        }

        /// <summary>
        /// Append record to file
        /// </summary>
        /// <param name="record"></param>
        private void Append(Dictionary<string, string> record)
        {
            Records.Add(record);

            StreamWriter fileStream = File.AppendText(WriteFilePath);

            string[] line = new string[6];
            line[namePos] = record[NameKey];
            line[nGamesPos] = record[NGamesKey];
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
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>id of user's record if found; otherwise null</returns>
        public Nullable<int> login(string username, string password)
        {
            Nullable<int> id = null;

            if (!(Records is null))
            {
                Dictionary<string, string> userRecord = Records.Find(record => (record[NameKey] == username && record[PwdKey] == password));
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
        /// <param name="name"></param>
        /// <returns></returns>
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
        /// <param name="record"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="name"></param>
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
        /// <param name="record"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="password"></param>
        public void setPassword(int id, string password)
        {
            if (!(Records is null))
            {
                Records[id][PwdKey] = password;
            }
        }

        /// <summary>
        /// Tries to retrieve the number of games from a record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Nullable<int> getNumberOfGames(int id)
        {
            Nullable<int> nGames = null;

            if (!(Records is null))
            {
                nGames = int.Parse(Records[id][NGamesKey]);
            }

            return nGames;
        }

        /// <summary>
        /// Set the number of games of the user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nGames"></param>
        public void setNumberOfGames(int id, int nGames)
        {
            if (!(Records is null))
            {
                Records[id][NGamesKey] = nGames.ToString();
            }
        }

        /// <summary>
        /// Get the number of wins
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="wins"></param>
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
        /// <param name="record"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="losses"></param>
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
        /// <param name="record"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="ties"></param>
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
        /// <param name="record"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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
                    record[NGamesKey] = rawRecord[nGamesPos];
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
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="losses"></param>
        /// <param name="wins"></param>
        /// <param name="ties"></param>
        /// <returns>true if the record was inserted successfully; otherwise false</returns>
        public bool insert(string name, string password, int losses, int wins, int ties)
        {
            bool inserted = false;
            if (!nameExists(name))
            {
                Dictionary<string, string> record = new Dictionary<string, string>();
                record[TextUserDataHandler.idKey] = Records.Count.ToString();
                record[TextUserDataHandler.NameKey] = name;
                record[TextUserDataHandler.PwdKey] = password;
                record[TextUserDataHandler.TiesKey] = ties.ToString();
                record[TextUserDataHandler.WinsKey] = wins.ToString();
                record[TextUserDataHandler.LossesKey] = losses.ToString();
                record[TextUserDataHandler.NGamesKey] = (wins + losses + ties).ToString();

                Append(record);
                inserted = true;
            }

            return inserted;
        }
    }
}
