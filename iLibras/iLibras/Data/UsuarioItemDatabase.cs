using System;
using SQLite;
using iLibras.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iLibras.Data
{
    public class UsuarioItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UsuarioItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Usuario>().Wait();
        }

        public Task<List<Usuario>> GetItemsAsync()
        {
            return database.Table<Usuario>().ToListAsync();
        }

        public Task<Usuario> GetItemAsync(string email, string senha)
        {
            return database.Table<Usuario>().Where(i => (i.Email == email) 
                                                   && (i.Senha == senha)).FirstOrDefaultAsync();
        }

        public Task<Usuario> GetItemAsync(int codigo)
        {
            return database.Table<Usuario>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Usuario item)
        {
            if (item.Codigo != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Usuario item)
        {
            return database.DeleteAsync(item);
        }
    }
}
