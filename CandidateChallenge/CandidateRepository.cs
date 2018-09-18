using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateChallenge
{
	class CandidateRepository
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

		public bool DeleteCandidate(string name)
		{
			var entity = _candidates.Single(x => x.LastName == name);

			if (entity == null) return false;
			else
			{
				_candidates.Remove(entity);
				return true;
			}
		}
	}
}
