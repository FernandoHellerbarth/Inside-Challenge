using InsideChallenge.Application;
using InsideChallenge.Infrastructure;

namespace InsideChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services.AddApplicationServices();
                builder.Services.AddInfrastructure(builder.Configuration);
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
