using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    class ProgramUI
    {
        private KomodoMenu_Repo _repo = new KomodoMenu_Repo();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                
                Console.WriteLine("Select a number for what you would like to do!:\n" +
                    "1. See the menu:\n" +
                    "2. Add to the menu:\n" +
                    "3. Delete menu items:\n" +
                    "4. Exit: \n"
                    );

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SeeMenuItem();
                        break;
                    case "2":
                        AddToMenu();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void SeeMenuItem()
        {
            Console.Clear();

            List<KomodoMenu> listOfMenuItems = _repo.SeeMenuItems();

            foreach (KomodoMenu menu in listOfMenuItems)
            {
                DisplayMenu(menu);

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayMenu(KomodoMenu menu)
        {
            Console.WriteLine($"Meal Name: {menu.MealName}");
            Console.WriteLine($"Meal Number: {menu.MealNumber}");
            Console.WriteLine($"Description: {menu.Description}");
            Console.WriteLine($"Ingredients: {menu.Ingredients}");
            Console.WriteLine($"Price: {menu.Price}");

        }

        private void AddToMenu()
        {
            Console.Clear();

            KomodoMenu newMenuItem = new KomodoMenu();

            Console.WriteLine("What is the name of your new meal?");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("What is the number of your new meal?");
            string ratingAsString = Console.ReadLine();
            int ratingAsInt = Int32.Parse(ratingAsString);
            newMenuItem.MealNumber = ratingAsInt;

            Console.WriteLine("Describe the meal.");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Ingredients to the meal");
            newMenuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Price of meal");
            string priceAsString = Console.ReadLine();
            decimal ratingAsDecimal = decimal.Parse(priceAsString);
            newMenuItem.Price = ratingAsDecimal;

            bool wasAdded = _repo.AddToMenu(newMenuItem);
            if (wasAdded == true)
            {
                Console.WriteLine("Your meal has been added to the menu");
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Try again.");
            }
        }
        private void DeleteMenuItem()
        {

            SeeMenuItem();
            Console.WriteLine("Enter the name of meal you wish to take off the menu.");

            string mealToDelete = Console.ReadLine();

            KomodoMenu contentToDelete = _repo.SeeMenuItemByMealName(mealToDelete);

            bool wasDeleted = _repo.DeleteMenuItem(contentToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }
        }
    }
}

