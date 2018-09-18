using System.Collections.Generic;

namespace CandidateChallenge
{
	public class Candidate
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int YearsCoding { get; set; }

		public List<string> Languages { get; set; }

		public int ExpectedSalary { get; set; }
	}
}