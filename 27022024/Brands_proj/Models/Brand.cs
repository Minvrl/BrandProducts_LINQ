using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brands_proj.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundedAt { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} - {FoundedAt.ToString("dd.MM.yyyy")}";
        }
    }

    

}
