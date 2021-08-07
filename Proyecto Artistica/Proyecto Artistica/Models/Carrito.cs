using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Artistica.Models
{
    [Table("carrito")]
    public class Carrito
    {
        [PrimaryKey, AutoIncrement]
        public int carritoId { get; set; }

        [NotNull]
        public int productoId { get; set; }

        [NotNull]
        public int usuarioID { get; set; }

        [MaxLength(100), NotNull]
        public string Nombre { get; set; }

        [NotNull]
        public int Cantidad { get; set; }

        [NotNull]
        public decimal Precio { get; set; }

        [MaxLength(1), NotNull]
        public string Estado { get; set; }

    }
}
