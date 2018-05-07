using System;
using SQLite;
namespace iLibras.Models
{
    public class ImagemRepresentativa
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public int CodigoSinal { get; set; }
        public string Imagem { get; set; }
    }
}
