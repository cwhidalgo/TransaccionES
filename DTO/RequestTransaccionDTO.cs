using System.ComponentModel.DataAnnotations;

namespace TransaccionES.DTO
{
    public class RequestTransaccionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(15)]
        public string Codigo_Transaccion { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NIC { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Codigo_Empresa { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Sucursal { get; set; }
    }
}
