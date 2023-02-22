using CA.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL("server = localhost;database = AuthenticationApi;uid = root ; pwd = 123456"));
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//string[] urls = new string[] {"https://localhost:7207/Re-LO"};
builder.Services.AddCors(options => {options.AddDefaultPolicy(builder =>{
	builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
	});	
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
