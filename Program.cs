using Aplication.Client.API;
using Aplication.Client.API.Context;
using Aplication.Client.API.Repository;
using Aplication.Client.API.Repository.Imp;
using Aplication.Client.API.Services;
using Aplication.Client.API.Services.Imp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIClient", Version = "v1" });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.Configure<Image>(builder.Configuration.GetSection("Image"));
builder.Services.Configure<ServerMode>(builder.Configuration.GetSection("ServerMode"));

builder.Services.AddTransient<IProductsRepository, ImpProductsRepository>();
builder.Services.AddTransient<IProducts, ImpProducts>();
builder.Services.AddTransient<ITrainingShiftRepository, ImpTrainingShiftRepository>();
builder.Services.AddTransient<ITrainingShift, ImpTrainingShift>();
builder.Services.AddTransient<IIdentificationImageRepository, ImpIdentificationImageRepository>();
builder.Services.AddTransient<ISocialMediaRepository, ImpSocialMediaRepository>();
builder.Services.AddTransient<IAddressRepository, ImpAddressRepository>();
builder.Services.AddTransient<IAddress, ImpAddress>();
builder.Services.AddTransient<ICustomerRepository, ImpCustomerRepository>();
builder.Services.AddTransient<ICustomer, ImpCustomer>();
builder.Services.AddTransient<IManagerImage, ImpManagerImage>();
builder.Services.AddTransient<ISuscriptionRepository, ImpSuscriptionsRepository>();
builder.Services.AddTransient<ISuscription, ImpSuscriptions>();
builder.Services.AddTransient<ITutorRepository,ImpTutorRepository>();
builder.Services.AddTransient<ITutor, ImpTutor>();
builder.Services.AddTransient<IKinshipRepository, ImpKinshipRepository>();
builder.Services.AddTransient<IKinship, ImpKinship>();
builder.Services.AddTransient<IPoliticsRepository,ImpPoliticsRepository>();
builder.Services.AddTransient<IPolitics,ImpPolitics>();
builder.Services.AddTransient<ITermsAndConditionsRepository, ImpTermsAndConditionsRepositor>();
builder.Services.AddTransient<ICustomerPoliticsRepository, ImpCustomerPoliticsRepository>();
builder.Services.AddTransient<ICustomerPolitics, ImpCustomerPolitic>();
builder.Services.AddTransient<ICustomerAnswerTestRepository, ImpCustomerAnswerTestRepository>();
builder.Services.AddTransient<ICustomerAnswerTest, ImpCustomerAnswerTest>();
builder.Services.AddTransient<IAnswerTestHealth, ImpAnswerTestHealth>();
builder.Services.AddTransient<IAnswerTestHealthRepository, ImpAnswerTestHealthRepository>();



builder.Services.AddCors(o => o.AddPolicy("Client", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors("Client");

app.UseAuthorization();

app.MapControllers();

app.Run();
