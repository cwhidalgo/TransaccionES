using System.ComponentModel.DataAnnotations;

namespace TransaccionES.DTO
{
    public class ResTurnoDiarioDTO
    {
        [Key]
        public decimal id_turno { get; set; }
        public decimal? turno { get; set; }
        public DateTime? fecha { get; set; }
        public DateTime? inicio_atencion { get; set; }
        public DateTime? fin_atencion { get; set; }
        public DateTime? fecha_caducidad { get; set; }
        public decimal? prioridad { get; set; }
        public string? estado { get; set; }
        public decimal? id_agencia { get; set; }
        public DateTime? fecha_llamado { get; set; }
        public decimal? total_media { get; set; }
    }
}
