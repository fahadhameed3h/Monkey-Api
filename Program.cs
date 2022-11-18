using Monkey_Api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMonkeyShelter, MonkeyShelter>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/GetSpiecesCount", (IMonkeyShelter _MonkeyShelter) =>
{
    return _MonkeyShelter.GetSpiecesCount();
});
app.MapGet("/GetSpieces", (IMonkeyShelter _MonkeyShelter) =>
{
    return _MonkeyShelter.GetSpieces();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
