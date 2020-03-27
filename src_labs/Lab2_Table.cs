using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP1.src_labs.Lab2
{

	struct MyPoint : IEnumerable<double>
	{
		public readonly double x, y;

		public MyPoint(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public IEnumerator<double> GetEnumerator()
		{
			yield return this.x;
			yield return this.y;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}

	static class Branching_3_1
	{
		private const short need_args = 3;
		public static IEnumerable<MyPoint> ComputeValuesInRange(double begin, double end, double step)
		{
			Int32 a;
			Dictionary<double, double> ans = new Dictionary<double, double>();
			bool s = end - begin > 0;
			for (; s ? (begin <= end) : (begin >= end); begin += step)
			{
				yield return new MyPoint(begin, Branching_2_1.ComputeValue(begin));
			}
		}

		public static void Run()
		{
			string[] args;
			do
			{
				Console.Write("args = ");
				args = Console.ReadLine().Split(' ');
				if ((args.Length != need_args) ||
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
							//var keyString = now.x.ToString("F3");
							//var valueString = now.y.ToString("F3");
							//Console.WriteLine("{0, 7} {1, 7}", keyString, valueString);

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
