using System;
using SQLite;

namespace iLibras.Models
{
    /// <summary>
    /// 1 - Admin
    /// 2 - Coordenador
    /// 3 - Cooperador
    /// 4 - Comunicador
    /// </summary>
    public class Perfil
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public String Descricao { get; set; }
    }
}
