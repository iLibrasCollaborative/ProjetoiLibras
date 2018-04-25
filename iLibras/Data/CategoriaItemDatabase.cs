using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class CategoriaItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CategoriaItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Categoria>().Wait();
        }

        public List<Categoria> GetItems()
        {
            var lista = database.Table<Categoria>().ToListAsync().Result;
            return lista;
        }

        public List<string> GetItemsDescricao(){
            var items = database.Table<Categoria>().ToListAsync().Result;
            var descricoes = new List<string>();

            foreach(Categoria categoria in items)
                descricoes.Add(categoria.Descricao);

            return descricoes;
        }

        public Categoria GetItem(string descricao){
            return database.Table<Categoria>().Where(i => i.Descricao == descricao).
                           FirstOrDefaultAsync().Result;
        }

        public Categoria GetItem(int codigo)
        {
            return database.Table<Categoria>().Where(i => i.Codigo == codigo).
                           FirstOrDefaultAsync().Result;
        }

        public string GetItemAtDescricao(int codigo)
        {
            return database.Table<Categoria>().Where(i => i.Codigo == codigo).
                           FirstOrDefaultAsync().Result.Descricao;
        }

        public int SaveItem(Categoria item)
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

        public int DeleteItem(Categoria item)
        {
            return database.DeleteAsync(item).Result;
        }
    }
}
