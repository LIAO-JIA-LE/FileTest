var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//文件上傳服務
builder.Services.AddMvc();

var app = builder.Build();

app.Urls.Add("http://localhost:5003");
//提供靜態文件
app.UseStaticFiles();
//CROS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin() // 允许任何来源
            .AllowAnyMethod() // 允许任何HTTP方法
            .AllowAnyHeader(); // 允许任何HTTP标头
});

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
