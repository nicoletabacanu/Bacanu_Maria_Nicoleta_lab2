using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bacanu_Maria_Nicoleta_lab2.Models;

namespace Bacanu_Maria_Nicoleta_lab2.Data
{
    public class Bacanu_Maria_Nicoleta_lab2Context : DbContext
    {
        public Bacanu_Maria_Nicoleta_lab2Context (DbContextOptions<Bacanu_Maria_Nicoleta_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Bacanu_Maria_Nicoleta_lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Bacanu_Maria_Nicoleta_lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Bacanu_Maria_Nicoleta_lab2.Models.Author>? Authors { get; set; } = default!;

        public DbSet<Bacanu_Maria_Nicoleta_lab2.Models.BookCategory>? BookCategory { get; set; }

        public DbSet<Bacanu_Maria_Nicoleta_lab2.Models.Category>? Category { get; set; }

    }
}
