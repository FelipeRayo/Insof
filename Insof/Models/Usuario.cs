using System.ComponentModel.DataAnnotations;

namespace Insof.Models
{
    public class Usuario
    {
        public string TipoDocumento { get; set; }

        [Key]
        public int NumeroDocumento { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public int Celular { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }
    }

}
