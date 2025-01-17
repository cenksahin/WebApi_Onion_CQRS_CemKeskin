using Microsoft.Extensions.Configuration;
using YoutubeApi.Persistence;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Swagger hizmetini ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "My ASP.NET Core 9 API"
    });
});

//ortama göre ayarlarý set ettik.
var environment = builder.Environment;
builder.Configuration.SetBasePath(environment.ContentRootPath).AddJsonFile("appsettings.json", optional: false).AddJsonFile($"appsettings.{environment}.json", optional: true);

//ekle
builder.Services.AddPersistence(builder.Configuration);


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    //https://localhost:5276/swagger/index.html
    app.UseSwagger();
    app.UseSwaggerUI(); //Swagger UI'ý baþlatýr

    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();