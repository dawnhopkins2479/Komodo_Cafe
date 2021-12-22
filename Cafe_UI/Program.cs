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
            //_currentMenu.AddNewItem(new MenuItem(1, "Cheesburger", "Cheese on a bun", "cheese burger and bread", 8.50));
            //_currentMenu.AddNewItem(new MenuItem(2, "Cheesburger", "Cheese on a bun", "cheese burger and bread", 8.50));
            //_currentMenu.AddNewItem(new MenuItem(3, "Cheesburger", "Cheese on a bun", "cheese burger and bread", 8.50));
            //_currentMenu.AddNewItem(new MenuItem(4, "Cheesburger", "Cheese on a bun", "cheese burger and bread", 8.50));
            //_currentMenu.ListCurrentMenuItems();

            //Console.ReadKey();
            //_currentMenu.RemoveMenuItem(3);
            //_currentMenu.ListCurrentMenuItems();
            
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
        public static MenuItem ParseListCurrentMenuFromInput(string input)
        {
            string aInput = input;

            if (aInput.Length == 5)
            {
                return ParseListCurrentMenuFromInput(aInput);
            }

            return null;

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
                case MenuActions.ListCurrentMenu:
                    RenderMainMenu();
                    Console.WriteLine("********************************");            
                    Console.WriteLine("List of current Menu");
                    Console.WriteLine("**************************************************");
                    Console.WriteLine("Current Menu");
                    Console.WriteLine();
                    Console.WriteLine("1, Quarter Pounder, a burger, fries drink burger, $9.00");
                    Console.WriteLine("2, Chicken Tenders, Chicken fries large drink, potatoes chicken spices breading salt, $8.50");
                    Console.WriteLine("3, Salad, lettuce tomatoes egg cheese croutons your choice of dressing large ice tea, lettuce tomatoes bread egg cheese, $3.50");
                    Console.WriteLine("4, Cheesecake, cheesecake with your choice of topping, cream cheese sugar milk butter vanilla, $6.95");
                    Console.WriteLine();
                    Console.WriteLine("**************************************************");
                    Console.WriteLine();
                    String sInput = Console.ReadLine();
                    MenuItem menuItem = ParseListCurrentMenuFromInput(sInput);                    
                    break;                                       

                case MenuActions.AddMenuItem:
                    RenderMainMenu();
                    Console.WriteLine("To add a new item to the menu, enter the Meal number, Name of Meal, description, ingredients, price and then hit enter");
                    sInput = Console.ReadLine();
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
                    break;

                case MenuActions.RemoveMenuItem:
                    RenderMainMenu();
                    Console.WriteLine("To remove an item from your current menu, type in the meal number and then press enter");
                    sInput = Console.ReadLine();
                    RenderMainMenu();

                    if (_currentMenu.RemoveMenuItem(Convert.ToInt32(sInput)))
                    {
                        
                        Console.WriteLine("Your item was succesfully removed. ");
                    }
                    else
                    {
                        
                        Console.WriteLine("Number entered does not exist. Please try another number.");
                    }
                    //RenderMainMenu();
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
        }        
        //public static void RenderCurrentMenu()
        //{
        //    //Console.WriteLine("**************************************************");
        //    //Console.WriteLine("Current Menu");
        //    //Console.WriteLine();
        //    //Console.WriteLine("1, Quarter Pounder, a burger, fries drink burger, $9.00");
        //    //Console.WriteLine("2, Chicken Tenders, Chicken fries large drink, potatoes chicken spices breading salt, $8.50");
        //    //Console.WriteLine("3, Salad, lettuce tomatoes egg cheese croutons your choice of dressing large ice tea, lettuce tomatoes bread egg cheese, $3.50");
        //    //Console.WriteLine("4, Cheesecake, cheesecake with your choice of topping, cream cheese sugar milk butter vanilla, $6.95");
        //    //Console.WriteLine();
        //    //Console.WriteLine("**************************************************");
        //    _currentAction = MenuActions.ListCurrentMenu;
        //}
        //public static void RenderAddMenuItem()
        //{
        //    Console.Clear();
        //    Console.WriteLine("**************************************************");
        //    Console.WriteLine();
        //    _currentAction = MenuActions.AddMenuItem;
        //}
        //public static void RenderRemoveMenuItem()
        //{
        //    Console.WriteLine("**************************************************");            
        //    _currentAction = MenuActions.RemoveMenuItem;
        //}
    }
}
