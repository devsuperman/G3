﻿using System.Collections.Generic;
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

            var path = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "peoes.db");
            db = new SQLiteAsyncConnection(path);
            await db.CreateTableAsync<Peon>();
        }

        public static async Task<int> AddAsync(string name)
        {
            await Init();
            var peon = new Peon(name);
            return await db.InsertAsync(peon);
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

        public static async Task<Peon> GetAsync(int id)
        {
            await Init();
            return await db.Table<Peon>().Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<IEnumerable<Peon>> GetAllAsync()
        {
            await Init();
            return await db.Table<Peon>().ToListAsync();
        }
    }
}