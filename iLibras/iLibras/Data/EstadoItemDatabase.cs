using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iLibras.Models;
using SQLite;

namespace iLibras.Data
{
    public class EstadoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public EstadoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Estado>().Wait();
        }

        public Task<List<Estado>> GetItemsAsync()
        {
            var lista = database.Table<Estado>().ToListAsync().Result;

            if(lista == null || lista.Count <= 0){
                SaveItemAsync(new Estado() { Abreviacao = "AC", Extenso = "Acre" });
                SaveItemAsync(new Estado() { Abreviacao = "AL", Extenso = "Alagoas" });
                SaveItemAsync(new Estado() { Abreviacao = "AP", Extenso = "Amapá" });
                SaveItemAsync(new Estado() { Abreviacao = "AM", Extenso = "Amazonas" });
                SaveItemAsync(new Estado() { Abreviacao = "BA", Extenso = "Bahia" });
                SaveItemAsync(new Estado() { Abreviacao = "CE", Extenso = "Ceará" });
                SaveItemAsync(new Estado() { Abreviacao = "DF", Extenso = "Distrito Federal" });
                SaveItemAsync(new Estado() { Abreviacao = "ES", Extenso = "Espírito Santo" });
                SaveItemAsync(new Estado() { Abreviacao = "GO", Extenso = "Goiás" });
                SaveItemAsync(new Estado() { Abreviacao = "MA", Extenso = "Maranhão" });
                SaveItemAsync(new Estado() { Abreviacao = "MT", Extenso = "Mato Grosso" });
                SaveItemAsync(new Estado() { Abreviacao = "MS", Extenso = "Mato Grosso do Sul" });
                SaveItemAsync(new Estado() { Abreviacao = "MG", Extenso = "Minas Gerais" });
                SaveItemAsync(new Estado() { Abreviacao = "PA", Extenso = "Pará" });
                SaveItemAsync(new Estado() { Abreviacao = "PB", Extenso = "Paraíba" });
                SaveItemAsync(new Estado() { Abreviacao = "PR", Extenso = "Paraná" });
                SaveItemAsync(new Estado() { Abreviacao = "PE", Extenso = "Pernambuco" });
                SaveItemAsync(new Estado() { Abreviacao = "PI", Extenso = "Piauí" });
                SaveItemAsync(new Estado() { Abreviacao = "RJ", Extenso = "Rio de Janeiro" });
                SaveItemAsync(new Estado() { Abreviacao = "RN", Extenso = "Rio Grande do Norte" });
                SaveItemAsync(new Estado() { Abreviacao = "RS", Extenso = "Rio Grande do Sul" });
                SaveItemAsync(new Estado() { Abreviacao = "RO", Extenso = "Rondônia" });
                SaveItemAsync(new Estado() { Abreviacao = "RR", Extenso = "Roraima" });
                SaveItemAsync(new Estado() { Abreviacao = "SC", Extenso = "Santa Catarina" });
                SaveItemAsync(new Estado() { Abreviacao = "SP", Extenso = "São Paulo" });
                SaveItemAsync(new Estado() { Abreviacao = "SE", Extenso = "Sergipe" });
                SaveItemAsync(new Estado() { Abreviacao = "TO", Extenso = "Tocantins" });
            }

            return database.Table<Estado>().ToListAsync();
        }

        public Task<Estado> GetItemAsync(int codigo)
        {
            return database.Table<Estado>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync();
        }

        private Task<int> SaveItemAsync(Estado item)
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
    }
}
