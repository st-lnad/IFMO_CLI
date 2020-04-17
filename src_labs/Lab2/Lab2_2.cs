using System;

namespace ProjectProgram.src_labs.Lab2
{
	static class L2_2
	{
		static bool ComputeValue(double x, double y, double r)
		{
			if ((x <= 0) && (x >= -r) && (y >= 0))
				return (((x + r) * (x + r) + y * y) <= r * r);
			else if ((x >= 0) && (x <= r) && (y <= 0))
				return (((x - r) * (x - r) + y * y) <= r * r);
			else
				return false;
		}
		static void Run()
		{
			string[] args;
			do
			{
				Console.Write("args = ");
				args = Console.ReadLine().Split(' ');
				if ((args.Length != 3) ||
					!double.TryParse(args[0], out double x) ||
					!double.TryParse(args[1], out double y) ||
					!double.TryParse(args[1], out double r))
				{
					if (!(args.Length == 1 && args[0] == "back")) PrintHelp();
				}
				else
				{
					Console.Write("result = ");
					Console.WriteLine(ComputeValue(x, y, r));
				}
			} while (!(args.Length == 1 && args[0] == "back"));
		}
		private static void PrintHelp()
		{
			Console.WriteLine("This function calculates:");
			Console.WriteLine("is your point a hit point");
			Console.WriteLine("The syntax for this command is");
			Console.WriteLine("x y r\n");
		}
	}
}
