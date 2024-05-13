namespace Application.Entities.Models;

public record Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Collection { get; set; }
    public string Publisher { get; set; }
    public double Price { get; set; }
    
}