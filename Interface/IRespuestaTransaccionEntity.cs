namespace TransaccionES.Interface
{
    public interface IRespuestaTransaccionEntity
    {
        public string Codigo_Transaccion { get; set; }

        public string Fecha_Transaccion { get; set; }

        public string Hora_Transaccion { get; set; }

        public string Codigo_Empresa { get; set; }

        public string Nombre_Empresa { get; set; }

        public string Sucursal { get; set; }

        public string NIC { get; set; }

        //public double Valor_Total_Pagado { get; set; }
        public decimal Valor_Total_Pagado { get; set; }
    }
}
