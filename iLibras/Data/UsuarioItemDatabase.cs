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

        public List<Usuario> GetItems()
        {
            return database.Table<Usuario>().ToListAsync().Result;
        }

        public Usuario GetLogin(string email, string senha)
        {
            return database.Table<Usuario>().Where(i => (i.Email == email) 
                                                   && (i.Senha == senha)).FirstOrDefaultAsync().Result;
        }

        public List<Usuario> GetItemsForPerfil()
        {
            return database.Table<Usuario>().Where(i => (i.Perfil > 1)).ToListAsync().Result;
        }

        public Usuario GetItem(int codigo)
        {
            return database.Table<Usuario>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync().Result;
        }

        public Usuario GetItem(string email)
        {
            return database.Table<Usuario>().Where(i => i.Email == email).FirstOrDefaultAsync().Result;
        }

        public int SaveItem(Usuario item)
        {
            if (GetItem(item.Email) != null)
            {
                return database.UpdateAsync(item).Result;
            }
            else
            {
                return database.InsertAsync(item).Result;
            }
        }

        public int DeleteItemAsync(Usuario item)
        {
            return database.DeleteAsync(item).Result;
        }
    }
}
