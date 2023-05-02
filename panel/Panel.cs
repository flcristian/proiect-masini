using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_liste.car.model;
using test_liste.car.service;

namespace test_liste.panel
{
    internal class Panel
    {
        CarService _carService;

        public Panel()
        {
            _carService = new CarService();

            bool running = true;
            string k;
            while (running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Display - Display all cars.");
                Console.WriteLine("Search - Search for cars.");
                Console.WriteLine("Remove - Remove cars.");

                Console.WriteLine("\nOther - End the program.\n");

                k = Console.ReadLine();

                Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

                switch (k.ToLower())
                {
                    case "display":
                        this.Display();
                        break;
                    case "search":
                        this.Search();
                        break;
                    case "remove":
                        this.RemoveCars();
                        break;
                    default:
                        running = false;
                        break;
                }
            }
        }

        // Metode

        // Display all current cars.

        public void Display()
        {
            _carService.Display();
        }

        // Searches for a tag and displays found cars.
        public void Search()
        {
            string input = "";
            Console.WriteLine("Type a tag you want to search for :\n");
            input = Console.ReadLine();
            Console.WriteLine("\nYour results are :\n");

            List<Car> list = _carService.SearchForTag(input);
            foreach (Car c in list)
            {
                Console.WriteLine(c.Description() + "\n");
            }
        }

        // Removes cars.
        public void RemoveCars()
        {
            Console.WriteLine("What do you want to remove cars by :\n");
            Console.WriteLine("Id - Remove a car that has a specific id.");
            Console.WriteLine("Tag - Remove all cars with a certain tag.\n");

            string choice1 = Console.ReadLine();

            int count = 0;

            switch (choice1.ToLower())
            {
                case "id":
                    Console.WriteLine("\nType the id of the car you want removed :\n");
                    int id = Console.Read();
                    if (_carService.FindById(id) != null)
                    {
                        _carService.RemoveById(id);
                        count = 1;
                    }                   
                    break;
                case "tag":
                    Console.WriteLine("\nType what tag to remove cars by :\n");
                    string tag = Console.ReadLine();
                    count = _carService.SearchForTag(tag).Count();
                    if(count > 0)
                    {
                        _carService.RemoveByTag(tag);
                    }                    
                    break;
                default:
                    break;
            }

            if (count > 0)
            {
                Console.WriteLine($"\nRemoved {count} cars succesfully!\nDo you want to display the new car list? (Y/N) :\n");
                string choice2 = Console.ReadLine();
                Console.WriteLine();
                switch (choice2.ToLower())
                {
                    case "y":
                        _carService.Display();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nNo cars found by specified parameters.\n");
            }
            
        }
    }
}
