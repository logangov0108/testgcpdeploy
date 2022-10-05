using Microsoft.AspNetCore.Hosting;

WebApplicationBuilder builder;
#if DEBUG
    builder = WebApplication.CreateBuilder(args);
#endif


#if !DEBUG
      
    builder.WebHost.UseUrls("http://*:8080", "https://*:443"); 

#endif


// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
