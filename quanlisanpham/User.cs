using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlisanpham
{
    class User
    {
        private string name;
        private string pass;
        private string id;
        private string price;

        public User(string id, string price, string name)
        {
            this.id = id;
            this.price = price;
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
