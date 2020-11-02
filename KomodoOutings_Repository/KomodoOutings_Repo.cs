using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_Repository
{
    public class KomodoOutings_Repo
    {
        private List<KomodoOutings> _menuDirectory = new List<KomodoOutings>();
        public bool AddToListOfOutings(KomodoOutings outings)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(outings);

            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<KomodoOutings> SeeOutings()
        {
            return _menuDirectory;
        }

        public KomodoOutings GetOutingsByOutingType(OutingType outingType)
        {
            foreach (KomodoOutings outings in _menuDirectory)
            {
                if (outings.OutingType == outingType)
                {
                    return outings;
                }
            }
            return null;
        }
        
        public double GetCostOfOutingType(OutingType outingType)
        {
            double totalCost = 0;
            foreach (KomodoOutings outing in _menuDirectory)
            {
                if (outing.OutingType == outingType)
                {
                    totalCost += outing.CostOfEvent;
                }
            }
            return totalCost;
        }

        public double GetCostOfAllOutingsTogether()
        {
            double totalCost = 0;
            foreach (KomodoOutings outing in _menuDirectory)
            {
                totalCost += outing.CostOfEvent;
            }
            return totalCost;

        }
    }
}
