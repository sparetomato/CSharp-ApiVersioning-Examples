using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1.0", new OpenApiInfo { Title = "My API - V1", Version = "1.0" });
    c.SwaggerDoc("2.0", new OpenApiInfo { Title = "My API - V2", Version = "2.0" });
    c.SwaggerDoc("3.0", new OpenApiInfo { Title = "My API - V3", Version = "3.0" });
});


builder.Services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(o =>
{
   // o.GroupNameFormat = "v'VVV";
    o.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.SwaggerEndpoint("/swagger/1.0/swagger.json", "1.0");
    o.SwaggerEndpoint("/swagger/2.0/swagger.json", "2.0");
    o.SwaggerEndpoint("/swagger/3.0/swagger.json", "3.0");
}
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
