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
        // Perfil
        // 1 - Comunicador
        // 2 - Cooperador
        // 3 - Coordenador
        public String Perfil { get; set; }
        public String Estado { get; set; }
    }
}
