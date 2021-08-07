using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Artistica.Models
{
    [Table("producto")]
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int productoId { get; set; }

        [MaxLength(100), NotNull]
        public string Nombre { get; set; }

        [MaxLength(50), NotNull]
        public string Categoria { get; set; }

        [MaxLength(50), NotNull]
        public string Salon { get; set; }

        [NotNull]
        public int Cantidad { get; set; }

        [NotNull]
        public decimal Precio { get; set; }

        [MaxLength(50), NotNull]
        public string Proveedor { get; set; }

        [MaxLength(500), NotNull]
        public string Image { get; set; }
    }
}
