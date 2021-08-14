using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace Proyecto_Artistica.Models
{
    class ProductRepository
    {
        private SQLiteConnection con;
        private static ProductRepository instanciaProducto;
        public static ProductRepository InstanciaProducto
        {
            get
            {
                if (instanciaProducto == null)
                    throw new Exception("Debe llamar al inicializador, acciÃ³n detenida");
                return instanciaProducto;
            }
        }
        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instanciaProducto != null)
            {
                instanciaProducto.con.Close();
            }

            instanciaProducto = new ProductRepository(filename);
        }

        internal void POST(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9, string text10, string text11, Entry txtActualizarPrecio, Entry txtActualizarProveedor, Entry txtActualizarImage, int v)
        {
            throw new NotImplementedException();
        }

        internal void POST(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, int v)
        {
            throw new NotImplementedException();
        }

        private ProductRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            //con.DropTable<Venta>();
            //con.DropTable<Pago>();
            //con.DropTable<Garantia>();

            con.CreateTable<Usuario>();
            con.CreateTable<Venta>();
            con.CreateTable<Producto>();
            con.CreateTable<Garantia>();
            con.CreateTable<Pago>();
            con.CreateTable<Carrito>();
        }

        internal void PUT(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9, string text10, string text11, Entry txtActualizarPrecio, Entry txtActualizarProveedor, Entry txtActualizarImage, int v)
        {
            throw new NotImplementedException();
        }

        public string EstadoMensaje;

        public int AddNewUsuario(string username, string nombre, string apellidos, string email, string password, string type)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Usuario
                {
                    userName = username,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Email = email,
                    Password = password,
                    Type = type

                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        internal void PUT(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, int v)
        {
            throw new NotImplementedException();
        }

        public int UpdateUsuario(int id, string username, string nombre, string apellidos, string email, string password)
        {
            int result = 0;
            try
            {
                Usuario usuario = (new Usuario
                {
                    usuarioId = id,
                    userName = username,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Email = email,
                    Password = password
                });
                result = con.Update(usuario);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        internal object Get()
        {
            throw new NotImplementedException();
        }

        internal void DEL(int v)
        {
            throw new NotImplementedException();
        }

        public int DeleteUsuario(int id, string username, string nombre, string apellidos, string email, string password)
        {
            int result = 0;
            try
            {
                Usuario usuario = (new Usuario
                {
                    usuarioId = id,
                    userName = username,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Email = email,
                    Password = password
                });
                result = con.Delete(usuario);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            try
            {
                return con.Table<Usuario>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Usuario>();
        }

        public int GetUsuario(string username, string password)
        {

            try
            {

                var usuarios = con.Table<Usuario>();

                foreach (var aux in usuarios)
                {
                    if (aux.userName.Equals(username) && aux.Password.Equals(password))
                    {
                        return aux.usuarioId;
                    }
                }

            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }

            return 0;
        }

        public int AddNewProducto(string nombre, string categoria, string salon, int cantidad, decimal precio, string proveedor, string image)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Producto
                {
                    Categoria = categoria,
                    Nombre = nombre,
                    Salon = salon,
                    Cantidad = cantidad,
                    Precio = precio,
                    Proveedor = proveedor,
                    Image = image

                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public int UpdateProducto(Producto producto)
        {
            int result = 0;
            try
            {

                result = con.Update(producto);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public int DeleteProducto(int id, string nombre, string categoria, string salon, int cantidad, decimal precio, string proveedor, string image)
        {
            int result = 0;
            try
            {
                Producto producto = (new Producto
                {
                    productoId = id,
                    Categoria = categoria,
                    Nombre = nombre,
                    Salon = salon,
                    Cantidad = cantidad,
                    Precio = precio,
                    Proveedor = proveedor,
                    Image = image
                });
                result = con.Delete(producto);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Producto> GetAllProductos()
        {
            try
            {
                return con.Table<Producto>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Producto>();
        }

        public Producto GetProducto(int id)
        {
            try
            {
                var producto = con.Table<Producto>();
                foreach (var aux in producto)
                {
                    if (aux.productoId == id)
                    {
                        return aux;
                    }
                }
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return null;
        }




        public int AddNewVenta(int id, DateTime fecha, decimal total, decimal monto, int pagos, decimal interes)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Venta
                {
                    usuarioId = id,
                    Fecha = fecha,
                    Total = total,
                    Monto = monto,
                    Pagos = pagos,
                    Interes = interes


                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Venta> GetAllVentas()
        {
            try
            {
                return con.Table<Venta>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Venta>();
        }

        public IEnumerable<Venta> GetAllVentas(int id, DateTime fecha)
        {
            try
            {
                List<Venta> ventaLista = new List<Venta>();
                var venta = con.Table<Venta>();
                foreach (var aux in venta)
                {
                    if (aux.usuarioId == id && aux.Fecha.AddYears(1) >= fecha)
                    {
                        ventaLista.Add(aux);
                    }
                }
                return ventaLista;
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Venta>();
        }

        public IEnumerable<Venta> GetAllVentasH(int id)
        {
            try
            {
                List<Venta> ventaLista = new List<Venta>();
                var venta = con.Table<Venta>();
                foreach (var aux in venta)
                {
                    if (aux.usuarioId == id)
                    {
                        ventaLista.Add(aux);
                    }
                }
                return ventaLista;
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Venta>();
        }

        public int GetVenta(int id)
        {
            int ventaList = 0;
            try
            {
                var venta = con.Table<Venta>();

                foreach (var aux in venta)
                {
                    if (aux.usuarioId == id)
                        ventaList = aux.ventaId;
                }
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return ventaList;
        }

        public Venta GetVentaId(int id)
        {

            try
            {
                var venta = con.Table<Venta>();

                foreach (var aux in venta)
                {
                    if (aux.ventaId == id)
                        return aux;
                }
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return null;
        }




        public int AddNewGarantia(int ventaid, int productoId, int facturaId, string descripcion, string estado, DateTime fecha)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Garantia
                {
                    ventaId = ventaid,
                    facturaId = facturaId,
                    productoId = productoId,
                    Descripcion = descripcion,
                    Estado = estado,
                    Fecha = fecha
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public int UpdateGarantia(int id, string resolucion)
        {
            int result = 0;
            try
            {
                Garantia garantia = (new Garantia
                {
                    garantiaId = id,
                    Resolucion = resolucion
                });
                result = con.Update(garantia);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Garantia> GetAllGarantias()
        {
            try
            {
                return con.Table<Garantia>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Garantia>();
        }

        public IEnumerable<Garantia> GetAllGarantiaH(int id)
        {
            try
            {
                List<Garantia> garantias = new List<Garantia>();
                var garantia = con.Table<Garantia>();
                foreach (var aux in garantia)
                {
                    if (GetVentaId(aux.ventaId).usuarioId == id)
                    {
                        garantias.Add(aux);
                    }

                }
                return garantias;
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Garantia>();
        }

        public int AddNewPago(int ventaid, decimal monto, int numeropago, DateTime fecha)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Pago
                {
                    ventaId = ventaid,
                    Monto = monto,
                    numeroPago = numeropago,
                    Fecha = fecha,
                    Estado = "P"
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Pago> GetAllPagos()
        {
            try
            {
                return con.Table<Pago>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Pago>();
        }

        public IEnumerable<Pago> GetAllPagos(int userId)
        {
            try
            {
                var pagos = con.Table<Pago>();
                List<Pago> pagosList = new List<Pago>();
                foreach (var aux in pagos)
                {
                    if (GetVentaId(aux.ventaId).ventaId == userId && aux.Estado.Equals("P"))
                    {
                        pagosList.Add(aux);
                    }
                }

                return pagosList;
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Pago>();
        }

        public bool UpdatePago(int id)
        {
            try
            {
                var pagos = con.Table<Pago>();
                foreach (var aux in pagos)
                {
                    if (aux.pagoId == id)
                    {
                        aux.Estado = "F";
                        try
                        {
                            con.Update(aux);
                            return true;
                        }
                        catch (Exception e)
                        {
                            EstadoMensaje = e.Message;

                        }

                    }
                }


            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return false;
        }

        public IEnumerable<Pago> GetAllPagosH(int userId)
        {
            try
            {
                var pagos = con.Table<Pago>();
                List<Pago> pagosList = new List<Pago>();
                foreach (var aux in pagos)
                {
                    if (GetVentaId(aux.ventaId).usuarioId == userId)
                    {
                        pagosList.Add(aux);
                    }
                }

                return pagosList;
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Pago>();
        }

        public int AddNewCarrito(int idUsuario, int idProducto, string nombre, int cantidad, decimal precio)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Carrito
                {
                    productoId = idProducto,
                    Nombre = nombre,
                    usuarioID = idUsuario,
                    Cantidad = cantidad,
                    Precio = precio,
                    Estado = "P"
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public bool UpdateCarrito(int idUsuario, int idVenta)
        {
            bool result = false;
            int resultado = 0;
            try
            {
                var carrito = con.Table<Carrito>();
                foreach (var aux in carrito)
                {
                    if (aux.usuarioID == idUsuario && aux.Estado.Equals("P"))
                    {
                        resultado = 0;
                        aux.Estado = idVenta.ToString();
                        try
                        {
                            resultado = con.Update(aux);
                            result = true;
                        }
                        catch (Exception e)
                        { EstadoMensaje = e.Message; }
                    }
                }
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public int DeleteCarrito(Carrito carrito)
        {
            int result = 0;
            try
            {

                result = con.Delete(carrito);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Carrito> GetAllCarrito()
        {
            try
            {
                return con.Table<Carrito>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Carrito>();
        }

        public Carrito GetCarritoUserProd(int user, int prod)
        {
            try
            {
                var carrito = con.Table<Carrito>();
                foreach (var aux in carrito)
                {
                    if (aux.usuarioID == user && aux.productoId == prod)
                    {
                        return aux;
                    }
                }
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return null;
        }

        public int UpdateCarrito(Carrito carritoVar, decimal precio, int cantidad)
        {
            int result = 0;
            try
            {
                Carrito carrito = (new Carrito
                {
                    carritoId = carritoVar.carritoId,
                    Nombre = carritoVar.Nombre,
                    productoId = carritoVar.productoId,

                    usuarioID = carritoVar.usuarioID,
                    Precio = precio,
                    Cantidad = cantidad,
                    Estado = "P"
                });
                result = con.Update(carrito);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }

        public IEnumerable<Carrito> GetAllCarrito(int userId)
        {
            try
            {
                List<Carrito> carritoList = new List<Carrito>();
                var carrito = con.Table<Carrito>();
                foreach (var aux in carrito)
                {
                    if (aux.usuarioID == userId && aux.Estado.Equals("P"))
                    {
                        carritoList.Add(aux);
                    }
                }
                return carritoList;
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Carrito>();
        }

        public IEnumerable<Carrito> GetAllCarrito(int userId, int ventaId)
        {
            try
            {
                List<Carrito> carritoList = new List<Carrito>();
                var carrito = con.Table<Carrito>();
                foreach (var aux in carrito)
                {
                    if (!aux.Estado.Equals("P"))
                    {
                        if (Convert.ToInt32(aux.Estado) == ventaId)
                        {

                            carritoList.Add(aux);

                        }

                    }
                }
                return carritoList;
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Carrito>();
        }

        public static implicit operator UserRepository(ProductRepository v)
        {
            throw new NotImplementedException();
        }
    }
}