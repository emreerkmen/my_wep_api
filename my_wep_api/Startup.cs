using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using my_wep_api.CustomMiddlewares;
using my_wep_api.DataAccess;
using my_wep_api.Formatter;
using Newtonsoft.Json;

namespace my_wep_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //DependencyInjection burada
        public void ConfigureServices(IServiceCollection services)
        {

            

            services.AddScoped<IProductDal, EfProductDal>();//Eðer Iproductdal'a ihtiyaç olursa EfProductDal'ý new le ve bunu ver
            services.AddScoped<ITitleDal, EfTitlesManager>();
            services.AddScoped<ICompanyDal, EfCompaniesDal>();
            services.AddScoped<IDescriptionDal, EfDescriptionsDal>();

            //services.AddTransient<IProductDal, EfProductDal>();
            //services.AddSingleton<IProductDal, EfProductDal>();
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            //Ms video'sunda connection stringi dependency injection ile buraya ekliyor. Hard code yazmayýn diye de ekleme yapýyor.
            //services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True"));
            //services.AddDbContext<ResumeContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ResumesDB"]));

            services.AddMvc(options => options.OutputFormatters.Add(new VCardOutputFormatter()));

            services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);

            services.AddAuthentication(p => p.DefaultChallengeScheme = Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Middleware burada
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
