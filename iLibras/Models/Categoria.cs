using System;
using SQLite;

namespace iLibras.Models
{
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
