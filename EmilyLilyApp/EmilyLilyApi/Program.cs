using Azure.Data.Tables;
using EmilyLilyApi.Services;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var CONN_STRING = builder.Configuration.GetConnectionString("AzureTableConnectionString");
var TableName = builder.Configuration.GetValue<string>("AzureTableName");

TableServiceClient serviceClient = new TableServiceClient(CONN_STRING);
TableClient tableClient = serviceClient.GetTableClient(TableName);

builder.Services.AddSingleton(tableClient);
builder.Services.AddSingleton<TableServices>();
builder.Services.AddScoped<IMessenger, Emailer>();

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