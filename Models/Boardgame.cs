using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Heghes_Bogdan_Lab8.Models
{
    public class Boardgame
    {
        public int ID { get; set; }
        [Display(Name = "Boardgame Name")]
        public string Name { get; set; }
        public string Author { get; set; }

        [Column(TypeName ="decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BoardgameCategory> BoardgameCategories { get; set; }
    }
}
