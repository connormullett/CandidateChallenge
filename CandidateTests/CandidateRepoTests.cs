using System;
using System.Collections.Generic;
using CandidateChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CandidateTests
{
	[TestClass]
	public class CandidateRepoTests
	{
		readonly CandidateRepository _repo = new CandidateRepository();

		[TestMethod]
		public void CandidateRepository_CreateCandidate_ShouldCreateCandidate()
		{
			//-- Arrange
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

			//-- act
			_repo.CreateCandidate(candidate);
			var expected = 1;
			var actual = _repo.Getlist().Count;

			//-- assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CandidateRepository_GetList_ShouldReturnListAndHaveExpectedCount()
		{
			//-- act
			var list = _repo.Getlist();

			//-- assert
			Assert.IsInstanceOfType(list, typeof(List<Candidate>));
			Assert.IsTrue(list.Count == 0);
		}

		[TestMethod]
		public void CandidateRepository_DeleteCandidate_ShouldDeleteCandidate()
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

			//-- act
			_repo.CreateCandidate(candidate);
			_repo.DeleteCandidate(0);

			//-- assert
			Assert.IsTrue(_repo.Getlist().Count == 0);
		}
	}
}
