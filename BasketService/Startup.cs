using BasketService.Domain.Basket;
using BasketService.Domain.Order;
using BasketService.Infrastructure.Db.Basket;
using BasketService.Infrastructure.Db.Basket.Config;
using BasketService.Infrastructure.Db.Basket.Model;
using BasketService.Infrastructure.Db.Order;
using BasketService.Infrastructure.Db.Order.Config;
using BasketService.Infrastructure.Db.Order.Model;
using BasketService.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BasketService
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
            services.Configure<BasketDatabaseProperties>(Configuration.GetSection("BasketDatabase"));
            services.Configure<OrderDatabaseProperties>(Configuration.GetSection("OrderDatabase"));
            services.AddSingleton<OrderModelMapper>();
            services.AddSingleton<BasketModelMapper>();
            services.AddSingleton<IBasketProvider, DatabaseBasketProvider>();
            services.AddSingleton<IOrderProvider, DatabaseOrderProvider>();
            services.AddSingleton<Domain.Basket.BasketService>();
            services.AddSingleton<OrderService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BasketService", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasketService v1"));
            }

            app.ConfigureCustomExceptionMiddleware();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
