using System;
using System.Collections.Generic;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class ContextoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ContextoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Contexto>().Wait();
        }

        public List<Contexto> GetItems()
        {
            var lista = database.Table<Contexto>().ToListAsync().Result;
            return lista;
        }

        public Contexto GetItem(string descricao)
        {
            return database.Table<Contexto>().Where(i => i.Descricao == descricao).
                           FirstOrDefaultAsync().Result;
        }

        public Contexto GetItem(int codigo)
        {
            return database.Table<Contexto>().Where(i => i.Codigo == codigo).
                           FirstOrDefaultAsync().Result;
        }

        public string GetItemAtDescricao(int codigo)
        {
            return database.Table<Contexto>().Where(i => i.Codigo == codigo).
                           FirstOrDefaultAsync().Result.Descricao;
        }

        public int SaveItem(Contexto item)
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

        public int DeleteItem(Contexto item)
        {
            return database.DeleteAsync(item).Result;
        }
    }
}
