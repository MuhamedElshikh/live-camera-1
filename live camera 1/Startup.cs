using live_camera_1.Models.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace live_camera_1
{

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<UserRegistration, IdentityRole>()
                .AddEntityFrameworkStores<LivecamContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Configure identity options here, e.g., password requirements.
            });

            services.AddDbContext<LivecamContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Myconnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddIdentity<UserRegistration, IdentityRole>()
    .AddEntityFrameworkStores<LivecamContext>()
    .AddDefaultTokenProviders();
        }
    }
}

    
        

       


