using Hotelier.BusinessLayer;
using Hotelier.DataAccessLayer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Hotelier.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddBusinessServices();

        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("HotelierApiCors", opt =>
            {
                opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.DocExpansion(DocExpansion.None));
        }

        app.UseHttpsRedirection();

        app.UseCors("HotelierApiCors");
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
