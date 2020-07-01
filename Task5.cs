using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace Lev_labs.Lab1.Task5
{
	static class Task5
	{
		static Sentence[] SplitSentences(string text)
		{
			//Strings
			Sentence[] sentences = new Sentence[0];
			int start_sent = 0, end_sent = 0;
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '.' || text[i] == '!' || text[i] == '?')
				{
					end_sent = i;
					Array.Resize(ref sentences, sentences.Length + 1);
					int sent_size = end_sent - start_sent + 1;
					sentences[sentences.Length - 1] = new Sentence(text.Substring(start_sent, sent_size));
					start_sent = end_sent + 1;
				}
			}
			return sentences;
		}
		static Sentence ReverseOrderOfWords(Sentence input)
		{
			Sentence output = new Sentence();
			Array.Copy(input.meat, output.meat, input.meat.Length);
			int[] indexes_of_words = new int[input.meat.Length];
			int j = 0;
			for (int i = 0; i < input.meat.Length; i++)
			{
				if (input.meat[i].type_of_part == Type_of_part.word) indexes_of_words[j++] = i;
			}
			for (j = 0; j < indexes_of_words.Length; j++)
			{
				output.meat[j] = input.meat[indexes_of_words.Length - j - 1];
			}
			return output;
		}
		static bool TryReadFile(string path, out string text)
		{
			text = "";
			try
			{

				foreach (string line in File.ReadLines(path))
				{
					text += line;
				}
				return true;
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine("Access denied");
				Console.WriteLine(e.Message);
			}
			catch (SecurityException e)
			{
				Console.WriteLine("Access denied");
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine("Wrong path");
				Console.WriteLine(e.Message);
			}
			return false;
		}
		internal static void Run()
		{
			Console.Write("path = ");
			string path = Console.ReadLine();
			if (TryReadFile(path, out string text))
			{
				Sentence[] sentences = SplitSentences(text);
				for (int i = 0; i < sentences.Length; i++)
				{
					var now = sentences[i];
					now = ReverseOrderOfWords(now);
					Console.WriteLine(now.MyToString());
				}
			}
		}
	}
}
