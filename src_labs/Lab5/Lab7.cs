using System;

namespace ProjectProgram.src_labs.Lab5
{
	class L7
	{
		static void Run()
		{
			try
			{
				Complex n = new Complex(0.0 / 0.0);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Complex a = new Complex(15, 18);
			Complex b = new Complex();
			Complex c = a + b;
			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(c);
			Console.WriteLine(a.getReal() + b.getImaginary() * c.Module());
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
