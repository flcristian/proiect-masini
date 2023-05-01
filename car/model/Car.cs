using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_liste.car.model
{
    internal class Car
    {
        private int _id;
        private int _year;
        private string _make;
        private string _model;
        private string _type;
        private string _fuelType;
        private string _transmissionType;
        private string _drivetrainType;
        private string _color;
        private List<string> _tags = new List<string>();

        // Constructori

        public Car(int id, int year, string make, string model, string type, string fuelType, string transmissionType, string drivetrainType, string color)
        {
            _id = id;
            _year = year;
            _make = make;
            _model = model;
            _type = type;
            _fuelType = fuelType;
            _transmissionType = transmissionType;
            _drivetrainType = drivetrainType;
            _color = color;

            this.AssignTagsAutomatically();
        }

        // Accesorii

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
            }
        }

        public string Make
        {
            get { return _make; }
            set
            {
                _make = value;
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public string FuelType
        {
            get { return _fuelType; }
            set
            {
                _fuelType = value;
            }
        }

        public string TransmissionType
        {
            get { return _transmissionType; }
            set
            {
                _transmissionType = value;
            }
        }

        public string DrivetrainType
        {
            get { return _drivetrainType; }
            set
            {
                _drivetrainType = value;
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
            }
        }

        public List<string> Tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
            }
        }

        // Metode

        public void AssignTagsAutomatically()
        {
            List<string> tags = new List<string>();
            char[] separators = { ' ', ',', ';', '-', '.', ':' };

            string[] make = _make.Split(separators);
            for(int i = 0; i < make.Count(); i++)
            {
                string tag = make[i].ToLower();
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);
                }
            }

            string[] model = _model.Split(separators);
            for (int i = 0; i < model.Count(); i++)
            {
                string tag = model[i].ToLower();
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);
                }
            }

            string[] type = _type.Split(separators);
            for (int i = 0; i < type.Count(); i++)
            {
                string tag = type[i].ToLower();
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);
                }
            }

            string[] fuelType = _fuelType.Split(separators);
            for (int i = 0; i < fuelType.Count(); i++)
            {
                string tag = fuelType[i].ToLower();
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);
                }
            }

            string[] transmissionType = _transmissionType.Split(separators);
            for (int i = 0; i < transmissionType.Count(); i++)
            {
                string tag = transmissionType[i].ToLower();
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);
                }
            }

            string[] drivetrainType = _drivetrainType.Split(separators);
            for (int i = 0; i < drivetrainType.Count(); i++)
            {
                string tag = drivetrainType[i].ToLower();
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);
                }
            }

            string[] color = _color.Split(separators);
            for (int i = 0; i < color.Count(); i++)
            {
                string tag = color[i].ToLower();
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);
                }
            }

            tags.Add(_year.ToString());

            _tags = tags;
        }
        
        public void AddTag(string tag)
        {
            _tags.Add(tag);
        }

        public void RemoveTag(string tag)
        {
            _tags.Remove(tag);
        }

        public string Description()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Year : " + _year + "\n";
            desc += "Make : " + _make + "\n";
            desc += "Model : " + _model + "\n";
            desc += "Type : " + _type + "\n";
            desc += "Fuel Type : " + _fuelType + "\n";
            desc += "Transmission Type : " + _transmissionType + "\n"; 
            desc += "Drivetrain Type : " + _drivetrainType + "\n";
            desc += "Color : " + _color + "\n";
            desc += "Tags : ";
            foreach(string tag in _tags){
                desc += tag + " ";
            }

            return desc;
        }

    }
}
