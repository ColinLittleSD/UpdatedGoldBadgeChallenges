using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class Claim_Repo
    {
        private Queue<Claim> _claimDirectory = new Queue<Claim>();
        private int _idCounter = 1;

        public void AddToQueueOfClaims(Claim claim)
        {
            claim.ClaimID = _idCounter;
            _claimDirectory.Enqueue(claim);
            _idCounter++;
        }

        public Queue<Claim> GetQueueOfClaims()
        { 
            return _claimDirectory;
        }

        public void HandleNextClaim()
        {
            _claimDirectory.Dequeue();
        }

    }
}
