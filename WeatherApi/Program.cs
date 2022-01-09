using WeatherApi;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient(x => new ConverterClient(new Uri($"https://localhost:1802")));
builder.Services.AddTransient(x => new ConverterClient(builder.Configuration.GetServiceUri("conversionapi")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
