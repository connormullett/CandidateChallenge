using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateChallenge
{
	public class ProgramUI
	{
		public CandidateRepository _repo;
		private readonly IConsole _console;

		public ProgramUI(IConsole console)
		{
			_console = console;
			_repo = new CandidateRepository();
		}

		public void Run()
		{
			InitialPrompt();
		}

		private void InitialPrompt()
		{
			_console.Clear();
			_console.WriteLine("1. Add Candidate\n2. Delete Candidate\n3. See Candidates\n4. Exit");
			string inputStr = _console.ReadLine();

			bool inputBl = int.TryParse(inputStr, out int input);
			if(input < 1 || input > 4 || inputBl == false)
			{
				_console.Clear();
				_console.WriteLine("Invalid Answer");
				_console.ReadKey();
				InitialPrompt();
			}

			switch (input)
			{
				case 1:
					AddCandidate();
					break;
				case 2:
					RemoveCandidate();
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
			_console.Clear();
			_console.WriteLine("Enter Candidate First Name: ");
			var firstName = _console.ReadLine();

			_console.WriteLine("Enter Candidate Last Name: ");
			var lastName = _console.ReadLine();

			_console.WriteLine("Enter Years of Experience: ");
			var yearsCoding = int.Parse(_console.ReadLine());

			_console.WriteLine("How many languages does the candidate know: ");
			var numLanguages = int.Parse(_console.ReadLine());
			var languages = AddLanguages(numLanguages);

			_console.WriteLine("Enter candidates expected salary: ");
			var expectedSalary = int.Parse(_console.ReadLine());

			_repo.CreateCandidate(new Candidate()
				{
					FirstName = firstName,
					LastName = lastName,
					YearsCoding = yearsCoding,
					Languages = languages,
					ExpectedSalary = expectedSalary
				});

			_console.Clear();
			_console.WriteLine("Candidate Created");
			_console.ReadKey();
			InitialPrompt();
		}

		private List<string> AddLanguages(int num)
		{
			var list = new List<string>();

			for (int i = 0; i < num; i++)
			{
				_console.WriteLine("Enter Language: ");
				list.Add(_console.ReadLine());
			}

			return list;
		}

		private void RemoveCandidate()
		{
			_console.Clear();

			for(int i = 1; i < _repo.Getlist().Count; i++)
			{
				Console.WriteLine($"{i}. {_repo.Getlist()[i].LastName} {_repo.Getlist()[i].FirstName}");
			}

			_console.WriteLine("Enter Candidates number to delete: ");
			var num = int.Parse(_console.ReadLine());

			_repo.DeleteCandidate(num - 1);
			_console.WriteLine("Candidate deleted");
			

			_console.ReadKey();
			InitialPrompt();
		}

		private void SeeCandidates()
		{
			_console.Clear();
			if(_repo.Getlist() == null)
			{
				_console.WriteLine("No candidates exist");
				_console.ReadKey();
				InitialPrompt();
			}

			foreach(var c in _repo.Getlist())
			{
				_console.WriteLine($"{c.FirstName} {c.LastName}\n{c.YearsCoding}");
				foreach(var l in c.Languages)
				{
					_console.WriteLine(l);
				}
				_console.WriteLine(c.ExpectedSalary.ToString());
			}

			_console.ReadKey();
			InitialPrompt();
		}
	}
}
