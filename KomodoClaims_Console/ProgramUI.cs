using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    class ProgramUI
    {
        private Claim_Repo _repo = new Claim_Repo();
        public void Run()
        {
            SeedClaim();
            Menu();
        }

        private void SeedClaim()
        {
            DateTime dateOfIncidentOne = DateTime.Parse("04/25/2018");
            DateTime dateOfClaimOne = DateTime.Parse("04/27/2018");
            Claim carAccidentOne = new Claim(
                ClaimType.Car,
                "Car accident on 465",
                400,
                dateOfIncidentOne,
                dateOfClaimOne);

            DateTime dateOfIncidentTwo = DateTime.Parse("04/11/2018");
            DateTime dateOfClaimTwo = DateTime.Parse("04/12/2018");
            Claim carAccidentTwo = new Claim(
                ClaimType.Home,
                "House fire in kitchen",
                4000,
                dateOfIncidentTwo,
                dateOfClaimTwo);

            DateTime dateOfIncidentThree = DateTime.Parse("04/27/2018");
            DateTime dateOfClaimThree = DateTime.Parse("06/01/2018");
            Claim carAccidentThree = new Claim(
                ClaimType.Theft,
                "Stolen potatoes",
                4,
                dateOfIncidentThree,
                dateOfClaimThree);

            _repo.AddToQueueOfClaims(carAccidentOne);
            _repo.AddToQueueOfClaims(carAccidentTwo);
            _repo.AddToQueueOfClaims(carAccidentThree);
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Select a number for what you would like to do!:\n" +
                    "1. See all claims:\n" +
                    "2. Handle next claim:\n" +
                    "3. Enter new claim:\n" +
                    "4. Exit: \n"
                    );

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        //TakeCareOfNextClaim();
                        break;
                    case "3":
                        //AddNewClaim();
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

        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claim> listOfClaims = _repo.GetQueueOfClaims();
            const int paddingLength = -25; //This is equivalent to the method PadRight(25)
            const int narrowPaddingLength = -10;
            
            Console.WriteLine($"{"ClaimId",narrowPaddingLength}{"Type",narrowPaddingLength}{"Description",paddingLength}{"Amount",narrowPaddingLength}{"DateOfIncident",paddingLength}{"DateOfClaim",paddingLength}{"IsValid",paddingLength}");
            foreach (Claim claim in listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID,narrowPaddingLength}{claim.ClaimType,narrowPaddingLength}{claim.Description,paddingLength}{claim.ClaimAmount,narrowPaddingLength}{claim.DateOfIncident.ToString("mm-dd-yyyy"),paddingLength}{claim.DateOfClaim.ToString("mm-dd-yyy"),paddingLength}{claim.IsValid,paddingLength}");
            }
        }
    }
}
