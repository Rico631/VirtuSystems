using Microsoft.EntityFrameworkCore;
using TestProject1.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", corsBuilder =>
{
    corsBuilder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials();
}));

builder.Services.AddDbContext<Context>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dc = scope.ServiceProvider.GetRequiredService<Context>();
    dc.Database.Migrate();
}

app.UseCors("ApiCorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
