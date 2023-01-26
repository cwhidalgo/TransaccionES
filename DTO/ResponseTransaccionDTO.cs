using TransaccionES.Entidades;

namespace TransaccionES.DTO
{
    public class ResponseTransaccionDTO
    {
        public string? Codigo_Respuesta { get; set; }
        public string? Mensaje_Respuesta { get; set; }
        public RespuestaTransaccionEntity Transaccion { get; set; }
        public List<RespuestaServiciosEntity> listaServicios { get; set; }


        public ResponseTransaccionDTO() { listaServicios = new List<RespuestaServiciosEntity>(); }
    }
}
