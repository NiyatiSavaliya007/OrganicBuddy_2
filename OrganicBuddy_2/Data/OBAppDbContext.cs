using Microsoft.EntityFrameworkCore;
using OrganicBuddy_2.Models;

namespace OrganicBuddy_2.Data
{
    public class OBAppDbContext : DbContext
    {
        public OBAppDbContext(DbContextOptions<OBAppDbContext> options) : base(options)
        {
        }
        
        public DbSet<BolgCat> BlogCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Cat> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProCat> ProdCategories { get; set; }
        public DbSet<Pro> Products { get; set; }
        public DbSet<TypeModel> Types { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
//