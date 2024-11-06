using Microsoft.EntityFrameworkCore;
using SberBankOnline.Interfaces.Repository;
using SberBankOnline.Repository;
using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Repository;
using SberBanOnline.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SberonlineContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PSQL"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICardRepository,CardRepository>();
builder.Services.AddScoped<ICardTypeRepository, CardTypeRepository>();
builder.Services.AddScoped<IExchangeRateRepositroy, ExchangeRateRepository>();

builder.Services.AddScoped<ICardServices, CardServices>();
builder.Services.AddScoped<ICardTypeServices, CardTypeServices>();
builder.Services.AddScoped<IExchangeRateServices, ExchangeRateServices>();

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
