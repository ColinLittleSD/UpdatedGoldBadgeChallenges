using System;
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
    }
}
