using System.ComponentModel.DataAnnotations;

namespace TransaccionES.DTO
{
    public class ResTurnoServicioDTO
    {
        [Key]
        public string codigo { get; set; }
        public int id_turnoservicio { get; set; }
        public int id_turno { get; set; }
    }
}
