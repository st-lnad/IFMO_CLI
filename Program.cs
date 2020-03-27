using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PP1
{
	class Program
	{
		static Dictionary<string, Func<bool>> _labActions;

		static Program()
		{
			_labActions = typeof(Program).Assembly.GetTypes()
										 .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
										 .Where(m => m.ReturnType == typeof(void) && m.GetParameters().Length == 0 && m.IsStatic)
										 .Where(m => m.Name == "Run")
										 .Select(m => CreateDelegate<Action>(m))
										 .ToDictionary(
												m => m.Method.DeclaringType.Name, 
												m => new Func<bool>(() => { m(); return true; }),
												StringComparer.InvariantCultureIgnoreCase
										  );

			_labActions.Add("exit", () => false);
		}

		static T CreateDelegate<T>(MethodInfo method)
		{
			if (!typeof(Delegate).IsAssignableFrom(typeof(T)))
				throw new ArgumentException("Type should be of delegate kind");

			return (T)(object)Delegate.CreateDelegate(typeof(T), method);
		}

		public static void Main(string[] args)
		{
			string path = "\nLP\\Main>";
			Console.WriteLine("   Hello!\n   Write help:)");
			do
			{
				Console.Write(path);
			} while (PerformCommand(Console.ReadLine().Split(' ')[0]));
		}

		private static bool PerformCommand(string com)
		{
			if (_labActions.TryGetValue(com, out var act))
			{
				return act();
			}
			else
			{
				Console.WriteLine("Sorry, function is not implemented");
				help();
				return true;
			}

			//if (Enum.TryParse<Commands>(com, out var cmd))
			//{
			//	string path = "LP\\" + cmd + ">";
			//	Console.WriteLine(path);

			//	#region
			//	//switch (cmd)
			//	//{
			//	//	case Commands.end:
			//	//		return true;
			//	//	case Commands.help:
			//	//		help();
			//	//		break;
			//	//	case Commands.lab1_1:
			//	//		src_labs.Lab1.Linear_1.Run();
			//	//		break;
			//	//	case Commands.lab2_2_1:
			//	//		src_labs.Lab2.Branching_2_1.Run();
			//	//		break;
			//	//	case Commands.lab2_2_2:
			//	//		src_labs.Lab2.Branching_2_2.Run();
			//	//		break;
			//	//	case Commands.lab2_3_1:
			//	//		src_labs.Lab2.Branching_3_1.Run();
			//	//		break;
			//	//	case Commands.lab2_3_2:
			//	//		Console.WriteLine("Sorry, function hasn't realized");
			//	//		break;
			//	//	case Commands.lab3_4_1:
			//	//		src_labs.Lab3.Arrays_4_1.Run();
			//	//		break;
			//	//	case Commands.lab3_4_2:
			//	//	case Commands.lab4_5:
			//	//	case Commands.lab4_6:
			//	//	case Commands.lab5_7:
			//	//	case Commands.lab6_8:
			//	//		Console.WriteLine("Sorry, function hasn't realized");
			//	//		break;
			//	//	default:
			//	//		throw new NotImplementedException("Unknown command " + cmd);
			//	//}
			//	#endregion
			//}
			//else
			//{
			//	help();
			//}
			//return false;
		}
		//private enum Commands
		//{
		//	lab1_1,
		//	lab2_2_1,
		//	lab2_2_2,
		//	lab2_3_1,
		//	lab2_3_2,
		//	lab3_4_1,
		//	lab3_4_2,
		//	lab4_5,
		//	lab4_6,
		//	lab5_7,
		//	lab6_8,
		//	help,
		//	end
		//}
		private static void help()
		{
			Console.WriteLine("List of available commands:");
			//foreach (var now in Enum.GetNames(typeof(Commands)))
			foreach (var now in _labActions.Keys)
			{
				Console.WriteLine("  " + now);
			}
		}
	}
}
