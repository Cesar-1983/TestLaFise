using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EML
{
    public class ImagenProducto
    {
        public int ImagenProductoId { get; set; }
        public int ProductoId { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public string file_base64 { get; set; }
        public string description { get; set; }
        public bool IsPrincipal { get; set; }

    }
}
