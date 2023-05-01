using System;
using System.Collections.Generic;
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
            int k;
            while (running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("\n1 - Display all cars.\n2 - Search for cars.\n3 - Remove cars.\n");

                k = Console.Read();

            }
        }

        // Metode

        // Searches for a tag and displays found cars.
        public void Search()
        {
            string input = "";
            Console.WriteLine("Type a tag you want to search for :\n");
            input = Console.ReadLine();
            Console.WriteLine();

            List<Car> list = _carService.SearchForTag(input);
            foreach (Car c in list)
            {
                Console.WriteLine(c.Description() + "\n");
            }
        }

        // Removes cars.
        public void RemoveCars()
        {
            Console.WriteLine("Type what tag to remove cars by :\n");
            string tag = Console.ReadLine();
            _carService.RemoveByTag(tag);
            Console.WriteLine("\nRemoved cars succesfully!\nDo you want to display the new car list? (Y/N) :\n");
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "Y":
                    _carService.Display();
                    break;
                default:
                    break;
            }
        }
    }
}
