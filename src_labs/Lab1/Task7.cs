using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lev_labs.Lab1.Task7
{
	static class Task7
	{
		internal static void Run()
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
	}
}
