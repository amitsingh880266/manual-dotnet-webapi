using manual_dotnet_webapi.dtos;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
}
);
app.MapGet("/", () =>
{
    return $"Hello World! The current time is {DateTime.Now}";
});
app.MapGet("/orders", (int size, int page) =>
{
    return $"Size: {size}, Page: {page}";
});


app.MapPost("/orders", (CreateOrderRequest request) =>
{   
    Console.WriteLine(request.CustomerEmail);
    return Results.Ok(new
    {
        Message = "Order created successfully",
        CustomerName = request.CustomerName,
        CustomerEmail = request.CustomerEmail
    });
});

app.Run();