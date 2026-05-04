using e_commerce.BLL.Services;
using e_commerce.DAL.Data;
using e_commerce.DAL.Models.User;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddIdentity< AppUser, IdentityRole>(option =>

    {
        option.Password.RequireDigit = true;
        option.Password.RequiredLength = 6;
        option.Password.RequireUppercase = true;
        option.Password.RequireLowercase = true;
    }
).AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


        
builder.Services.AddAuthentication();
builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
