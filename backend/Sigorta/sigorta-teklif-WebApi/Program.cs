using System;
using sigorta_teklif.Core;
using sigorta_teklif.DataAccess;
using Microsoft.EntityFrameworkCore;
using sigorta_teklif.Business.Managers;
using sigorta_teklif.Business.Services;
using sigorta_teklif.Entity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApplicantService, ApplicantManager>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();


builder.Services.AddScoped<ISigortaPolicyRepository, SigortaPolicyRepository>();
builder.Services.AddScoped<ISigortaService, SigortaManager>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
//builder.Services.AddScoped<ISigortaService, SigortaManager>();
//builder.Services.AddScoped<IRepository<SigortaPolicy>, EfRepository<SigortaPolicy>>();



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