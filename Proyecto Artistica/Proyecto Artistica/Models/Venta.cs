using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Artistica.Models
{
    [Table("venta")]
    class Venta
    {
        [PrimaryKey, AutoIncrement]
        public int ventaId { get; set; }

        [NotNull]
        public int usuarioId { get; set; }

        [NotNull]
        public DateTime Fecha { get; set; }

        [NotNull]
        public decimal Total { get; set; }

        [NotNull]
        public decimal Monto { get; set; }

        [NotNull]
        public int Pagos { get; set; }

        [NotNull]
        public decimal Interes { get; set; }

    }
}
