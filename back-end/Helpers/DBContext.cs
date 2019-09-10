using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Helpers
{
    public class DBContext : DbContext 
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { } 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldDetail> FieldDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
    }
}