using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WeatherProject.Data;
using WeatherProject.Data.Entities;
using WeatherProject.Helpers;

namespace WeatherProject
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
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider; //video 33 token necessario para login
                cfg.SignIn.RequireConfirmedEmail = true; //temos de ativar conta no email
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false; // obrigatoriedade para as passwords terem varios caracters, numeros etc... COLOCAR A TRUE
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 6;
            })
                .AddDefaultTokenProviders() 
                 .AddEntityFrameworkStores<DataContext>(); 

            //Token
            services.AddAuthentication()//video 33 serviços para o token 
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = this.Configuration["Tokens:Issuer"],
                        ValidAudience = this.Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(this.Configuration["Tokens:Key"]))
                    };
                });

            services.AddDbContext<DataContext>(cfg => // cria um serviço do DataContext, injeto o meu
            {
                cfg.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));   // usar o sqlsever com esta connection string
            });

            services.AddTransient<SeedDb>(); // quando alguem chamar pelo SeedDb cria-o na factory do Program.cs
                                             //AddTransient -> Usa e deita fora (deixa de ficar em memória) e não pode ser mais usado 
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IMailHelper, MailHelper>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Error/NotAuthorized"; // em vez de reedirecionar para o login envia para a action Not Authorize (anula o retorno que definimos no login)
                options.AccessDeniedPath = "/Error/NotAuthorized"; // quando houver um acesso negado (Authorize) corre esta
            });

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Errors/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Middleware (Sistema operativo que mantêm a aplicação)
                                     // Atenção á sequência 

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
