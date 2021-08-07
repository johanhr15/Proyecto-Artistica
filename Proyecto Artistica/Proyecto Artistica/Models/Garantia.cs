using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Artistica.Models
{
    [Table("garantia")]
    class Garantia
    {
        [PrimaryKey, AutoIncrement]
        public int garantiaId { get; set; }

        [NotNull]
        public int ventaId { get; set; }

        [NotNull]
        public int productoId { get; set; }

        [NotNull]
        public int facturaId { get; set; }

        [MaxLength(500), NotNull]
        public string Descripcion { get; set; }

        [MaxLength(1), NotNull]
        public string Estado { get; set; }

        [NotNull]
        public DateTime Fecha { get; set; }

        [MaxLength(50)]
        public string Resolucion { get; set; }

       
    }
}
