using System;

namespace ProjectProgram.src_labs.Lab2
{
	class L2_1
	{
		internal static double ComputeValue(double x)
		{
			if (x <= -3) return x + 3;
			else if (x <= 0) return Math.Sqrt(9 - x * x);
			else if (x <= 6) return -1.0 / 2.0 * x + 3;
			else return x - 6;
		}
		static void Run()
		{
			string[] args;
			do
			{
				Console.Write("args = ");
				args = Console.ReadLine().Split(' ');
				if ((args.Length != 1) || !double.TryParse(args[0], out double x))
				{
					if (!(args.Length == 1 && args[0] == "back")) PrintHelp();
				}
				else
				{
					Console.Write("result = ");
					Console.WriteLine(ComputeValue(x));
				}
			} while (!(args.Length == 1 && args[0] == "back"));
		}
		private static void PrintHelp()
		{
			Console.WriteLine("Piecewise-defined function");
			Console.WriteLine("This function calculates:");
			Console.WriteLine("y(x), where you enter x");
			Console.WriteLine("The syntax for this command is");
			Console.WriteLine("x\n");
		}

	}
}
