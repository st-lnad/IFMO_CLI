using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace PP1.src_labs.Lab4
{
	class Strings_5
	{
		public static void Run()
		{
			bool end = false;
			string[] args;
			do
			{
				Console.Write("path = ");
				args = Console.ReadLine().Split(' ');
				if (args.Length != 1)  PrintHelp();
				else if (args.Length == 1 && args[0] == "back") end = true;
				else
				{
					if (TryReadFile(args[0], out string text))
					{
						int Max_count_index = 0;
						string[] sentences = text.Split('.', '?', '!');
						int[] sp_ch_count = new int[sentences.Length];
						for (int i = 0; i < sentences.Length; i++) 
						{
							foreach (var now_ch in sentences[i])
							{
								if (!(now_ch >= 'a' && now_ch<='z')&& !(now_ch >= 'A' && now_ch <= 'Z'))
								{
									sp_ch_count[i]++;
								}
								if (sp_ch_count[i] > sp_ch_count[Max_count_index]) Max_count_index = i;
							}
						}
						Console.WriteLine(sentences[Max_count_index]);
					}
					
				}
			} while (!end);
		}

		static bool TryReadFile(string path, out string text)
		{
			text = "";
			try
			{
				
				foreach (string line in File.ReadLines(path))
				{
					text += line;
				}
				return true;
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine("Access denied");
				Console.WriteLine(e.Message);
			}
			catch (SecurityException e)
			{
				Console.WriteLine("Access denied");
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine("Wrong path");
				Console.WriteLine(e.Message);
			}
			return false;
		}
		private static void PrintHelp()
		{
			Console.WriteLine("This function does:");
			Console.WriteLine("Select sentences in the order of special characters count growth");
			Console.WriteLine("The syntax for this command is");
			Console.WriteLine("[path to file]\n");
		}
	}
}
