using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectProgram
{
	class Starter
	{
		static Dictionary<string, Func<bool>> _labActions;

		static void Main(string[] args)
		{
			string path = "\nLP\\Main>";
			Console.WriteLine("   Hello!\n   Write help:)");
			do
			{
				Console.Write(path);
			} while (PerformCommand(Console.ReadLine().Split(' ')[0]));
		}

		public Starter()
		{
			_labActions = typeof(Starter).Assembly.GetTypes()
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

		private static bool PerformCommand(string com)
		{
			if (_labActions.TryGetValue(com, out var act))
			{
				return act();
			}
			else
			{
				Console.WriteLine("Sorry, function is not implemented");
				PrintHelp();
				return true;
			}
		}
		private static void PrintHelp()
		{
			Console.WriteLine("List of available commands:");
			foreach (var now in _labActions.Keys)
			{
				Console.WriteLine("  " + now);
			}
		}
	}
}
