using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BooksWpfApp
{
    public class AppDBContext : DbContext
    {
        public DbSet<Authors> Authors { get; set; }

        public DbSet<AuthorISBN> AuthorISBN { get; set; }

        public DbSet<Titles> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Iris_college\\Courses\\Semester2\\Comp212_Program3\\Labs\\Lab3\\301072868(meko)_Lab3\\301072868(meko)_Lab3\\BooksWpfApp\\database\\Books.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AuthorISBN>().HasKey(e => new { e.AuthorID, e.ISBN});

        }
    }
}
