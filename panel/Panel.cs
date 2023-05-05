using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_liste.car.model;
using test_liste.car.service;
using test_liste.admin.model;
using test_liste.admin.service;
using System.Collections.Specialized;

namespace test_liste.panel
{
    internal class Panel
    {
        CarService _carService;

        public Panel()
        {
            _carService = new CarService();
            Admin _admin = new Admin(1, "George", "george@gmail.com", "parola");

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine($"Welcome {_admin.Name}!\n");

            bool running = true;
            this.Main(running);
        }

        // Pages

        public void Main(bool _running)
        {
            while (_running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("1 - Display all cars.");
                Console.WriteLine("2 - Search for cars.");
                Console.WriteLine("3 - Edit the car list.");

                Console.WriteLine("\nAnything else to end the program.\n");

                string choice = Console.ReadLine();

                Console.WriteLine();

                bool running = true;
                switch (choice.ToLower())
                {
                    case "1":
                        this.Display();
                        break;
                    case "2":
                        this.Search();
                        break;
                    case "3":
                        this.EditCars(running);
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        public void EditCars(bool _running)
        {
            while (_running)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("Type what you want to do :\n");
                Console.WriteLine("1 - Add a car.");
                Console.WriteLine("2 - Remove cars.");
                Console.WriteLine("3 - Edit a car.");

                Console.WriteLine("\nAnything else to close the edit tab.\n");

                string choice1 = Console.ReadLine();

                Console.WriteLine();

                switch (choice1.ToLower())
                {
                    case "1":
                        this.AddCar();
                        break;
                    case "2":
                        this.RemoveCars();
                        break;
                    case "3":
                        break;
                    default:
                        _running = false;
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
            Console.WriteLine("Type a tag you want to search for :\n");
            string input = Console.ReadLine();
            Console.WriteLine();

            List<Car> list = _carService.SearchForTag(input);
            if(list.Count > 0)
            {
                Console.WriteLine("Your results are :\n");

                foreach (Car c in list)
                {
                    Console.WriteLine(c.Description() + "\n");
                }
            }
            else
            {
                Console.WriteLine("There were no cars found!\n");
            }
            
        }

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

        public void AddCar()
        {
            Console.Write("Enter the car's year : ");
            int year = Int32.Parse(Console.ReadLine());
            Console.Write("Enter the car's maker : ");
            string make = Console.ReadLine();
            Console.Write("Enter the car's model : ");
            string model = Console.ReadLine();
            Console.Write("Enter the car's type : ");
            string type = Console.ReadLine();
            Console.Write("Enter the car's fuel type : ");
            string fuelType = Console.ReadLine();
            Console.Write("Enter the car's transmission type : ");
            string transmissionType = Console.ReadLine();
            Console.Write("Enter the car's drivetrain type : ");
            string drivetrainType = Console.ReadLine();
            Console.Write("Enter the car's color : ");
            string color = Console.ReadLine();

            Car car = new Car(0, year, make, model, type, fuelType, transmissionType, drivetrainType, color);

            _carService.AddCar(car);

            Console.WriteLine("\nThe car was added succesfully!\n");
        }
    }
}
