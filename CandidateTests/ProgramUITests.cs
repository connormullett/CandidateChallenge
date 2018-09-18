using System;
using System.Collections.Generic;
using CandidateChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CandidateTests
{
	[TestClass]
	public class ProgramUITests
	{
		[TestMethod]
		public void ProgramUI_AddCandidate_ShouldAddCandidate()
		{
			//-- arrange
			var mockConsole = new MockConsole(new string[] { "1","Jim", "Poggers", "5", "2", "lua", "c#", "65000","4"});
			var programUI = new ProgramUI(mockConsole);

			//-- act
			programUI.Run();

			//-- assert
			var outputText = mockConsole._output;
			StringAssert.Contains(outputText, "Exit");
		}

		[TestMethod]
		public void ProgramUI_DeleteCandidate_CandidateShouldBeDeleted()
		{
			//-- arrange
			var repo = new CandidateRepository();
			var mock = new MockConsole(new string[] { "1", "Jim", "Poggers", "5", "2", "lua", "c#", "65000", "2", "1", "4" });
			var program = new ProgramUI(mock);

			//-- act
			program.Run();

			//-- assert
			Assert.IsTrue(repo.Getlist().Count == 0);
		}

		[TestMethod]
		public void ProgramUI_SeeCandidates_ShouldContainCandidateInfo()
		{
			//-- arrange
			var mock = new MockConsole(new string[] { "1", "Jim", "Poggers", "5", "2", "lua", "c#", "65000", "3", "4" });
			var program = new ProgramUI(mock);

			//-- act
			program.Run();

			//-- assert
			var outputText = mock._output;
			StringAssert.Contains(outputText, "Jim");
		}
	}
}
