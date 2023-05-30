using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Host
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"OcelotConsul.json", optional: false, reloadOnChange: true);
    //config.AddOcelot((global::Microsoft.AspNetCore.Hosting.IWebHostEnvironment)hostingContext.HostingEnvironment); //12.x版本 要加环境  自动查询所有Ocelot.xx.json
});

var authenticationProviderKey = "server1";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(authenticationProviderKey, options =>
    {
        options.Authority = "http://localhost:2000"; //IDS4地址
        options.ApiName = "server";
        options.RequireHttpsMetadata = false; //不适用https
        options.SupportedTokens = SupportedTokens.Both;
    });
    

// Add services to the container.
builder.Services.AddOcelot().AddConsul().AddPolly();
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
