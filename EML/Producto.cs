using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EML
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public int MedidaId { get; set; }
        public string Nombre { get; set; }
        public string DescripcionLarga { get; set; }
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public decimal Existencia { get; set; }

    }
}
