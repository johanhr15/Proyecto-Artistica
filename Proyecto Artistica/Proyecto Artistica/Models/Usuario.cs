using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Artistica.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int usuarioId { get; set; }

        [MaxLength(50), NotNull]
        public string Nombre { get; set; }

        [MaxLength(100), NotNull]
        public string Apellidos { get; set; }

        [MaxLength(50), Unique, NotNull]
        public string userName { get; set; }

        [MaxLength(50), Unique, NotNull]
        public string Email { get; set; }

        [MaxLength(50), NotNull]
        public string Password { get; set; }

        [MaxLength(1), NotNull]
        public string Type { get; set; }

    }
}
