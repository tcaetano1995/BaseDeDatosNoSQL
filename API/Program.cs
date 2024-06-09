using API.Controllers;
using Cassandra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Cassandra configuration
var cassandraCluster = Cluster.Builder()
    .AddContactPoints("localhost") // Change to your Cassandra contact points
    .WithDefaultKeyspace("obligatorio") // Change to your Cassandra keyspace
    .Build();
var session = cassandraCluster.Connect();


// Register Cassandra session in dependency injection container
builder.Services.AddSingleton(session);

// Add ForoLogic to dependency injection container
builder.Services.AddScoped<Logic>();

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
