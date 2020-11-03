using System;
using KomodoOutings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KomodoOutings_Tests
{
    [TestClass]
    public class KomodoOutingsRepo_Tests
    {
        [TestMethod]
        public void AddEvent_ReturnsNewList()
        {
            KomodoOutings outing = new KomodoOutings();
            KomodoOutings_Repo repo = new KomodoOutings_Repo();

            bool addResult = repo.AddToListOfOutings(outing);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetOutingsReturns_CorrectOuting()
        {
            KomodoOutings outing = new KomodoOutings();
            KomodoOutings_Repo repo = new KomodoOutings_Repo();

            repo.AddToListOfOutings(outing);

            List<KomodoOutings> outings = repo.SeeOutings();

            bool menuHasOutings = outings.Contains(outing);

            Assert.IsTrue(menuHasOutings);
        }
        [TestMethod]
        public void GetByOutingTypeReturns_OutingType()
        {
            KomodoOutings_Repo repo = new KomodoOutings_Repo();
            KomodoOutings newOuting = new KomodoOutings(OutingType.AmusementPark, 10, DateTime.Now, 10 );
            repo.AddToListOfOutings(newOuting);

            OutingType name = OutingType.AmusementPark;

            KomodoOutings searchResult = repo.GetOutingsByOutingType(name);

            Assert.AreEqual(searchResult.OutingType, name);
        }
    }
}
