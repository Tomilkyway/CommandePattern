using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommandePattern
{
    public class DataBaseContext : DbContext {

        public DbSet<Article> Articles { get; set; }

        // Create and use a .db file which corresponds to the SQlite database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=commandePattern.db");
        }

        // Foreach in the table Article in order to display all the articles
        public void displayDataBase() {
            foreach (Article article in Articles) {
                System.Console.WriteLine(article);
            }
            Console.Write("\n");
        }

    }
}
