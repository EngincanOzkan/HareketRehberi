using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HareketRehberi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SystemUser> SystemUsers { get; set; }
    }
}
