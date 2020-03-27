using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP1.src_labs.Lab1
{
	static class Linear_1
	{
		private const short need_args = 2;
		public static double Result(double alpha, double beta)
		{
			return (Math.Pow(Math.Cos(alpha) - Math.Cos(beta), 2)) - (Math.Pow(Math.Sin(alpha) - Math.Sin(beta), 2));
			// (cos(a)-cos(b))^2 - (sin(a)-sin(b))^2
		}
		public static void Run()
		{
			string[] args;	
			do
			{
				Console.Write("args = ");
				args = Console.ReadLine().Split(' ');
				if ((args.Length != need_args) ||
					!double.TryParse(args[0], out double a) ||
					!double.TryParse(args[1], out double b))
				{
					if (!(args.Length == 1 && args[0] == "back")) PrintHelp();
				}
				else
				{
					Console.Write("result = ");
					Console.WriteLine(Result(a, b));
				}
			} while (!(args.Length == 1 && args[0] == "back"));
		}
		private static void PrintHelp()
		{
			Console.WriteLine("This function calculates:");
			Console.WriteLine("(cos(a)-cos(b))^2 - (sin(a)-sin(b))^2");
			Console.WriteLine("The syntax for this command is");
			Console.WriteLine("alpha beta\n");
		}
	}
}
