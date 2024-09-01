using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Department
    {
        private int _id;
        public int id
        {
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            get
            {
                return _id;
            }
        }

        private string? _name;
        public string? name
        {
            protected set
            {
                if (value?.Length > 2)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            get
            {
                return _name;
            }
        }
        private string? _shortName;
        public string? shortName
        {
            protected set
            {
                if (value?.Length < 6)
                {
                    _shortName = value;
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            get
            {
                return _shortName;
            }
        }
        private string? _address;
        public string? address
        {
            protected set
            {
                if (value?.Length > 1)
                {
                    _address = value;
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            get
            {
                return _address;
            }
        }

        public Department(string? name, string? shortName, string? address)
        {
            this.name = name;
            this.shortName = shortName;
            this.address = address;
        }
        public void printInfo()
        {
            Console.WriteLine($"Кафедра {name} ({shortName}) - {address}");
        }
    }
}
