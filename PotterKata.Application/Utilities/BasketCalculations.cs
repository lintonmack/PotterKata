using Application.Entities.Models;

namespace Application.Utilities;

public static class BasketCalculations
{
    public static double ApplyNoDiscount(KeyValuePair<string, List<Book>> books)
    {
        return books.Value.Sum(book => book.Price);
    }
}