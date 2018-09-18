using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateChallenge
{
	public class RealConsole : IConsole
	{
		public void Clear()
		{
			Console.Clear();
		}

		public void ReadKey()
		{
			Console.ReadKey();
		}

		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void WriteLine(string s)
		{
			Console.WriteLine(s);
		}
	}
}
