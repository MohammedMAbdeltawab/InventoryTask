
using InventoryTask.Authentication.Interfaces;
using InventoryTask.Authentication.Repositories;
using InventoryTask.Data;
using InventoryTask.Entities;
using InventoryTask.MappingConfig;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Repository.Reposatories;
using InventoryTask.Service.Interfaces;
using InventoryTask.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InventoryTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });
            builder.Services.AddDefaultIdentity<AppUser>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;

                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddAuthentication(

                            Options =>
                            {
                                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                Options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                            }).AddJwtBearer(options =>
                            {
                                options.SaveToken = true;
                                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    RequireExpirationTime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = builder.Configuration["JWT:Issure"],
                                    ValidAudience = builder.Configuration["JWT:Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
                                };

                            });


            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            // builder.Services.AddScoped<IProductWarehouseService, ProductWarehouseService>();
            builder.Services.AddScoped<IWareHouseService, WarehouseService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IUserManagment, UserManagment>();
            builder.Services.AddScoped<ITokenManagment, TokenManagment>();
            builder.Services.AddScoped<IRoleManagment, RoleManagment>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddAutoMapper(typeof(MapConf));
            //builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
