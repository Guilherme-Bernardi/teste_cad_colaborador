using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDePessoa.Data;
using CadastroDePessoa.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace CadastroDePessoa
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<CadastroDePessoaContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("CadastroDePessoaContext"), builder =>
                        builder.MigrationsAssembly("CadastroDePessoa")));

            services.AddScoped<SeedingService>();
            services.AddScoped<ColaboradorService>();
            services.AddScoped<DepartamentoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var enBR = new CultureInfo("en-BR");
            var localizarionOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enBR),
                SupportedCultures = new List<CultureInfo> { enBR },
                SupportedUICultures = new List<CultureInfo> { enBR }
            };

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
