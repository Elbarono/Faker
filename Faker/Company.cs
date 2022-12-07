using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Product { get; set; }
        public Company()
        {
            Id = 10;
            Name = "NoName";
        }
    }
}
