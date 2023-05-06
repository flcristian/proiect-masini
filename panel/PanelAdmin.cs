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
using Microsoft.VisualBasic.FileIO;
using System.Drawing;

namespace test_liste.panel
{
    internal class PanelAdmin
    {
        CarService _carService;

        public PanelAdmin()
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
                        this.EditCarList(running);
                        break;
                    default:
                        _running = false;
                        break;
                }
            }
        }

        public void EditCarList(bool _running)
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
                        this.EditCar();
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
            if(_carService.CarCount() > 0)
            {
                _carService.Display();
            }
            else
            {
                Console.WriteLine("There were no cars found!\n");
            }
            
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
            Console.WriteLine("Tag - Remove all cars with a certain tag.");
            Console.WriteLine("All - Remove every car from the list.\n");

            string choice1 = Console.ReadLine();

            int count = 0;

            bool notall = true;
            switch (choice1.ToLower())
            {
                case "id":
                    Console.WriteLine("\nType the id of the car you want removed :\n");
                    int id = Int32.Parse(Console.ReadLine());
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

                case "all":
                    Console.Write("\nAre you sure you want to remove all cars? (Y / N) : ");
                    string choice2 = Console.ReadLine();
                    count = _carService.CarCount();
                    if (choice2.ToLower().Equals("y"))
                    {
                        _carService.RemoveAllCars();
                    }

                    notall = false;
                    break;
                default:
                    break;
            }

            if (count > 0)
            {
                Console.WriteLine($"\nRemoved {count} cars succesfully!\n");
                if (notall)
                {
                    Console.Write("Do you want to display the new car list? (Y / N) : ");
                    string choice3 = Console.ReadLine();
                    Console.WriteLine();
                    if (choice3.ToLower().Equals("y"))
                    {
                        _carService.Display();
                    }
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

        public void EditCar()
        {
            Console.WriteLine("Type the id of the car you want to edit :\n");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            Car car = _carService.FindById(id);
            if(car == null)
            {
                Console.WriteLine("Car not found.\n");
            }
            else
            {
                Console.WriteLine("Type what you want to edit :");
                Console.WriteLine("1 - Edit the car's year.");
                Console.WriteLine("2 - Edit the car's make.");
                Console.WriteLine("3 - Edit the car's model.");
                Console.WriteLine("4 - Edit the car's type.");
                Console.WriteLine("5 - Edit the car's fuel type.");
                Console.WriteLine("6 - Edit the car's transmission type.");
                Console.WriteLine("7 - Edit the car's drivetrain type.");
                Console.WriteLine("8 - Edit the car's color.");
                Console.WriteLine("9 - Edit the entire car.");
                Console.WriteLine("Anything else to cancel.");

                string choice = Console.ReadLine();
                Console.WriteLine();

                bool edited = false;
                int year;
                string make, model, type, fuelType, transmissionType, drivetrainType, color;
                switch (choice.ToLower())
                {
                    case "1":
                        Console.Write("Enter the car's year : ");
                        year = Int32.Parse(Console.ReadLine());

                        car.Year = year;
                        edited = true;
                        break;

                    case "2":
                        Console.Write("Enter the car's maker : ");
                        make = Console.ReadLine();

                        car.Make = make;
                        edited = true;
                        break;

                    case "3":
                        model = Console.ReadLine();
                        Console.Write("Enter the car's type : ");

                        car.Model = model;
                        edited = true;
                        break;

                    case "4":
                        Console.Write("Enter the car's type : ");
                        type = Console.ReadLine();

                        car.Type = type;
                        edited = true;
                        break;

                    case "5":
                        Console.Write("Enter the car's fuel type : ");
                        fuelType = Console.ReadLine();

                        car.FuelType = fuelType;
                        edited = true;
                        break;

                    case "6":
                        Console.Write("Enter the car's transmission type : ");
                        transmissionType = Console.ReadLine();

                        car.TransmissionType = transmissionType;
                        edited = true;
                        break;

                    case "7":
                        Console.Write("Enter the car's drivetrain type : ");
                        drivetrainType = Console.ReadLine();

                        car.DrivetrainType = drivetrainType;
                        edited = true;
                        break;

                    case "8":
                        Console.Write("Enter the car's color : ");
                        color = Console.ReadLine();

                        car.Color = color;
                        edited = true;
                        break;

                    case "9":
                        Console.Write("Enter the car's year : ");
                        year = Int32.Parse(Console.ReadLine());
                        Console.Write("Enter the car's maker : ");
                        make = Console.ReadLine();
                        Console.Write("Enter the car's model : ");
                        model = Console.ReadLine();
                        Console.Write("Enter the car's type : ");
                        type = Console.ReadLine();
                        Console.Write("Enter the car's fuel type : ");
                        fuelType = Console.ReadLine();
                        Console.Write("Enter the car's transmission type : ");
                        transmissionType = Console.ReadLine();
                        Console.Write("Enter the car's drivetrain type : ");
                        drivetrainType = Console.ReadLine();
                        Console.Write("Enter the car's color : ");
                        color = Console.ReadLine();

                        car.Year = year;
                        car.Make = make;
                        car.Model = model;
                        car.Type = type;
                        car.FuelType = fuelType;
                        car.TransmissionType = transmissionType;
                        car.DrivetrainType = drivetrainType;
                        car.Color = color;

                        edited = true;
                        break;

                    default:
                        break;
                }

                if (edited)
                {
                    List<string> tags = new List<string>();
                    car.Tags = tags;
                    car.AssignTagsAutomatically();
                    _carService.EditCar(car);

                    Console.WriteLine("\nThe car has been edited succesfully!\n");
                }
                else
                {
                    Console.WriteLine("\nThe car was not edited.\n");
                }
            }
        }
    }
}
