namespace OnlineShop.Application.Requests;

public class CreateProductRequest
{
    public CreateProductRequest(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; }

    public string Description { get; }

    public decimal Price { get; }
}
