using System;
using System.Collections.Generic;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class PerfilItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public PerfilItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Perfil>().Wait();
        }

        public List<Perfil> GetItems()
        {
            return database.Table<Perfil>().ToListAsync().Result;
        }

        public List<string> GetItemsString(){
            var perfis = GetItems();
            var lista = new List<string>();

            foreach(Perfil perfil in perfis)
                if(!perfil.Descricao.Equals("Admin"))
                    lista.Add(perfil.Descricao);

            return lista;
        }

        public Perfil GetItem(string descricao){
            return database.Table<Perfil>().Where(i => i.Descricao == descricao).FirstOrDefaultAsync().Result;
        }

        public Perfil GetItem(int codigo)
        {
            return database.Table<Perfil>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync().Result;
        }

        public int SaveItem(Perfil item)
        {
            if (item.Codigo != 0)
                return database.UpdateAsync(item).Result;
            else
                return database.InsertAsync(item).Result;
        }
    }
}
