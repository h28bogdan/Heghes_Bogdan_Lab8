using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heghes_Bogdan_Lab8.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BoardgameCategory> BoargameCategories { get; set; }
    }
}
