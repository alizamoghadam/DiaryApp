using Microsoft.EntityFrameworkCore;
using MyDiaryApp.Models.AppDbContext.Entities;

namespace MyDiaryApp.Models.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        //Entities
        public DbSet<Diary> Diaries { get; set; }
    }
}
