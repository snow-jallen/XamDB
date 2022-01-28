using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamDB.Models;

namespace XamDB.Services
{
    internal class SqliteDataStore : IDataStore<Item>
    {
        private AppDbContext context;

        public SqliteDataStore()
        {
            context = new AppDbContext();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            context.Items.Add(item);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var item = await context.Items.FindAsync(id);
            if (item != null)
            {
                context.Items.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await context.Items.ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
            return true;
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public AppDbContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "items.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
