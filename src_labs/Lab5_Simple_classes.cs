using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP1.src_labs.Lab5
{
	class Simple_classes_7
	{
		public static void Run()
		{
			Complex a = new Complex(0.0/0.0);
			Complex b = new Complex();
			Complex c = a + b;
			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(c);
			Console.WriteLine(a.getReal());
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