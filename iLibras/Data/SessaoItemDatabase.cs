using System;
using System.Collections.Generic;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class SessaoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SessaoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Sessao>().Wait();
        }

        public Sessao GetItem()
        {
            if(database.Table<Sessao>().FirstOrDefaultAsync().Result == null){
                database.InsertAsync(new Sessao { 
                    CodigoRegionalidade = App.DatabaseEstado.GetItem("Santa Catarina").Codigo, 
                    CodigoUsuario = -1 
                });
            }

            return database.Table<Sessao>().FirstOrDefaultAsync().Result;
        }

        public int SaveItem(Sessao item)
        {
            database.DeleteAsync(GetItem());
            return database.InsertAsync(item).Result;
        }
    }
}
