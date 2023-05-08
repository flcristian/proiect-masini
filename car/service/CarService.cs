using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using test_liste.car.model;
using static System.Formats.Asn1.AsnWriter;

namespace test_liste.car.service
{
    internal class CarService
    {
        private List<Car> _listCar;

        public CarService()
        {
            _listCar = new List<Car>();
            this.ReadList();
        }

        // Metode

        // Load function no more used.
        public void Load()
        {
            Car c1 = new Car(7812, 2017, "Mercedes-Benz", "GLC Coupe 350 e 4MATIC", "SUV", "Hybrid", "Automatic", "4X4", "Blue");
            Car c2 = new Car(1771, 2020, "Mercedes-Benz", "AMG GT-S 53 4MATIC+", "Coupe", "Petrol", "Automatic", "AWD", "Silver");
            Car c3 = new Car(8133, 2020, "Audi", "A4 35 TFSI S tronic", "Sedan", "Petrol", "Automatic", "FWD", "Black");
            Car c4 = new Car(4575, 2008, "Honda", "Accord", "Hatchback", "Diesel", "Manual", "RWD", "White");
            Car c5 = new Car(6121, 2016, "Subaru", "WRX STI 2.5 Sport", "Sedan", "Petrol", "Manual", "AWD", "Black");
            Car c6 = new Car(9525, 2016, "Subaru", "WRX STI 2.5 Sport", "Sedan", "Petrol", "Manual", "AWD", "White");
            Car c7 = new Car(2594, 2021, "BMW", "730d xDrive MHEV", "Sedan", "Diesel", "Automatic", "RWD", "Black");
            Car c8 = new Car(6417, 2022, "Mercedes-Benz", "GLE Coupe AMG 63 S MHEV 4MATIC+", "SUV", "Hybrid", "Automatic", "4X4", "Silver");

            _listCar.Add(c1);
            _listCar.Add(c2);
            _listCar.Add(c3);
            _listCar.Add(c4);
            _listCar.Add(c5);
            _listCar.Add(c6);
            _listCar.Add(c7);
            _listCar.Add(c8);
        }
        
        public void ReadList()
        {
            _listCar.Clear();
            StreamReader sr = new StreamReader("../../../data/carlist.txt");

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] data = line.Split('/');
                Car car = new Car(Int32.Parse(data[0]), Int32.Parse(data[1]), data[2], data[3], data[4], data[5], data[6], data[7], data[8]);

                _listCar.Add(car);
            }

            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("../../../data/carlist.txt");

            foreach(Car c in _listCar)
            {
                sw.WriteLine($"{c.Id}/{c.Year}/{c.Make}/{c.Model}/{c.Type}/{c.FuelType}/{c.TransmissionType}/{c.DrivetrainType}/{c.Color}");
            }

            sw.Close();
        }

        public void Display()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            foreach(Car c in _listCar)
            {
                Console.WriteLine(c.Description() + "\n");
            }
        }

        public Car FindById(int id)
        {
            foreach(Car c in _listCar)
            {
                if(c.Id == id)
                {
                    return c;
                }
            }

            return null;
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 9999);
            while (this.FindById(id) != null)
            {
                id = rnd.Next(1, 9999);
            }
            return id;
        }

        public void RemoveById(int id)
        {
            _listCar.Remove(this.FindById(id));
        }

        public void RemoveByTag(string tag)
        {
            List<Car> cars = this.SearchForTag(tag);
            foreach(Car c in cars)
            {
                _listCar.Remove(c);
            }
        }

        public void RemoveAllCars()
        {
            List<Car> cars = new List<Car>();
            _listCar = cars;
        }

        public void AddCar(Car car)
        {
            car.Id = this.NewId();
            _listCar.Add(car);
        }

        public void EditCar(Car car)
        {
            for(int i = 0; i < _listCar.Count(); i++)
            {
                Car c = _listCar[i];
                if(c.Id == car.Id)
                {
                    c = car;                    
                }                
                break;
            }
        }

        public int CarCount()
        {
            return _listCar.Count();
        }

        // Returns a list of objects that contain a specific tag.
        public List<Car> SearchForTag(string input)
        {
            List<Car> list = new List<Car>();
            foreach(Car c in _listCar)
            {
                if (c.Tags.Contains(input.ToLower()))
                {
                    list.Add(c);
                }
            }
            return list;
        }
    }
}
