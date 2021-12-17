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
        static Menu _currentMenu = new Menu();

        static void Main(string[] args)
        {
            _currentMenu.AddNewItem(new MenuItem(1, "Quarter Pounder", "a burger", "fried drink burger", 8.50));
            _currentMenu.AddNewItem(new MenuItem(2, "Chicken Tenders", "a burger", "fried drink burger", 8.50));
            _currentMenu.AddNewItem(new MenuItem(3, "Salad", "a burger", "fried drink burger", 8.50));
            _currentMenu.AddNewItem(new MenuItem(4, "Pulled Pork", "a burger", "fried drink burger", 8.50));
            _currentMenu.AddNewItem(new MenuItem(5, "Cheesecake", "a burger", "fried drink burger", 8.50));
            

            RenderMainMenu();
            
            ConsoleKeyInfo keypressed;
            char cKeyPressed;
            bool bRun = true;

            while (bRun)
            {
                keypressed = Console.ReadKey();
                int iKeyPressed = Convert.ToInt32(keypressed.KeyChar.ToString());
                HandleMenuSelection(iKeyPressed);
                //TODO: HandleTheInput(iPressed)       
                int iPressed = 0;
                
                
            }          
        }
        private static MenuItem ParseAddMenuItemFromInput(string input)
        {
            string[] aInput = input.Split(',');
            
            if (aInput.Length == 5)
            {
                return new MenuItem(Convert.ToInt32(aInput[0]), aInput[1], aInput[2], aInput[3], Convert.ToDouble(aInput[4]));
            }
            else
            {
                Console.WriteLine("Unable to add meal. Please try again.");
            }

            return null;

        }
        private static MenuItem ParseRemoveMenuItemFromInput(int input)
        {
            int aInput = input;

            if (aInput == 1)
            {
                return ParseRemoveMenuItemFromInput(aInput);
            }
            else
            {
                Console.WriteLine("Please enter a different number.");
            }

            return null;
        }
        public static void HandleMenuSelection(int iKeyPressed)
        {
            switch ((MenuActions) iKeyPressed)
            {
                case MenuActions.ViewCurrentMenu:
                    RenderMainMenu();
                    Console.WriteLine("********************************");
                    //Console.WriteLine("1. Quarter Pounder\n A delicious burger with cheese between two buns\n fries\n large drink\n made with ground beef\n cheese\n lettuce\n tomatoes\n potatoes\n and salt\n $8.50");
                    _currentMenu.ListCurrentMenu();
                    Console.WriteLine();
                    Console.WriteLine("********************************");

                    break;

                case MenuActions.AddMenuItem:
                    RenderMainMenu();
                    Console.WriteLine("To add a new item to the menu, enter the Meal number, Name of Meal, description, ingredients, price and then hit enter");
                    String sInput = Console.ReadLine();
                    MenuItem newMenuItem = ParseAddMenuItemFromInput(sInput);

                    if (_currentMenu.AddNewItem(newMenuItem))
                    {
                        RenderMainMenu();
                        Console.WriteLine("Your item was added successfully");
                    }
                    else
                    {
                        RenderMainMenu();
                        Console.WriteLine("Invalid items entered. Please try again.");
                    }
                    RenderMainMenu();
                    break;

                case MenuActions.RemoveMenuItem:
                    RenderMainMenu();
                    Console.WriteLine("To remove an item from your current menu, type in the meal number and then press enter");
                    sInput = Console.ReadLine();
                    
                    if (_currentMenu.RemoveMenuItem(Convert.ToInt32(sInput)))
                    {
                        RenderMainMenu();
                        Console.WriteLine("Your item was succesfully removed. ");
                    }
                    else
                    {
                        RenderMainMenu();
                        Console.WriteLine("Number entered does not exist. Please try another number.");
                    }
                    RenderMainMenu();
                    break;
            }
        }       
        public static void RenderMainMenu()
        {
            Console.Clear();
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
            Console.WriteLine();
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
