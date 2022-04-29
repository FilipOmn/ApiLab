using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3_API.Models
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterests> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<LinkInterest> LinkInterests { get; set; }
        public DbSet<PersonLinks> PersonLinks { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FFB4Q97\SQLEXPRESS;Initial Catalog=APIlab_3DB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, PersonName = "Andreas", Phone = "076 111 22 33" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, PersonName = "Anders", Phone = "076 222 33 44" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, PersonName = "Maya", Phone = "076 333 44 55" });

            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 1, InterestTitle = "Programming", Description = "an interest in programming.." });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 2, InterestTitle = "Reading", Description = "an interest in reading books and such" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 3, InterestTitle = "Food", Description = "an interest in cooking/eating food and other edibles" });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestId = 4, InterestTitle = "Fishing", Description = "an interest in fishing" });

            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 1, Link_ = "https://stackoverflow.com/" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 2, Link_ = "https://www.w3schools.com/" });
            modelBuilder.Entity<Link>().HasData(new Link { LinkId = 3, Link_ = "https://books.google.com/" });

            modelBuilder.Entity<PersonInterests>()
                .HasOne(p => p.Person)
                .WithMany(pi => pi.PersonInterests)
                .HasForeignKey(pid => pid.PersonId);

            modelBuilder.Entity<PersonInterests>()
              .HasOne(p => p.Interest)
              .WithMany(pi => pi.PersonInterests)
              .HasForeignKey(pid => pid.InterestId);

            modelBuilder.Entity<LinkInterest>()
                .HasOne(p => p.Interest)
                .WithMany(pi => pi.LinkInterests)
                .HasForeignKey(pid => pid.InterestId);

            modelBuilder.Entity<LinkInterest>()
              .HasOne(p => p.Link)
              .WithMany(pi => pi.LinkInterests)
              .HasForeignKey(pid => pid.LinkId);

            modelBuilder.Entity<PersonLinks>()
               .HasOne(p => p.Person)
               .WithMany(pi => pi.PersonLinks)
               .HasForeignKey(pid => pid.PersonId);

            modelBuilder.Entity<PersonLinks>()
              .HasOne(p => p.Link)
              .WithMany(pi => pi.PersonLinks)
              .HasForeignKey(pid => pid.LinkId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
