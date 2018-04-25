using System;
using SQLite;

namespace iLibras.Models
{
    public class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public String Descricao { get; set; }
        public int CodigoCategoria { get; set; }
        public String DescricaoCategoria { get; set; }
    }
}
