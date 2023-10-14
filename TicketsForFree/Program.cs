using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TicketsForFree.Data;

using TicketsForFree.Services;
using TicketsForFree.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TicketsForFree
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
            builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IJourneyService, JourneyService>();
            builder.Services.AddScoped<ISeatService, SeatService>();
<<<<<<< HEAD
            builder.Services.AddScoped<IReservationService, ReservationService>();
=======
>>>>>>> cb32489a51433bf8958d45d859864c9408c31f75
            builder.Services.AddDbContext<TicketsDbContext>();
           
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