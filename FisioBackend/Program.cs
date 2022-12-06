namespace FisioBackend;
using FisioBackend.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddCors();

        // adicionar middlewares (serviços)
        builder.Services.AddControllers();

        builder.Services.AddCors(option =>
            option.AddPolicy(name: "MyAllowSpecificOrigins",
             builder =>
             {
                 builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowAnyOrigin();
             }));


        // singleton ou transient
        //builder.Services.AddDbContext<BDFisio>(option => option.UseInMemoryDatabase("db"));
        string strConn = builder.Configuration.GetConnectionString("BDInter");
        builder.Services.AddDbContext<BDFisio>(option => option.UseSqlServer(strConn));

        // adicionar o middleware Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("MyAllowSpecificOrigins");

        // usar middlewares (adiciona no pipeline de execução)
        app.MapControllers();

        // inicia a aplicação
        app.Run();
    }
}