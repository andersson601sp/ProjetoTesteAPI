using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoTeste.Domain.Handlers;
using ProjetoTeste.Domain.Repositories;
using ProjetoTeste.Domain.Services;
using ProjetoTeste.Infrastructure.Repositories;
using ProjetoTeste.Infrastructure.Services;

namespace ProjetoTeste.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ProdutoHandler>();
            services.AddScoped<CategoriaHandler>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
