using System;
using SQLite;

namespace iLibras.Models
{
    public class Contexto
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string ContextoTexto { get; set; }
        public int CodigoTag { get; set; }
        public int CodigoSinal { get; set; }
    }
}
