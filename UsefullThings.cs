using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT
{
	internal static class UserInput
	{
		internal static void EnterDouble(string name, out double output_double)
		{
			do
			{
				Console.Write("Enter {0}: ", name);
			} while (!double.TryParse(Console.ReadLine(), out output_double));
		}
		internal static void EnterInteger(string name, out int output_integer)
		{
			do
			{
				Console.Write("Enter {0}: ", name);
			} while (!int.TryParse(Console.ReadLine(), out output_integer));
		}
	}
}
