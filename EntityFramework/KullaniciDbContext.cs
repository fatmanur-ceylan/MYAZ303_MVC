using Microsoft.EntityFrameworkCore;
using MVC_Odev.Model;

namespace MVC_Odev.Repository
{
    public class KullaniciDbContext : DbContext
    {
        public KullaniciDbContext(DbContextOptions<KullaniciDbContext> options) : base(options)
        {

        }


        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Admin>  Admin { get; set; }
        public DbSet<Word> Word { get; set; }
    }
}