using ACTIS_WebSocket_Gantner.Data;
using Microsoft.EntityFrameworkCore;
using ACTIS_WebSocket_Gantner.Models;

namespace ACTIS_WebSocket_Gantner
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string connString = Configuration.GetConnectionString("ACTIS_Database");
            services.AddDbContext<Actis3011aprilContext>(options => options.UseSqlServer(connString));
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseRouting();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();
            app.UseEndpoints(endpoints => { 
                endpoints.MapControllers();
            });
        }
    }
}
