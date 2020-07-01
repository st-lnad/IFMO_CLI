using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

// Potanin Lev
// Var 8

namespace Lev_labs.Lab1.Starter
{
	static class Starter {
		internal delegate void Runner();
		internal static  Dictionary<string, Runner> actions = new Dictionary<string, Runner>
		{
			{ "1", Task1.Run},
			{ "2", Task2_1.Run},
			{ "3", Task2_2.Run},
			{ "4", Task3_1.Run},
			{ "5", Task3_2.Run},
			{ "6", Task4_1.Run},
			{ "7", Task4_2.Run},
			{ "8", Task5.Task5.Run},
			//{ "9", Task6.Run},
			{ "10", Task7.Task7.Run},
			//{ "11", Task8.Run},
		};
		static string commands = "1 - Task 1 Linear programs\n" +
			"2 - Task 2.1 Piecewise-defined function\n" +
			"3 - Task 2.2 Hit point\n" +
			"4 - Task 3.1 Table of function values\n" +
			"5 - Task 3.2 Taylor series\n" +
			"6 - Task 4.1 of rank 1\n" +
			"7 - Task 4.2 of rank 2\n" +
			"8 - Task 5 Strings\n" +
			"9 - Task 6 Simple data structures\n" +
			"10 - Task 7 Simple classes\n" +
			"11 - Task 8  Standard collections\n";
			
		static void PrintActions()
		{
			Console.WriteLine(commands + "Now are available:");
			foreach (var now in actions)
			{
				Console.Write("{0} ", now.Key);
			}
			Console.WriteLine();
		}
		public static void Main()
		{
			string cmd = "";
			while (cmd != "end") {
				Console.WriteLine();
				PrintActions();
				Console.WriteLine();
				cmd = Console.ReadLine().ToLower();
				if (!actions.ContainsKey(cmd) && cmd != "end") { Console.WriteLine("Wrong key"); }
				else actions[cmd]();
			}
		}
	}
}
