using System.ComponentModel.DataAnnotations;

namespace TransaccionES.Entidades
{
    public class ServicioEntity
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Codigo_Servicio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre_Servicio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Tipo_Servicio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double Valor_Servicio_Pagado { get; set; }

        public ServicioEntity(string codigo_Servicio, string nombre_Servicio,
            string tipo_Servicio, double valor_Servicio_Pagado)
        {
            this.Codigo_Servicio = codigo_Servicio;
            this.Nombre_Servicio = nombre_Servicio;
            this.Tipo_Servicio = tipo_Servicio;
            this.Valor_Servicio_Pagado = valor_Servicio_Pagado;
        }

        public ServicioEntity() { }
    }
}
