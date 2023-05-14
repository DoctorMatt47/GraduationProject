using System.Security.Principal;
using GraduationProject.Application.Common.Extensions;
using GraduationProject.Infrastructure.Common.Extensions;
using GraduationProject.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddBearerAuthentication(builder.Configuration)
    .AddControllers();

builder.Services
    .AddHttpContextAccessor()
    .AddScoped<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>()!.HttpContext!.User);
    
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

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
