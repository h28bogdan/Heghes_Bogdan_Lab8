using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heghes_Bogdan_Lab8.Models
{
    public class BoardgameCategory
    {
        public int ID { get; set; }
        public int BoardgameID { get; set; }
        public Boardgame Boardgame { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
