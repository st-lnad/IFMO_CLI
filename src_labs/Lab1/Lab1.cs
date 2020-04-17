using System;

namespace ProjectProgram.src_labs.Lab1
{
	class L1
	{
		static double ComputeValue(double alpha, double beta)
		{
			return (Math.Pow(Math.Cos(alpha) - Math.Cos(beta), 2)) - (Math.Pow(Math.Sin(alpha) - Math.Sin(beta), 2));
		}
		static void Run()
		{
			string[] args;
			do
			{
				Console.Write("args = ");
				args = Console.ReadLine().Split(' ');
				if (
					(args.Length != 2) ||
					!double.TryParse(args[0], out double a) ||
					!double.TryParse(args[1], out double b)
)
				{
					if (!(args.Length == 1 && args[0] == "back")) PrintHelp();
				}
				else
				{
					Console.Write("result = ");
					Console.WriteLine(ComputeValue(a, b));
				}
			} while (!(args.Length == 1 && args[0] == "back"));
		}
		private static void PrintHelp()
		{
			Console.WriteLine("Linear programs");
			Console.WriteLine("This function calculates:");
			Console.WriteLine("(cos(a)-cos(b))^2 - (sin(a)-sin(b))^2");
			Console.WriteLine("The syntax for this command is");
			Console.WriteLine("alpha beta\n");
		}
	}
}
