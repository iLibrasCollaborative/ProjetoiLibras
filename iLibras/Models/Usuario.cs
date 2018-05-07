using System;
using SQLite;

namespace iLibras.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Perfil { get; set; }
        public int Estado { get; set; }
        public string Imagem { get; set; } 
    }
}
