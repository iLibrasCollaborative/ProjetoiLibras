using System;
using System.Collections.Generic;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class SinalItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SinalItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Sinal>().Wait();
        }

        public List<Sinal> GetItems()
        {
            var lista = database.Table<Sinal>().ToListAsync().Result;
            return lista;
        }

        public Sinal GetItem(int codigo)
        {
            return database.Table<Sinal>().Where(i => i.Codigo == codigo).
                           FirstOrDefaultAsync().Result;
        }

        public int SaveItem(Sinal item)
        {
            if (item.Codigo != 0)
            {
                return database.UpdateAsync(item).Result;
            }
            else
            {
                return database.InsertAsync(item).Result;
            }
        }

        public int DeleteItem(Sinal item)
        {
            return database.DeleteAsync(item).Result;
        }
    }
}
