using System;
using System.Collections.Generic;
using SQLite;

namespace iLibras.Models
{
    public class Estado
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public string Abreviacao { get; set; }
        public string Extenso { get; set; }
    }
}
