using allAp�.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;//devolepment se�ti�inde 
builder.Configuration.SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional:false) //olmas� gereken 
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); //ikiye b�lm�� de olabilirim olmayabilirim de

builder.Services.AddPersistence(builder.Configuration); 
    var app = builder.Build();

// Configure the HTTP request pipeline.builder.Services.AddPersistence(builder.Configuration); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
//55555