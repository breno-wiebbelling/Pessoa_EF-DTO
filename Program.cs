using Microsoft.EntityFrameworkCore;
using teste.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoginContext> (opcoes => 
    opcoes.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
