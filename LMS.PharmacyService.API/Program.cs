using LMS.PharmacyService.API.Database;
using LMS.PharmacyService.API.Repository;
using MongoFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<PharmacyServiceApiContext>();
builder.Services.AddTransient<IMongoDbConnection>(x => MongoDbConnection.
    FromConnectionString(builder.Configuration.GetConnectionString("MongoDB")));

builder.Services.AddScoped<IPharmacyServiceRepository, PharmacyServiceRepository>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();

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
