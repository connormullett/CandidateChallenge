using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateChallenge
{
	public interface IConsole
	{
		void WriteLine(string s);
		string ReadLine();
		void Clear();
		void ReadKey();
	}
}
