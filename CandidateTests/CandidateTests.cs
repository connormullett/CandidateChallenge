using System;
using System.Collections.Generic;
using CandidateChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CandidateTests
{
	[TestClass]
	public class CandidateTests
	{
		[TestMethod]
		public void Candidate_ShouldBeTypeOfCandidate()
		{
			//-- arrange
			var languages = new List<string>()
			{
				"c#", "lua"
			};

			var candidate = new Candidate()
			{
				FirstName = "Jim J",
				LastName = "Poggers",
				YearsCoding = 3,
				Languages = languages,
				ExpectedSalary = 65000
			};

			//-- assert
			Assert.IsInstanceOfType(candidate, typeof(Candidate));
		}
	}
}
