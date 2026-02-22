using Microsoft.EntityFrameworkCore;
using PhoneBook.m1chael888.Models;

namespace PhoneBook.m1chael888.Data
{
    internal class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=phonebook;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
