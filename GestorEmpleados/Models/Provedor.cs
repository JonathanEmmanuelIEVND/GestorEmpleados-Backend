using System.ComponentModel.DataAnnotations;

namespace MiWebAPI.Models
{
    public class Provedor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
        public string Empresa { get; set; }
    }
}
