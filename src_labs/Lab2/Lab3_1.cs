using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectProgram.src_labs.Lab2
{
	struct MyPoint : IEnumerable<double>
	{
		private readonly double x, y;

		public MyPoint(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public IEnumerator<double> GetEnumerator()
		{
			yield return x;
			yield return y;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	static class L3_1
	{
		static IEnumerable<MyPoint> ComputeValuesInRange(double begin, double end, double step)
		{
			Int32 a;
			Dictionary<double, double> ans = new Dictionary<double, double>();
			bool s = end - begin > 0;
			for (; s ? (begin <= end) : (begin >= end); begin += step)
			{
				yield return new MyPoint(begin, L2_1.ComputeValue(begin));
			}
		}

		static void Run()
		{
			string[] args;
			do
			{
				Console.Write("args = ");
				args = Console.ReadLine().Split(' ');
				if ((args.Length != 3) ||
					!double.TryParse(args[0], out double x0) ||
					!double.TryParse(args[1], out double x1) ||
					!double.TryParse(args[2], out double dx))
				{
					if (!(args.Length == 1 && args[0] == "back"))
						PrintHelp();
				}
				else
				{
					if (
						((x0 > x1) && (dx < 0)) ||
						((x0 <= x1) && (dx > 0))
						)
					{
						Console.WriteLine("result:");
						Console.WriteLine("{0,7} {1,7}", "x", "y");
						var result = ComputeValuesInRange(x0, x1, dx);
						foreach (var pt in result)
						{
							Console.WriteLine(string.Join(" ", pt.Select(a => a.ToString("F3").PadLeft(7, ' '))));
						}
					}
					else
					{
						Console.WriteLine("Wrong range or dx");
					}
				}
			} while (!(args.Length == 1 && args[0] == "back"));
		}
		private static void PrintHelp()
		{
			Console.WriteLine("This function writes:");
			Console.WriteLine("pairs (x,y) in your range");
			Console.WriteLine("The syntax for this command is");
			Console.WriteLine("x0 x1 dx\n");
		}
	}
}
