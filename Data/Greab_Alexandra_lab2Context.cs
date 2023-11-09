using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Greab_Alexandra_lab2.Models;

namespace Greab_Alexandra_lab2.Data
{
    public class Greab_Alexandra_lab2Context : DbContext
    {
        public Greab_Alexandra_lab2Context (DbContextOptions<Greab_Alexandra_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Greab_Alexandra_lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Greab_Alexandra_lab2.Models.Borrowing> Borrowings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(b => b.Book)
                .HasForeignKey<Borrowing>(b => b.BookID);
        }

        public DbSet<Greab_Alexandra_lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Greab_Alexandra_lab2.Models.Author>? Author { get; set; }

        public DbSet<Greab_Alexandra_lab2.Models.Category>? Category { get; set; }

        public DbSet<Greab_Alexandra_lab2.Models.Member>? Member { get; set; }

    }
}
