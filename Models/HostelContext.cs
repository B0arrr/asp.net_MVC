using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class HostelContext : DbContext
    {
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Pokoj> Pokoje { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }
        public DbSet<Klient> Clients { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=localhost;Database=hostels;Trusted_Connection=True;");
        //     optionsBuilder.UseSqlite(@"Data Source=C:\db\mydb.db;");
        // }
        public HostelContext(DbContextOptions<HostelContext> options)
            : base(options)
        {
        }
    }
}