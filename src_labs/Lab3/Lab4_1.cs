using System;

namespace ProjectProgram.src_labs.Lab3
{
	class L4_1
	{
		static void Run()
		{
			string[] args;
			do
			{
				Console.Write("args = ");
				args = Console.ReadLine().Split(' ');
				if (!AreAllArgsDouble(args, out var data))
				{
					if (!(args.Length == 1 && args[0] == "back")) PrintHelp();
				}
				else
				{
					Console.Write("Count of negative = ");
					Console.WriteLine(CountNegative(data));
					Console.Write("Sum from min = ");
					Console.WriteLine(SumFromIndex(data, IndexAbsMin(data)));
					ReplaceNegativeSqr(data);
					Console.Write("result = ");
					foreach (var now in data)
					{
						Console.Write(now.ToString() + " ");
					}
					Console.WriteLine();
				}
			} while (!(args.Length == 1 && args[0] == "back"));
		}
		private static bool AreAllArgsDouble(string[] input, out double[] output)
		{
			double[] goods = new double[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				if (!double.TryParse(input[i], out goods[i]))
				{
					output = new double[0];
					return false;
				}

			}
			output = goods;
			return true;
		}
		private static void ReplaceNegativeSqr(double[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] < 0) input[i] *= input[i];
			}
		}
		private static int CountNegative(double[] input)
		{
			int i = 0;
			foreach (var now in input)
			{
				if (now < 0) i++;
			}
			return i;
		}
		private static int IndexAbsMin(double[] input)
		{
			int min = 0;
			for (int i = 0; i < input.Length; i++)
			{
				if (Math.Abs(input[i]) < Math.Abs(input[min])) min = i;
			}
			return min;
		}
		private static double SumFromIndex(double[] input, int index)
		{
			double sum = 0;
			for (; index < input.Length; index++)
			{
				sum += input[index];
			}
			return sum;
		}

		private static void PrintHelp()
		{
			Console.WriteLine("This function does:");
			Console.WriteLine("Something:)");
			Console.WriteLine("The syntax for this command is");
			Console.WriteLine("[double data]\n");
		}
	}
}
