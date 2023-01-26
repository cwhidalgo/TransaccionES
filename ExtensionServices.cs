using TransaccionES.Entidades;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensionServices
    {
        public static void AddTransaccionServices(this ServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<RespuestaTransaccionEntity>();

        }
    }
}
