using System.Text;
using Application.DTO;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Application.Validation;
using DataAccess;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using Repository.Repositories;
using Repository.UnitOfWork;

namespace API
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
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<WalletValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<CartValidator>();
                });
            services.AddTransient<IValidator<WalletDTO>, WalletValidator>();
            services.AddTransient<IValidator<CartDTO>, CartValidator>();
            services.AddDbContext<RestaurantContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IMailer, Mailer>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  
                .AddJwtBearer(options =>  
                {  
                    options.TokenValidationParameters = new TokenValidationParameters  
                    {  
                        ValidateIssuer = true,  
                        ValidateAudience = true,  
                        ValidateLifetime = true,  
                        ValidateIssuerSigningKey = true,  
                        ValidIssuer = Configuration["Jwt:Issuer"],  
                        ValidAudience = Configuration["Jwt:Issuer"],  
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))  
                    };  
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}