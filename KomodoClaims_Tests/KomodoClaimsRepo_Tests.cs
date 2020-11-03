using System;
using System.Collections.Generic;
using KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class KomodoClaimsRepo_Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Claim claim = new Claim();
            Claim_Repo repository = new Claim_Repo();

            repository.AddToQueueOfClaims(claim);

            Assert.AreEqual(1, repository.ClaimCount());
        }

        [TestMethod]
        public void GetClaimsShouldReturn_QueueOfClaims()
        {
            Claim claim = new Claim();
            Claim_Repo repo = new Claim_Repo();

            repo.AddToQueueOfClaims(claim);

            Queue<Claim> claims = repo.GetQueueOfClaims();
            bool queueHasClaims = claims.Contains(claim);

            Assert.IsTrue(queueHasClaims);
        }

        //[TestMethod]
        //public void MyTestMethod()
        //{
        //    Claim claim = new Claim();
        //    Claim_Repo repository = new Claim_Repo();

        //    repository.HandleNextClaim();

        //    Assert.AreEqual(0, repository.ClaimCount());
        //}
    }
}
