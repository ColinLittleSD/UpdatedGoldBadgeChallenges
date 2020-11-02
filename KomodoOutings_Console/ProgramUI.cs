using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoOutings_Repository;

namespace KomodoOutings_Console
{
    class ProgramUI
    {
        private KomodoOutings_Repo _repo = new KomodoOutings_Repo();
        public void Run()
        {
            SeedOutings();
            Menu();
        }

        private void SeedOutings()
        {
            DateTime golfOutingDate = DateTime.Parse("04/10/2021");
            KomodoOutings golfOuting = new KomodoOutings(
                OutingType.Golf,
                30, 
                golfOutingDate,
                25
            );

            _repo.AddToListOfOutings(golfOuting);
        }
        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Select a number for what you would like to do!:\n" +
                    "1. See the events:\n" +
                    "2. Add an event:\n" +
                    "3. See cost of an event type:\n" +
                    "4. See costs of all events: \n" +
                    "5. Exit:\n"
                    );

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SeeEventList();
                        break;
                    case "2":
                        AddEvent();
                        break;
                    case "3":
                        SeeCostByEventType();
                        break;
                    case "4":
                        SeeCostOfAllEventsPlanned();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void SeeCostOfAllEventsPlanned()
        {
            double cost = _repo.GetCostOfAllOutingsTogether();
            Console.WriteLine($"The cost of your events is ${cost}");
        }

        private void SeeEventList()
        {
            Console.Clear();

            List<KomodoOutings> listOfEvents = _repo.SeeOutings();

            foreach (KomodoOutings outing in listOfEvents)
            {
                DisplayOutings(outing);

            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayOutings(KomodoOutings outing)
        {
            Console.WriteLine($"Event Type: {outing.OutingType}");
            Console.WriteLine($"Number of employees Attending: {outing.NumberOfAttendees}");
            Console.WriteLine($"Date: {outing.Date}");
            Console.WriteLine($"Cost Per Person: {outing.CostPerPerson}");
            Console.WriteLine($"Cost of Event: {outing.CostOfEvent}");

        }

        private void AddEvent()
        {
            Console.Clear();

            KomodoOutings newEvent = new KomodoOutings();

            Console.WriteLine("What number is the event type to add?:\n" +
                "1. Golf:\n" +
                "2. Bowling:\n" +
                "3. Amusment Park:\n" +
                "4. Concert:\n" 
                );

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    newEvent.OutingType = OutingType.Golf;
                    break;
                case "2":
                    newEvent.OutingType = OutingType.Bowling;
                    break;
                case "3":
                    newEvent.OutingType = OutingType.AmusementPark;
                    break;
                case "4":
                    newEvent.OutingType = OutingType.Concert;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option");
                    Console.ReadKey();
                    break;
            }

            Console.WriteLine("How many employees are attending?");
            string numberAttendingAsString = Console.ReadLine();
            int numberAttendingAsInt = Int32.Parse(numberAttendingAsString);
            newEvent.NumberOfAttendees = numberAttendingAsInt;

            Console.WriteLine("When is the event?");
            string dateAsString = Console.ReadLine();
            DateTime dateAsDateTime = DateTime.Parse(dateAsString);
            newEvent.Date = dateAsDateTime;

            Console.WriteLine("What is the cost per person for event?");
            string perPersonCostAsString = Console.ReadLine();
            double perPersonCostAsDouble = double.Parse(perPersonCostAsString);
            newEvent.CostPerPerson = perPersonCostAsDouble;
            
            bool wasAdded = _repo.AddToListOfOutings(newEvent);
            if (wasAdded == true)
            {
                Console.WriteLine("Your event has been added");
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Try again.");
            }
        }

        private void SeeCostByEventType()
        {
            Console.WriteLine("What number is the event type you wish to check price of?:\n" +
                "1. Golf:\n" +
                "2. Bowling:\n" +
                "3. Amusment Park:\n" +
                "4. Concert:\n"
                );

            string input = Console.ReadLine();
            double result = 0;
            switch (input)
            {
                case "1":
                    result = _repo.GetCostOfOutingType(OutingType.Golf);
                    break;
                case "2":
                    result = _repo.GetCostOfOutingType(OutingType.Bowling);
                    break;
                case "3":
                    result = _repo.GetCostOfOutingType(OutingType.AmusementPark);
                    break;
                case "4":
                    result = _repo.GetCostOfOutingType(OutingType.Golf);
                    break;
                default:
                    Console.WriteLine("Please choose a valid option");
                    Console.ReadKey();
                    break;
            }
             Console.WriteLine(result);
        }

        
    }
}
