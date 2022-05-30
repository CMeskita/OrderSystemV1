using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderSystemV1.Application.Clientss.Handlers;
using OrderSystemV1.Application.Clientss.Requests;
using OrderSystemV1.Application.Clientss.Responses;
using OrderSystemV1.Application.Productss.Handlers;
using OrderSystemV1.Application.Productss.Requests;
using OrderSystemV1.Application.Productss.Responses;
using OrderSystemV1.Domain.Interfaces;
using OrderSystemV1.Infra.Repository;
using OrderSystemV1.Infra.SqlDbContext;
using OrderSystemV1.Infra.UnitOfWork;

namespace OrderSystemV1.OrderSystem
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
            services.AddControllersWithViews();
            services.AddMediatR(typeof(ClientHandler));
            services.AddMediatR(typeof(ProductHandler));
            services.AddDbContext<SqlContext>(opt => opt.UseSqlServer("name=ConnectionStrings:Sql"));

            services.AddTransient<IRequestHandler<ClientRequest, ClientResponse>, ClientHandler>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddTransient<IRequestHandler<ProductRequest, ProductResponse>, ProductHandler>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IUnityOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
