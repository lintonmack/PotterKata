using Application.Entities.Models;

namespace Application.Utilities;

public static class BasketSort
{
    public static Dictionary<string, List<Book>> SortByCollection(List<Book> books)
    {
        return books.GroupBy(book => book.Collection)
            .ToDictionary(grouping => grouping.Key, grouping => grouping.ToList());
    }

    public static int[] SortByTitle(KeyValuePair<string, List<Book>> books)
    {
        return books.Value.GroupBy(book => book.Title)
            .Select(grouping => grouping.Count())
            .OrderByDescending(x => x)
            .ToArray();
    }

    public static Dictionary<string, List<Book>> SortByPublisher(List<Book> books)
    {
        return books
            .GroupBy(book => book.Publisher)
            .ToDictionary(grouping => grouping.Key, grouping => grouping
                .ToList());
    }
}