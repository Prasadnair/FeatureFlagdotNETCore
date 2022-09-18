using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFeatureManagement();
//Ignore Null Values
builder.Services.AddControllers().AddJsonOptions
    (option=>
    {
        option.JsonSerializerOptions.DefaultIgnoreCondition= System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; 
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
