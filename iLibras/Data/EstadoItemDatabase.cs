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

        public List<Estado> GetItems()
        {
            var lista = database.Table<Estado>().ToListAsync().Result;

            if(lista == null || lista.Count <= 0){
                SaveItem(new Estado() { Abreviacao = "AC", Extenso = "Acre" });
                SaveItem(new Estado() { Abreviacao = "AL", Extenso = "Alagoas" });
                SaveItem(new Estado() { Abreviacao = "AP", Extenso = "Amapá" });
                SaveItem(new Estado() { Abreviacao = "AM", Extenso = "Amazonas" });
                SaveItem(new Estado() { Abreviacao = "BA", Extenso = "Bahia" });
                SaveItem(new Estado() { Abreviacao = "CE", Extenso = "Ceará" });
                SaveItem(new Estado() { Abreviacao = "DF", Extenso = "Distrito Federal" });
                SaveItem(new Estado() { Abreviacao = "ES", Extenso = "Espírito Santo" });
                SaveItem(new Estado() { Abreviacao = "GO", Extenso = "Goiás" });
                SaveItem(new Estado() { Abreviacao = "MA", Extenso = "Maranhão" });
                SaveItem(new Estado() { Abreviacao = "MT", Extenso = "Mato Grosso" });
                SaveItem(new Estado() { Abreviacao = "MS", Extenso = "Mato Grosso do Sul" });
                SaveItem(new Estado() { Abreviacao = "MG", Extenso = "Minas Gerais" });
                SaveItem(new Estado() { Abreviacao = "PA", Extenso = "Pará" });
                SaveItem(new Estado() { Abreviacao = "PB", Extenso = "Paraíba" });
                SaveItem(new Estado() { Abreviacao = "PR", Extenso = "Paraná" });
                SaveItem(new Estado() { Abreviacao = "PE", Extenso = "Pernambuco" });
                SaveItem(new Estado() { Abreviacao = "PI", Extenso = "Piauí" });
                SaveItem(new Estado() { Abreviacao = "RJ", Extenso = "Rio de Janeiro" });
                SaveItem(new Estado() { Abreviacao = "RN", Extenso = "Rio Grande do Norte" });
                SaveItem(new Estado() { Abreviacao = "RS", Extenso = "Rio Grande do Sul" });
                SaveItem(new Estado() { Abreviacao = "RO", Extenso = "Rondônia" });
                SaveItem(new Estado() { Abreviacao = "RR", Extenso = "Roraima" });
                SaveItem(new Estado() { Abreviacao = "SC", Extenso = "Santa Catarina" });
                SaveItem(new Estado() { Abreviacao = "SP", Extenso = "São Paulo" });
                SaveItem(new Estado() { Abreviacao = "SE", Extenso = "Sergipe" });
                SaveItem(new Estado() { Abreviacao = "TO", Extenso = "Tocantins" });
            }

            return database.Table<Estado>().ToListAsync().Result;
        }

        public List<string> GetItemsString()
        {
            var estados = GetItems();
            var lista = new List<string>();

            foreach (Estado estado in estados)
                lista.Add(estado.Extenso);

            return lista;
        }

        public Estado GetItem(int codigo)
        {
            return database.Table<Estado>().Where(i => i.Codigo == codigo).FirstOrDefaultAsync().Result;
        }

        /// <summary>
        /// Retorna um objeto buscando pelo estado por extenso
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="estado">Estado.</param>
        public Estado GetItem(string estado){
            return database.Table<Estado>().Where(i => i.Extenso == estado).FirstOrDefaultAsync().Result;
        }

        public Estado GetItemForAbreviacao(string abreviacao){
            return database.Table<Estado>().Where(i => i.Abreviacao == abreviacao).FirstOrDefaultAsync().Result;
        }

        private int SaveItem(Estado item)
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
    }
}
