using System.ComponentModel.DataAnnotations;

namespace TransaccionES.DTO
{
    public class ServiciosDTO
    {
        [Key]
        public decimal? ID_TURNO { get; set; }
        public decimal? ID_TRANSACCION { get; set; }
        public decimal? COD_SERVICIO { get; set; }
        public string? NOMBRE_SERVICIO { get; set; }
        public bool TIPO_SERVICIO { get; set; }
        public decimal VALOR_SERVICIO { get; set; }

    }
}
