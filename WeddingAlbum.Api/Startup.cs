using System.Text;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using WeddingAlbum.Api.Infrastructure;
using WeddingAlbum.Common.Configuration;

namespace WeddingAlbum.Api
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
            services.AddCors();
            services.AddHttpContextAccessor();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cupid API", Version = "v1" });
            });
            services.AddControllers();

            ConfigureAuth(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var serilog = new LoggerConfiguration()
                  .MinimumLevel.Verbose()
                  .Enrich.FromLogContext()
                  .WriteTo.File(@"api_log.txt");

            loggerFactory.WithFilter(new FilterLoggerSettings
            {
                {"Microsoft", LogLevel.Warning},
                {"System", LogLevel.Warning}
            }).AddSerilog(serilog.CreateLogger());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseApiSecurityHttpHeaders();
            //app.UseBlockingContentSecurityPolicyHttpHeader();
            app.RemoveServerHeader();
            app.UseNoCacheHttpHeaders();
            app.UseStrictTransportSecurityHttpHeader(env);
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(b => b.WithOrigins("https://localhost:5002").AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cupid v1");
            });
        }

        public virtual void ConfigureAuth(IServiceCollection services)
        {
            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("secretJwtKey123_toCupidAPI_WeddingAlbum_qwerty555"))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("user", policy => policy.RequireRole("user"));
            });

            services.AddMvcCore();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DefaultModule(Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
        }
    }
}
