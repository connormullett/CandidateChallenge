using CandidateChallenge;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTests
{
	[ExcludeFromCodeCoverage]
	public class MockConsole : IConsole
	{
		public Queue<string> _userInput;
		public string _output;

		public MockConsole(IEnumerable<string> input)
		{
			_userInput = new Queue<string>(input);
			_output = "";
		}

		public void Clear()
		{
			_output += "Console Has been Cleared";
		}

		public void ReadKey()
		{
			_output += "readkey";
		}

		public string ReadLine()
		{
			if (_userInput.Count == 0) return "";

			return _userInput.Dequeue();
		}

		public void WriteLine(string s)
		{
			_output += s + "\n";
		}
	}
}
