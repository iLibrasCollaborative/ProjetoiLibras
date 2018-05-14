using System;
using System.Collections.Generic;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class EscritaSinaisItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public EscritaSinaisItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<EscritaSinais>().Wait();
        }

        public List<EscritaSinais> GetItems()
        {
            var lista = database.Table<EscritaSinais>().ToListAsync().Result;
            return lista;
        }

        public List<EscritaSinais> GetItemsSinal(int codigoSinal)
        {
            return database.Table<EscritaSinais>().Where(i => i.CodigoSinal == codigoSinal).ToListAsync().Result;
        }

        public EscritaSinais GetItem(int codigo)
        {
            return database.Table<EscritaSinais>().Where(i => i.Codigo == codigo).
                           FirstOrDefaultAsync().Result;
        }

        public int SaveItem(EscritaSinais item)
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

        public int DeleteItem(EscritaSinais item)
        {
            return database.DeleteAsync(item).Result;
        }
    }
}
