using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuManager;

namespace Cafe_UI
{
    public class Program
    {
        static MenuActions _currentAction = MenuActions.None;

        static void Main(string[] args)
        {
            RenderMainMenu();
            RenderCurrentMenu();
            RenderAddMenuItem();
            RenderRemoveMenuItem();

            ConsoleKeyInfo keypressed;
            char cKeyPressed;
            bool bRun = true;

            while (bRun)
            {
            keypressed = Console.ReadKey();
            cKeyPressed = keypressed.KeyChar;
            int iPressed = 0;
            }

        }
        private static MenuManager.MenuItem   ParseAddMenuItemFromInput(string input)
        {
            string[] aInput = input.Split(',');
            
            if (aInput.Length == 5)
            {
                return new MenuItem(Convert.ToInt32(aInput[1]),aInput[2],aInput[3],aInput[4],Convert.ToInt32(aInput[5]));
            }
            else
            {
                Console.WriteLine("Unable to add meal. Please try again.");
            }

            return null;

        }
        private static MenuManager.MenuItem ParseRemoveMenuItem(string input)
        {
            string[] aInput = input.Split(',');

            if (aInput.Length == 1)
            {
                return ParseRemoveMenuItem(Convert.ToString(aInput[1]));
            }
            else
            {
                Console.WriteLine("Please enter a different number.");
            }

            return null;
        }
        public static void HandleMenuSelection(int iKeyPressed)
        {
            switch (_currentAction)
            {
                case MenuActions.ViewCurrentMenu:
                    break;
                case MenuActions.AddMenuItem:
                    RenderAddMenuItem();
                    break;
                case MenuActions.RemoveMenuItem:
                    RenderRemoveMenuItem();
                    break;
            }
        }       
        public static void RenderMainMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Menu Manager 1.0");
            Console.WriteLine();
            Console.WriteLine("Please select an option below:");
            Console.WriteLine();
            Console.WriteLine("1. View Current Menu");
            Console.WriteLine("2. Add Menu Items");
            Console.WriteLine("3. Remove Menu Items");
            Console.WriteLine("0. Exit");
            Console.WriteLine("**************************************************");
            _currentAction = MenuActions.ViewCurrentMenu;
        }
        public static void RenderCurrentMenu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Current Menu");
            Console.WriteLine();
            Console.WriteLine("Meal #1 - ");
            _currentAction = MenuActions.ViewCurrentMenu;
        }
        public static void RenderAddMenuItem()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Please enter Meal #, Meal name, meal description, meal ingedients, meal price.");
            _currentAction = MenuActions.AddMenuItem;
        }
        public static void RenderRemoveMenuItem()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Please enter the meal # you would like to remove.");
            _currentAction = MenuActions.RemoveMenuItem;
        }
    }
}
