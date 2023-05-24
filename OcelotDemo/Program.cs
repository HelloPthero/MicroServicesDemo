using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//builder.Host
//.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile($"Ocelot.json", optional: false, reloadOnChange: true);
//    //config.AddOcelot((global::Microsoft.AspNetCore.Hosting.IWebHostEnvironment)hostingContext.HostingEnvironment); //12.x版本 要加环境  自动查询所有Ocelot.xx.json
//})
//;


// Add services to the container.
builder.Services.AddOcelot();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{
    config
        .AddOcelot((global::Microsoft.AspNetCore.Hosting.IWebHostEnvironment)hostingContext.HostingEnvironment);
}).UseUrls("http://*:1000");
//builder.WebHost.UseUrls("http://*:1000");
var app = builder.Build();
app.UseOcelot().Wait();
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
