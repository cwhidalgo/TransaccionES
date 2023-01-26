using System.ComponentModel.DataAnnotations;

namespace TransaccionES.DTO
{
    public class TransaccionDTO
    {
        [Key]
        public decimal? CODIGO_TRANSACCION { get; set; }
        public DateTime? FECHA_TRANSACCION { get; set; }
        public TimeSpan? HORA_TRANSACCION { get; set; }
        public string? CODIGO_EMPRESA { get; set; }
        public string? SUCURSAL { get; set; }
        public string? NIC { get; set; }
        public decimal? VALOR_TOTAL_PAGADO { get; set; }
        public bool? AGENDAMIENTO_WEB { get; set; }
    }
}
