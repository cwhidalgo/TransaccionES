using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransaccionES.DTO;

namespace TransaccionES
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ResTurnoDTO> Turno { get; set; }
        public DbSet<AgenciaDTO> AGENCIA { get; set; }
        public DbSet<ServiciosDTO> SERVICIOS_REQ { get; set; }
        public DbSet<TransaccionDTO> TRANSACCION_RQ { get; set; }


    }
}
