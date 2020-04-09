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
			string writeFile = "userData.txt";
			string readFile = "userData.txt";

			Dictionary<string, string> record = new Dictionary<string, string>();

			TextUserDataHandler userDataHandler = new TextUserDataHandler(readFile, writeFile);

			if (userDataHandler.insert("Solomon", "Sally", 5, 6, 7))
			{
				Console.WriteLine("User inserted successfully");
			}
			else
			{
				Console.WriteLine("User exists");
			}

			//userDataHandler.reload();
			bool exists = userDataHandler.nameExists("Theodore");

			int? nullId = userDataHandler.login("Solomon", "Sally");
			if (nullId != null)
			{
				int id = nullId ?? default(int);
				int ties = userDataHandler.getTies(id) ?? default(int);

				userDataHandler.setTies(id, ties + 1);
				userDataHandler.UpdateAll();
			}

			Console.WriteLine("User Solomon:  " + exists);
			Console.WriteLine("User David: " + userDataHandler.nameExists("David"));
			Console.WriteLine("Solomon id: " + nullId);

			Console.ReadKey();
		}
	}
}
