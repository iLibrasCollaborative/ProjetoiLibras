    using System;
using SQLite;
using iLibras.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iLibras.Data
{
    public class TagItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TagItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Tag>().Wait();
        }

        public List<Tag> GetItemsAsync()
        {
            return database.Table<Tag>().ToListAsync().Result;
        }

        public Tag GetItemAsync(int codigo)
        {
            return database.Table<Tag>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync().Result;
        }

        public bool IsUsingCategoria(int codigo){


            var result = database.Table<Tag>().Where(i => i.CodigoCategoria == codigo).ToListAsync().Result;

            return result.Count > 0;
        }

        public int SaveItemAsync(Tag item)
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

        public int DeleteItemAsync(Tag item)
        {
            return database.DeleteAsync(item).Result;
        }
    }
}
