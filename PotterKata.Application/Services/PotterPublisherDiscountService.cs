using Application.Abstractions;
using Application.Entities.Models;
using Application.Entities.PublisherDiscounts.PotterPublishing;
using Application.Utilities;

namespace Application.Services;

public class PotterPublisherDiscountService : IPublisherDiscountService
{
    private const string HarryPotter = "Harry Potter";

    private readonly Dictionary<string, IPotterPublisherDiscountService> _potterPublisherDiscounts = new()
    {
        { HarryPotter, new HarryPotterCollectionDiscountOffer() }
    };

    public double ApplyAllPublisherDiscounts(List<Book> books)
    {
        var booksByCollection = BasketSort.SortByCollection(books);

        var revisedPrice = 0.00;

        foreach (var collection in booksByCollection)
        {
            if (!_potterPublisherDiscounts.TryGetValue(collection.Key, out var discountOnCollection))
            {
                revisedPrice += BasketCalculations.ApplyNoDiscount(collection);
                continue;
            }

            revisedPrice += discountOnCollection.ApplyDiscountOfferOnBookCollection(collection);
        }

        return revisedPrice;
    }
}