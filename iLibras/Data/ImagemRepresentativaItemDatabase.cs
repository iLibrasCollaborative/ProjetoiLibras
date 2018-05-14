using System;
using System.Collections.Generic;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class ImagemRepresentativaItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ImagemRepresentativaItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ImagemRepresentativa>().Wait();
        }

        public List<ImagemRepresentativa> GetItems()
        {
            var lista = database.Table<ImagemRepresentativa>().ToListAsync().Result;
            return lista;
        }

        public List<ImagemRepresentativa> GetItemsSinal(int codigoSinal)
        {
            return database.Table<ImagemRepresentativa>().Where(i => i.CodigoSinal == codigoSinal).ToListAsync().Result;
        }

        public ImagemRepresentativa GetItem(int codigo)
        {
            return database.Table<ImagemRepresentativa>().Where(i => i.Codigo == codigo).
                           FirstOrDefaultAsync().Result;
        }

        public int SaveItem(ImagemRepresentativa item)
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

        public int DeleteItem(ImagemRepresentativa item)
        {
            return database.DeleteAsync(item).Result;
        }
    }
}
