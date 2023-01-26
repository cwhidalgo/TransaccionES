using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TransaccionES.DTO;
using TransaccionES.Entidades;
using TransaccionES.Interface;

namespace TransaccionES.Controllers
{
    [ApiController]
    [Route("api/transacciones")]
    public class TransaccionESController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public IConfiguration Configuration { get; }
        IRespuestaTransaccionEntity respuestaTransaccion;

        public TransaccionESController(ApplicationDbContext context, IConfiguration configuration, IMapper mapper, IRespuestaTransaccionEntity respuestaTransaccion)
        {
            this.context = context;
            Configuration = configuration;
            this.mapper = mapper;
            this.respuestaTransaccion = respuestaTransaccion;
        }



        /*ConsultarTransaccion*/
        [HttpPost, Route("ConsultarTransaccion")]
        public async Task<ActionResult<List<ResponseTransaccionDTO>>> ConsultarTransaccion(RequestTransaccionDTO requestTransaccion)
        {
            try
            {
                ResponseTransaccionDTO respuesta = new ResponseTransaccionDTO();

                if (requestTransaccion == null)
                {
                    ResponseTransaccionDTO res = new ResponseTransaccionDTO();
                    res.Codigo_Respuesta = "001";
                    res.Mensaje_Respuesta = "Ingrese datos en el request";
                    return mapper.Map<List<ResponseTransaccionDTO>>(res);
                }

                var trxExiste = await context.TRANSACCION_RQ.FirstOrDefaultAsync(trxBD => trxBD.CODIGO_TRANSACCION == Convert.ToUInt32(requestTransaccion.Codigo_Transaccion.Trim()));

                if ((trxExiste.CODIGO_TRANSACCION != Convert.ToUInt32(requestTransaccion.Codigo_Transaccion.Trim())) || (trxExiste.NIC.Trim() != requestTransaccion.NIC.Trim()) || (trxExiste.CODIGO_EMPRESA.Trim() != requestTransaccion.Codigo_Empresa.Trim()))
                    return BadRequest($"Transaccion o datos ingresados no encontrados");

                if (trxExiste.SUCURSAL.Trim() != requestTransaccion.Sucursal.Trim())
                    return BadRequest($"No existe codigo sucursal {requestTransaccion.Sucursal} registrada");

                /*luego del request valida la sucursal*/

                /*si existe la transaccion armo el request de respuesta*/
                var TRANSACCION = (from t in context.TRANSACCION_RQ
                                   where t.CODIGO_TRANSACCION == trxExiste.CODIGO_TRANSACCION
                                   select new
                                   {
                                       CODIGO_TRANSACCION = t.CODIGO_TRANSACCION,
                                       FECHA_TRANSACCION = t.FECHA_TRANSACCION,
                                       HORA_TRANSACCION = t.HORA_TRANSACCION,
                                       CODIGO_EMPRESA = t.CODIGO_EMPRESA,
                                       SUCURSAL = t.SUCURSAL,
                                       NIC = t.NIC,
                                       VALOR_TOTAL_PAGADO = t.VALOR_TOTAL_PAGADO,
                                       AGENDAMIENTO_WEB = t.AGENDAMIENTO_WEB

                                   }).ToList();

                var NOMEMPRESA = (from a in context.AGENCIA
                                  where a.id_agencia == Convert.ToUInt32(requestTransaccion.Codigo_Empresa)
                                  select new
                                  {
                                      NOMBRE = a.nombre,

                                  }).ToList();


                /*SERVICIOS_REQ*/
                respuestaTransaccion.Codigo_Transaccion = TRANSACCION[0].CODIGO_TRANSACCION.ToString();
                respuestaTransaccion.Fecha_Transaccion = Convert.ToDateTime(TRANSACCION[0].FECHA_TRANSACCION).ToString("yyyymmdd");
                var hora = TRANSACCION[0].HORA_TRANSACCION.ToString();
                var formatHora = hora.Split(':');
                respuestaTransaccion.Hora_Transaccion = formatHora[0] + formatHora[1] + formatHora[2];
                respuestaTransaccion.Codigo_Empresa = TRANSACCION[0].CODIGO_EMPRESA.ToString();
                respuestaTransaccion.Nombre_Empresa = NOMEMPRESA[0].NOMBRE.ToString();
                respuestaTransaccion.Sucursal = TRANSACCION[0].SUCURSAL.ToString();
                respuestaTransaccion.NIC = TRANSACCION[0].NIC.ToString();
                var retornocantidad = (TRANSACCION[0].VALOR_TOTAL_PAGADO).ToString();
                respuestaTransaccion.Valor_Total_Pagado = Convert.ToDecimal(retornocantidad);

                respuesta.Mensaje_Respuesta = "transacción Exitosa";
                respuesta.Codigo_Respuesta = "000";
                respuesta.Transaccion = (RespuestaTransaccionEntity)respuestaTransaccion;

                var SERVICIO = (from s in context.SERVICIOS_REQ
                                join t in context.TRANSACCION_RQ
                                on s.ID_TRANSACCION equals t.CODIGO_TRANSACCION
                                where s.ID_TRANSACCION == trxExiste.CODIGO_TRANSACCION
                                select new
                                {
                                    ID_TURNO = s.ID_TURNO,
                                    ID_TRANSACCION = s.ID_TRANSACCION,
                                    COD_SERVICIO = s.COD_SERVICIO,
                                    NOMBRE_SERVICIO = s.NOMBRE_SERVICIO,
                                    TIPO_SERVICIO = s.TIPO_SERVICIO,
                                    VALOR_SERVICIO = s.VALOR_SERVICIO,
                                    CODIGO_TRANSACCION = t.CODIGO_TRANSACCION,
                                    FECHA_TRANSACCION = t.FECHA_TRANSACCION,
                                    HORA_TRANSACCION = t.HORA_TRANSACCION,
                                    CODIGO_EMPRESA = t.CODIGO_EMPRESA,
                                    SUCURSAL = t.SUCURSAL,
                                    NIC = t.NIC,
                                    VALOR_TOTAL_PAGADO = t.VALOR_TOTAL_PAGADO,
                                    AGENDAMIENTO_WEB = t.AGENDAMIENTO_WEB

                                }).ToList();


                foreach (var rq in SERVICIO)
                {
                    RespuestaServiciosEntity respuestaServicios = new RespuestaServiciosEntity();

                    /*SERVICIOS_REQ*/
                    respuestaServicios.Codigo_Servicio = rq.COD_SERVICIO.ToString(); //Codigo_Servicio //Código del servicio que se pagó
                    respuestaServicios.Nombre_Servicio = rq.NOMBRE_SERVICIO.ToString(); //Nombre_Servicio//Ej: Renovación Cédula
                    respuestaServicios.Tipo_Servicio = rq.TIPO_SERVICIO.ToString(); //Tipo_Servicio//0: Normal, 1: Vulnerable
                    respuestaServicios.Valor_Servicio_Pagado = Convert.ToDouble(rq.VALOR_SERVICIO); //Valor_Servicio_Pagado//Valor pagado por el servicio. Separador de decimal coma

                    respuesta.listaServicios.Add(respuestaServicios);
                }


                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest("Codigo Transaccion " + requestTransaccion.Codigo_Transaccion + " incorrecto");
            }

        }
        /*COMENTARIO*/
    }
}
