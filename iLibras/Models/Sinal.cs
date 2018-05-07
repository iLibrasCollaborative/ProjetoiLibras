using System;
using SQLite;

namespace iLibras.Models
{
    public class Sinal
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public int CodigoEstado { get; set; }
        public int CodigoUsuario { get; set; }
        public string Gif { get; set; }
    }
}
