using ConsultaIbge.Municipios;

namespace ConsultaIbge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient<IMunicipios, MunicipiosApi>((x) =>
            {
                x.BaseAddress = new Uri("https://servicodados.ibge.gov.br/api/v1/localidades/estados/MG/municipios");
            });

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}