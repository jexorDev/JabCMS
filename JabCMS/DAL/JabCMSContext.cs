using JabCMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JabCMS.DAL
{
    public class JabCMSContext : DbContext
    {
        public DbSet<Post> Posts {get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                        .HasMany(p => p.Categories)
                        .WithMany(c => c.Posts)
                        .Map(t => t.MapLeftKey("PostId")
                                   .MapRightKey("CategoryId")
                                   .ToTable("PostCategory"));
        }        
    }
}