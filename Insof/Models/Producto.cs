using System.ComponentModel.DataAnnotations;

namespace Insof.Models
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public float ValorUnitario { get; set; }
    }
}
