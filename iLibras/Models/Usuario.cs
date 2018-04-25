using System;
using SQLite;

namespace iLibras.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Perfil { get; set; }
        public int Estado { get; set; }
    }
}
