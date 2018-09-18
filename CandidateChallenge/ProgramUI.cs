using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateChallenge
{
	class ProgramUI
	{
		readonly CandidateRepository _repo = new CandidateRepository();

		public void Run()
		{
			InitialPrompt();
		}

		private void InitialPrompt()
		{
			Console.Clear();
			Console.WriteLine("1. Add Candidate\n2. Delete Candidate\n3. See Candidates\n4. Exit");
			string inputStr = Console.ReadLine();

			bool inputBl = int.TryParse(inputStr, out int input);
			if(input < 1 || input > 4 || inputBl == false)
			{
				Console.Clear();
				Console.WriteLine("Invalid Answer");
				Console.ReadKey();
				InitialPrompt();
			}

			switch (input)
			{
				case 1:
					AddCandidate();
					break;
				case 2:
					DeleteCandidate();
					break;
				case 3:
					SeeCandidates();
					break;
				case 4:
					break;
			}
		}

		private void AddCandidate()
		{
			Console.Clear();
			Console.WriteLine("Enter Candidate First Name: ");
			var firstName = Console.ReadLine();

			Console.WriteLine("Enter Candidate Last Name: ");
			var lastName = Console.ReadLine();

			Console.WriteLine("Enter Years of Experience: ");
			var yearsCoding = int.Parse(Console.ReadLine());

			Console.WriteLine("How many languages does the candidate know: ");
			var numLanguages = int.Parse(Console.ReadLine());
			var languages = AddLanguages(numLanguages);

			Console.WriteLine("Enter candidates expected salary: ");
			var expectedSalary = int.Parse(Console.ReadLine());

			_repo.CreateCandidate(new Candidate()
				{
					FirstName = firstName,
					LastName = lastName,
					YearsCoding = yearsCoding,
					Languages = languages,
					ExpectedSalary = expectedSalary
				});

			Console.Clear();
			Console.WriteLine("Candidate Created");
			Console.ReadKey();
			InitialPrompt();
		}

		private List<string> AddLanguages(int num)
		{
			var list = new List<string>();

			for (int i = 0; i < num; i++)
			{
				Console.WriteLine("Enter Language: ");
				list.Add(Console.ReadLine());
			}

			return list;
		}

		private void DeleteCandidate()
		{
			Console.Clear();
			Console.WriteLine("Enter Last name of candidate to delete: ");
			if(_repo.DeleteCandidate(Console.ReadLine()) == true)
			{
				Console.WriteLine("Candidate deleted");
			}
			else
			{
				Console.WriteLine("Candidate does not exist");
			}

			Console.ReadKey();
			InitialPrompt();
		}

		private void SeeCandidates()
		{
			Console.Clear();
			if(_repo.Getlist() == null)
			{
				Console.WriteLine("No candidates exist");
				Console.ReadKey();
				InitialPrompt();
			}

			foreach(var c in _repo.Getlist())
			{
				Console.WriteLine($"{c.FirstName} {c.LastName}\n{c.YearsCoding}");
				foreach(var l in c.Languages)
				{
					Console.WriteLine(l);
				}
				Console.WriteLine(c.ExpectedSalary);
			}

			Console.ReadKey();
			InitialPrompt();
		}
	}
}
