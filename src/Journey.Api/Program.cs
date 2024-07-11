using System.Reflection;
using Journey.Api.Filters;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            options.EnableAnnotations();
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Journey Api", Version = "V1",
                    Description = "API para gerenciamento de viagens. Feito no NLW da Rocketseat"
                });
        });

        builder.Services.AddMvc(config => { config.Filters.Add(new ExceptionFilter()); });

        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}