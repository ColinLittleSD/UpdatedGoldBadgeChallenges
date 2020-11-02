using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class KomodoMenu_Repo
    {
        private List<KomodoMenu> _menuDirectory = new List<KomodoMenu>();

        public bool AddToMenu(KomodoMenu menu)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(menu);

            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<KomodoMenu> SeeMenuItems()
        {
            return _menuDirectory;
        }

        public KomodoMenu SeeMenuItemByMealName(string mealName)
        {
            foreach (KomodoMenu menu in _menuDirectory)
            {
                if (menu.MealName.ToLower() == mealName.ToLower())
                {
                    return menu;
                }
            }
            return null;
        }

        public bool DeleteMenuItem(KomodoMenu menuItem)
        {
            bool deleteItem = _menuDirectory.Remove(menuItem);
            return deleteItem;
        }
    }
}
