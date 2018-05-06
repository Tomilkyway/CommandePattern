using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommandePattern
{
    public class DataBaseContext : DbContext {

        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=commandePattern.db");
        }

        public void displayDataBase() {
            foreach (Article article in Articles) {
                System.Console.WriteLine(article);
            }
            Console.Write("\n");
        }

    }
}
