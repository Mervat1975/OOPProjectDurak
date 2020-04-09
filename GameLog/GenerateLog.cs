/*  GenerateLog.cs - Defines the Generate Log class
 *  Author:          Maheera Shariq
 *  Since:           April 2020 <update>
 */
using System;
using System.IO;

namespace GameLog
{
    public class GenerateLog
    {
        /// <summary>
        /// fileLocation - the location of the fileah
        /// </summary>
        public string fileLocation;

        /// <summary>
        /// writeLog - used to record the relevant game-play actions to a text-file log
        /// </summary>
        /// <param name="_logText"></param>
        public void writeLog(string _logText)
        {
            if (String.IsNullOrEmpty(fileLocation))
            {
                fileLocation = Path.Combine(System.IO.Path.GetDirectoryName(
                                        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Log.log");
                fileLocation = fileLocation.Replace("file:\\", "");
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(fileLocation, true))
            {
                file.WriteLine(DateTime.Now +":"+ _logText);
                file.Close();
            }
        }

        
    }
}
