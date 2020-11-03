using System;
using System.Collections.Generic;
using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class KomodoCafeRepo_Tests
    {
        [TestMethod]
        public void AddToMenu_ReturnIsTrue()
        {
            KomodoMenu menu = new KomodoMenu();
            KomodoMenu_Repo repo = new KomodoMenu_Repo();

            bool addResult = repo.AddToMenu(menu);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ReturnCollection()
        {
            KomodoMenu menu = new KomodoMenu();
            KomodoMenu_Repo repo = new KomodoMenu_Repo();

            repo.AddToMenu(menu);

            List<KomodoMenu> menus = repo.SeeMenuItems();

            bool menuHasItems = menus.Contains(menu);

            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]
        public void GetByTitle_ReturnCorrectTitle()
        {
            KomodoMenu_Repo repo = new KomodoMenu_Repo();
            KomodoMenu menu = new KomodoMenu(10, "pizza", "cheesy", "cheese", 10 );
            repo.AddToMenu(menu);

            string name = "pizza";

            KomodoMenu searchResult = repo.SeeMenuItemByMealName(name);

            Assert.AreEqual(searchResult.MealName, name);
        }

        [TestMethod]
        public void DeleteMenuItems_ReturnTrue()
        {
            KomodoMenu_Repo repo = new KomodoMenu_Repo();
            KomodoMenu menu = new KomodoMenu(7, "pizza", "cheesy", "cheese", 9);
            repo.AddToMenu(menu);

            KomodoMenu oldMenu = repo.SeeMenuItemByMealName("pizza");
            bool removeResult = repo.DeleteMenuItem(oldMenu);

            Assert.IsTrue(removeResult);

        }
    }
}
