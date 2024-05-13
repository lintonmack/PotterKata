using Application.Abstractions;
using Application.Entities.Models;
using Application.Utilities;

namespace Application.Services;

public class DiscountService : IDiscountService
{
    private const string PotterPublishing = "PotterPublishing";

    private readonly Dictionary<string, IPublisherDiscountService> _publisherDiscountService = new()
    {
        { PotterPublishing, new PotterPublisherDiscountService() }
    };

    public double ApplyAllDiscounts(Basket basket)
    {
        var booksByPublishers = BasketSort.SortByPublisher(basket.Books);
        return booksByPublishers.Sum(ApplyAllDiscountsFromSelectedPublisher);
    }

    private double ApplyAllDiscountsFromSelectedPublisher(KeyValuePair<string, List<Book>> booksByPublisher)
    {
        if (!_publisherDiscountService.TryGetValue(booksByPublisher.Key, out var publisherDiscountService))
        {
            return BasketCalculations.ApplyNoDiscount(booksByPublisher);
        }

        return publisherDiscountService.ApplyAllPublisherDiscounts(booksByPublisher.Value);
    }
}