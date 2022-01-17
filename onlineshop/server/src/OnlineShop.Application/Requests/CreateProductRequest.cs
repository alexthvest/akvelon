namespace OnlineShop.Application.Requests;

public class CreateProductRequest
{
    public CreateProductRequest(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
