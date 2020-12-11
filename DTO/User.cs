using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        private string id;
        private string price;
        private string name;
        private string amount;
        public string Id { get => id; set => id = value; }
        public string Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public string Amount { get => amount; set => amount = value; }

        public User(string id, string price, string name, string amount)
        {
            this.id = id;
            this.price = price;
            this.name = name;
            this.amount = amount;
        }

        public User(string amount)
        {
            this.amount = amount;
        }
    }
}
