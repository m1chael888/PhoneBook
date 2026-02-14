using Microsoft.EntityFrameworkCore;
using PhoneBook.m1chael888.Models;

namespace PhoneBook.m1chael888.Infrastructure
{
    internal class PhoneBookContext : DbContext
    {
        private readonly string _connectionString;
        public PhoneBookContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
