using System.Text;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Zone.API;
using Zone.API.Controllers.Hubs;
using Zone.API.Controllers.Hubs.ChatHub;
using Zone.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddSignalR();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    //options.Audience = "http://localhost:4200";
    //options.Authority = "http://localhost:5010";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["URL"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["secretkey"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Storage")),
    RequestPath = "/storage"
});

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/Chat");


app.Run();