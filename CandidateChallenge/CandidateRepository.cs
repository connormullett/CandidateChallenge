using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateChallenge
{
	public class CandidateRepository
	{
		private readonly List<Candidate> _candidates = new List<Candidate>();

		public void CreateCandidate(Candidate model)
		{
			_candidates.Add(model);
		}

		public List<Candidate> Getlist()
		{
			return _candidates;
		}

		public void DeleteCandidate(int i)
		{
			_candidates.Remove(_candidates[i]);
		}
	}
}
