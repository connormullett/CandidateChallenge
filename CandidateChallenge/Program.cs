using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateChallenge
{
	public class Program
	{
		static void Main(string[] args)
		{
			var program = new ProgramUI(new RealConsole());
			program.Run();
		}
	}
}
