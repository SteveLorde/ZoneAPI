using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Zone.API;
using Zone.API.Controllers.Hubs;
using Zone.API.Controllers.Hubs.ChatHub;
using Zone.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});;;
builder.Services.AddServices();
builder.Services.RunServices();
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SECRETKEY"]))
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

app.UseCors(options => options.WithOrigins("https://zone-bice.vercel.app/","http://localhost:5116").AllowAnyHeader().AllowAnyMethod());
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
app.Run(builder.Configuration["URL"]);