var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapGet("/", httpContext =>
{
    httpContext.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});

app.MapControllers();

app.Run();
