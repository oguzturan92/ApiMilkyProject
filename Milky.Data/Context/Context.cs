using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Milky.Entity.Concrete;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(@"Server=.\SQLEXPRESS;Database=milkyApi;Integrated Security=True;");
        }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SiteSocialMedia> SiteSocialMedias { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}