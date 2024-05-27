using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Zone.API;
using Zone.API.Controllers.Hubs;
using Zone.API.Controllers.Hubs.ChatHub;
using Zone.API.Middleware;
using Zone.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddSignalR();
builder.Services.AddControllers().AddJsonOptions(options => {options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
builder.Services.AddServices();
builder.Services.RunServices();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    //options.Audience = "http://localhost:4200";
    //options.Authority = "http://localhost:5010";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["URL"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SECRETKEY"]))
    };
});

builder.Services.AddCors(options => options.AddPolicy("General", builder =>
{
    builder.WithOrigins("https://zone-bice.vercel.app","http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
}));

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

app.UseCors("General");
//app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Storage")),
    RequestPath = "/storage"
});
app.UseAuthorization();
app.UseMiddleware<CookieMiddleware>();
app.MapControllers();
app.MapHub<ChatHub>("/chathub").RequireCors("General");
app.Run(builder.Configuration["URL"]);