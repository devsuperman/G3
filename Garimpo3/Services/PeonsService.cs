using System.Collections.Generic;
using System.Threading.Tasks;
using Garimpo3.Models;
using System.IO;
using SQLite;

namespace Garimpo3.Services
{
    public static class PeonsService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
                return;

            db = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "peoes.db"));
            await db.CreateTableAsync<Peon>();
        }

        public static async Task<int> AddAsync(Peon peao)
        {
            await Init();
            return await db.InsertAsync(peao);
        }

        public static async Task<int> UpdateAsync(Peon peao)
        {
            await Init();
            return await db.UpdateAsync(peao);
        }

        public static async Task<int> DeleteAsync(Peon peao)
        {
            await Init();
            return await db.DeleteAsync(peao);
        }

        public static async Task<Peon > GetAsync(int id)
        {
            await Init();
            return await db.Table<Peon>().FirstOrDefaultAsync(w => w.Id == id);
        }

        public static async Task<IEnumerable<Peon>> GetAllAsync()
        {
            await Init();
            return await db.Table<Peon>().ToListAsync();
        }
    }
}