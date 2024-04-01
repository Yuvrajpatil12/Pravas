using Core.Utility.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;
using System.Text;
using Yatra.Models;

namespace Adhilabhansah
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

            services.AddMvc(options => options.EnableEndpointRouting = false);

            // Save the session in database
            //services.AddDistributedSqlServerCache(options =>
            //{
            //    options.ConnectionString =
            //         Configuration.GetConnectionString("DefaultConnection");
            //    options.SchemaName = "dbo";
            //    options.TableName = "ServerSession";
            //});

            services.AddSession();

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromHours(12); // which will expire the cache after 12 hours the cache set.
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSingleton<IConfiguration>(Configuration);
            //   services.AddScoped<IQRCodeGenerator, QRCodeGeneratorHelper>();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

           // Adding Jwt Bearer
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ClockSkew = TimeSpan.Zero,

                   ValidAudience = ConstantsCommon.JWT_audience,
                   ValidIssuer = ConstantsCommon.JWT_issuer,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConstantsCommon.JWT_secret))
               };
           });
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
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvc();
            app.UseSession();

            //app.UseWebSockets();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "landing",
                   template: "s/{id}",
                   defaults: new { controller = "Users", action = "Index" }
               );
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";

                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Swagger Configuration V1");
                    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "text/plain"
            });

            // Enable WebSockets

            // Define the WebSocket endpoint path
            //string webSocketPath = "/ws/location";
            //string webSocketPathGetUserLocation = "/ws/getdriverlocation";

            // Configure the WebSocket middleware
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path == webSocketPath && context.Request.Method == "GET")
            //    {
            //        if (context.WebSockets.IsWebSocketRequest)
            //        {
            //            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            //            var connectionString = "DefaultConnection"; // Replace with your actual connection string
            //            var handler = new WebSocketHandler(connectionString);
            //            await handler.ProcessAsync(webSocket);
            //        }
            //        else
            //        {
            //            // Handle non-WebSocket requests for this path
            //            context.Response.StatusCode = 400;
            //        }
            //    }
            //    else
            //    {
            //        await next();
            //    }
            //});

            app.UseDefaultFiles();
        }
    }
}