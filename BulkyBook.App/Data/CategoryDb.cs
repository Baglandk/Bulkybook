using BulkyBook.App.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.App.Data
{
    public class CategoryDb:DbContext
    {
        public CategoryDb(DbContextOptions options):base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
    }
}
