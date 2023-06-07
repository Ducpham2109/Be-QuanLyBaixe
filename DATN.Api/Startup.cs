using DATN.Application;
using DATN.Application.AuthHandler.Commands.TokenCommand;
using DATN.Application.Models;
using DATN.Infastructure;
using DATN.Infastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static DATN.Infastructure.Repositories.EmailReponsitory.EmailService;

namespace DATN.Api
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
            services.AddAutoMapper(typeof(Startup));
            services.AddCors();

            services.AddControllers();

            services.AddSignalR();
            services.RegisterRepositories();
            services.RegisterRequestHandlers();

            //services.AddScoped<IRequestHandler<CreateAccountCommand, BResult>, CreateAccountCommandHandler>();
            //services.AddScoped<CreateAccountCommandHandler>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddCors();
            //services.AddMediatR(typeof(CreateAccountCommandHandler));
            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseNpgsql(
              Configuration.GetConnectionString("MyDb"),
              b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddHttpContextAccessor()
                   .AddAuthorization()
                   .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.SaveToken = true;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = Configuration["Jwt:Issuer"],
                           ValidAudience = Configuration["Jwt:Audience"],
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                       };
                   });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DATN.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DATN.Api v1"));
            
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
