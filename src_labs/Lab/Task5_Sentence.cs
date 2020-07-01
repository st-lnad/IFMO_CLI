using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lev_labs.Lab1.Task5
{
	internal enum Type_of_part
	{
		word,
		spec,
		space,
		end
	}
	class Sentence
	{
		internal class Sent_part
		{
			internal readonly Type_of_part type_of_part;
			internal string content;

			


			internal Sent_part(string content, Type_of_part type_of_part)
			{
				this.content = content;
				this.type_of_part = type_of_part;
			}
		}


		class Word : Sent_part
		{
			internal Word(string content) : base(content, Type_of_part.word) { }
		}
		class Spec : Sent_part
		{
			internal Spec(string content) : base(content, Type_of_part.spec) { }
		}
		class Space : Sent_part
		{
			internal Space(string content) : base(content, Type_of_part.space) { }

		}
		class End : Sent_part
		{
			internal End(string content) : base(content, Type_of_part.end) { }

		}

		internal Sent_part[] meat = new Sent_part[0];

		internal int word_count()
		{
			int counter = 0;
			foreach (var now in meat)
			{
				if (now.type_of_part == Type_of_part.word) counter++;
			}
			return counter;
		}

		internal Sentence(string raw_sent)
		{
			string now_word = "";
			foreach (char now_char in raw_sent)
			{
				if (('a' <= now_char) && (now_char <= 'z') || ('A' <= now_char) && (now_char <= 'Z')) now_word += now_char;
				else
				{
					Array.Resize(ref meat, (meat.Length + (now_word.Length != 0 ? 2 : 1)));
					if (now_word.Length != 0)
					{
						meat[meat.Length - 2] = new Word(now_word);
					}
					now_word = "";
					if (now_char == ' ') meat[meat.Length - 1] = new Space(now_char.ToString());
					else if (now_char == '.' || now_char == '!' || now_char == '?') meat[meat.Length - 1] = new End(now_char.ToString());
					else meat[meat.Length - 1] = new Spec(now_char.ToString());
				}
			}
		}
		internal Sentence() { }

		internal string MyToString()
		{
			string ret = "";
			foreach (var now in meat)
			{
				ret += now.content;
			}
			return ret;
		}
	}
}