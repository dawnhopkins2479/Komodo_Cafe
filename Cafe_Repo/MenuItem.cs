using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuManager
{
    public class Menu
    {
        private Dictionary<int, MenuItem> _listOfMenuItems = new Dictionary<int, MenuItem>();


        public bool AddNewItem(MenuItem menuItem)
        {
            bool bReturn = false; 

            if (!_listOfMenuItems.ContainsKey(menuItem.MealNumber))
            {
                _listOfMenuItems.Add(menuItem.MealNumber, menuItem);
                bReturn = true;
            }
            return bReturn;
        }
        public bool RemoveMenuItem(int mealNumber)
        {
            bool bReturn = false;

            if (_listOfMenuItems.ContainsKey(mealNumber))
            {
               _listOfMenuItems.Remove(mealNumber);
                bReturn = false;
            }            
            return bReturn;
        }
        public void ListCurrentMenu()
        {
            foreach (KeyValuePair<int, MenuItem> kvp in _listOfMenuItems)
            {
                MenuItem d = (MenuItem)kvp.Value;
                Console.WriteLine("{0}", d.MealNumber, d.MealName, d.Description, d.Ingredients,"{1}", d.Price);
            }

        }
    }
}
