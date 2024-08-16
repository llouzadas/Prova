using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; // Adicione esta linha
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; // Adicione esta linha

namespace FreightSystem
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddControllers();
            // Outros serviços podem ser adicionados aqui...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Aqui você usa IWebHostEnvironment
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
   }
}