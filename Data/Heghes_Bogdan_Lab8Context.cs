using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Heghes_Bogdan_Lab8.Models;

namespace Heghes_Bogdan_Lab8.Data
{
    public class Heghes_Bogdan_Lab8Context : DbContext
    {
        public Heghes_Bogdan_Lab8Context (DbContextOptions<Heghes_Bogdan_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Heghes_Bogdan_Lab8.Models.Boardgame> Boardgame { get; set; }

        public DbSet<Heghes_Bogdan_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Heghes_Bogdan_Lab8.Models.Category> Category { get; set; }
    }
}
