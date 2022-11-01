using LibraryHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //generate the default authentiticatizion tables
            modelBuilder.Entity<Author_Book>().HasKey(am => new
            {
                am.AuthorId,
                am.BookId
            });
            //csharp side
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Book).WithMany(am => am.Authors_Books).HasForeignKey(m => m.BookId);
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Author).WithMany(am => am.Authors_Books).HasForeignKey(m => m.AuthorId);


            base.OnModelCreating(modelBuilder);
        }
        //table names for each model
        public DbSet<Author> Authors { get; set; } 
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Book> Authors_Books { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
