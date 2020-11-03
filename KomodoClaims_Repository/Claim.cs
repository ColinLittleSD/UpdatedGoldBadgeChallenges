using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public Claim(ClaimType claimType, string description, int claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public ClaimType ClaimType { get; set; }
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid => DateOfIncident.AddDays(30) >= DateOfClaim;
    }
}
