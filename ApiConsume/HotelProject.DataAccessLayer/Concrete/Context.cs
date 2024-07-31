using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Zehra;initial catalog=Hotel;integrated security=true;TrustServerCertificate=True");
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
