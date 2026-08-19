namespace manual_dotnet_webapi.dtos;
public record CreateOrderRequest(
    string CustomerName,
    string CustomerEmail
);