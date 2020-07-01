using System;
using System.Collections.Generic;

namespace Lev_labs.Lab1
{

	static class Task1
	{
		static double ComputeValue(double x, double y)
		{
			// Linear programs
			return (Math.Pow(Math.Cos(x), 4) + Math.Pow(Math.Sin(y), 2) + 1 / 4 * Math.Pow(Math.Sin(2 * x), 2) - 1);
		}
		internal static void Run()
		{
			UT.UserInput.EnterDouble("x", out double x);
			UT.UserInput.EnterDouble("y", out double y);
			Console.WriteLine("Result: {0}", ComputeValue(x, y));
		}
	}

	internal static class Task2_1
	{
		internal static double ComputeValue(double x)
		{
			// Branching. Piecewise - defined function
			if (x <= -2) return 0.25*x + 0.5;
			else if (x <= 0) return ((4 - 2 * Math.Sqrt(4 - (Math.Pow((x+2), 2)))) / 2);
			else if (x <= 2) return Math.Sqrt(4- x*x);
			else return -x + 2;
		}
		internal static void Run()
		{
			UT.UserInput.EnterDouble("x", out double x);
			Console.WriteLine("Result: {0}", ComputeValue(x));
		}
	}

	static class Task2_2
	{
		static bool ComputeValue(double x, double y, double r)
		{
			// Branching. Hit point
			if ((x >= 0) && (y >= 0)) return (x * x + y * y <= r * r);
			else if ((x <= 0) && (y <= 0)) return (y >= -(x + r));
			else return false;
		}
		internal static void Run()
		{
			UT.UserInput.EnterDouble("x", out double x);
			UT.UserInput.EnterDouble("y", out double y);
			UT.UserInput.EnterDouble("r", out double r);
			Console.WriteLine("Result: {0}", ComputeValue(x, y, r));
		}
	}

	static class Task3_1
	{
		static Dictionary<double, double> ComputeTable(double begin, double end, double step)
		{
			// Loops. Table of function values
			Dictionary<double, double> ans = new Dictionary<double, double>();
			for (double now = begin; (end - begin > 0) ? (now <= end) : (now >= end); now += step)
			{
				ans.Add(now, Task2_1.ComputeValue(now));
			}
			return ans;
		}
		internal static void Run()
		{
			Console.WriteLine("[X1, X2], step dX");
			UT.UserInput.EnterDouble("X1", out double begin);
			UT.UserInput.EnterDouble("X2", out double end);
			UT.UserInput.EnterDouble("dX", out double step);

			foreach (var now in ComputeTable(begin, end, step))
			{
				Console.WriteLine(now.Key.ToString("F3").PadRight(7) + now.Value.ToString("F3").PadRight(7));
			}	
		}
	}

	static class Task3_2
	{
		static Dictionary<double, double> ComputeTable(double begin, double end, double step, double e)
		{
			// Loops. Taylor series
			// TODO
			return new Dictionary<double, double>();
		}
		internal static void Run()
		{
			Console.WriteLine("I haven't done that");
			Console.WriteLine("     ¯\\_(ツ)_/¯     ");
		}
	}
}
