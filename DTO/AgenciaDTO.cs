using System.ComponentModel.DataAnnotations;

namespace TransaccionES.DTO
{
    public class AgenciaDTO
    {
        [Key]
        public decimal? id_agencia { get; set; }
        public string? ruc { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public string? direccion { get; set; }
    }
}
