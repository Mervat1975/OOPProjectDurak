using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLog;

namespace TestTextDataHandler
{
	class Program
	{
		static void Main(string[] args)
		{
			string writeFile = "out.txt";
			string readFile = "out.txt";

			Dictionary<string, string> record = new Dictionary<string, string>();

			TextUserDataHandler userDataHandler = new TextUserDataHandler(readFile, writeFile);

			//userDataHandler.Append(record);

			userDataHandler.reload();
			bool exists = userDataHandler.nameExists("Theodore");

			int? id = userDataHandler.login("Roll", "akin");

			Console.WriteLine("User Theodore:  " + exists);
			Console.WriteLine("User David: " + userDataHandler.nameExists("David"));
			Console.WriteLine("Theodore id: " + id);

			Console.ReadKey();
		}
	}
}
