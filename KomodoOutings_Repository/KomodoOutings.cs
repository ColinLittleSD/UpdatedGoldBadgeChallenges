using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_Repository
{
    public enum OutingType
    {
        Golf,
        Bowling,
        AmusementPark,
        Concert
    }
    public class KomodoOutings
    {
        public OutingType OutingType { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEvent => NumberOfAttendees * CostPerPerson;
        public KomodoOutings() { }
        public KomodoOutings(OutingType outingType, int numberOfAttendees, DateTime date, double costPerPerson)
        {
            OutingType = outingType;
            NumberOfAttendees = numberOfAttendees;
            Date = date;
            CostPerPerson = costPerPerson;
        }
    }
}
