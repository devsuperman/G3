using System.Collections.Generic;
using System.Threading.Tasks;
using Garimpo3.Models;
using System.IO;
using SQLite;
using System;

namespace Garimpo3.Services
{
    public static class ProductionsService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
                return;

            var path = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "productions.db");
            db = new SQLiteAsyncConnection(path);
            await db.CreateTableAsync<Production>();
        }

        public static async Task<int> AddAsync(DateTime date, decimal amount)
        {
            await Init();
            var peon = new Production(date, amount);
            return await db.InsertAsync(peon);
        }

        public static async Task<int> UpdateAsync(Production production)
        {
            await Init();
            return await db.UpdateAsync(production);
        }

        public static async Task<int> DeleteAsync(Production production)
        {
            await Init();
            return await db.DeleteAsync(production);
        }

        public static async Task<Production> GetAsync(int id)
        {
            await Init();
            return await db.Table<Production>().Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<IEnumerable<Production>> GetAllAsync()
        {
            await Init();
            return await db.Table<Production>().ToListAsync();
        }
    }
}