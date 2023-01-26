using TransaccionES.Interface;

namespace TransaccionES.Entidades
{
    public class RespuestaTransaccionEntity : IRespuestaTransaccionEntity
    {
        private readonly IServiceProvider serviceProvider;

        public string Codigo_Transaccion { get; set; }

        public string Fecha_Transaccion { get; set; }

        public string Hora_Transaccion { get; set; }

        public string Codigo_Empresa { get; set; }

        public string Nombre_Empresa { get; set; }

        public string Sucursal { get; set; }

        public string NIC { get; set; }

        //public double Valor_Total_Pagado { get; set; }

        private decimal _valor_total_pagado { get; set; }
        public decimal Valor_Total_Pagado
        {
            get { return _valor_total_pagado; }
            set
            {
                _valor_total_pagado = Decimal.Parse(value.ToString());
            }
        }


        //public RespuestaTransaccionEntity(string codigo_Transaccion,
        //                         string fecha_Transaccion,
        //                         string hora_Transaccion,
        //                         string codigo_Empresa,
        //                         string sucursal,
        //                         string nIC,
        //                         double valor_Total_Pagado)
        //{
        //    this.Codigo_Transaccion = codigo_Transaccion;
        //    this.Fecha_Transaccion = fecha_Transaccion;
        //    this.Hora_Transaccion = hora_Transaccion;
        //    this.Codigo_Empresa = codigo_Empresa;
        //    this.Sucursal = sucursal;
        //    this.NIC = nIC;
        //    this.Valor_Total_Pagado = valor_Total_Pagado;
        //}
        public RespuestaTransaccionEntity(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}
