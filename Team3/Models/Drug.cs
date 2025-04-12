using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Administration { get; set; }

        public Drug(int id, string name, string administration)
        {
            this.Id = id;
            this.Name = name;
            this.Administration = administration;
        }
        override
        public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Administration: {Administration}";
        }
    }
}
