using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace Proyecto_Artistica.Models
{
    [Table("pago")]
    class Pago
    {
        [PrimaryKey, AutoIncrement]
        public int pagoId { get; set; }

        [NotNull]
        public int ventaId { get; set; }

        [NotNull]
        public DateTime Fecha { get; set; }

        [NotNull]
        public decimal Monto { get; set; }

        [NotNull]
        public int numeroPago { get; set; }

        [MaxLength(50), NotNull]
        public string Estado { get; set; }




    }
}
