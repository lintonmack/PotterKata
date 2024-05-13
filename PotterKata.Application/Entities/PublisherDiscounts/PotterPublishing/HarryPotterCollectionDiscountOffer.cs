using Application.Abstractions;
using Application.Entities.Models;
using Application.Utilities;

namespace Application.Entities.PublisherDiscounts.PotterPublishing;

public class HarryPotterCollectionDiscountOffer : IPotterPublisherDiscountService
{
    public double ApplyDiscountOfferOnBookCollection(KeyValuePair<string, List<Book>> booksByCollection)
    {
        var booksInHarryPotterCollection = BasketSort.SortByTitle(booksByCollection);

        var revisedPriceAfterDiscount = 0.00;
        var previousIndexBookQuantity = 0;


        for (var i = booksInHarryPotterCollection.Length - 1; i >= 0; i--)
        {
            if (previousIndexBookQuantity == booksInHarryPotterCollection[i])
            {
                continue;
            }

            var numberOfUniqueItemsInCollection = i + 1;

            revisedPriceAfterDiscount +=
                CalculateDiscountOnCollection(numberOfUniqueItemsInCollection,
                    booksInHarryPotterCollection[i] - previousIndexBookQuantity);
            previousIndexBookQuantity = booksInHarryPotterCollection[i];
        }

        return revisedPriceAfterDiscount;
    }

    private static double CalculateDiscountOnCollection(int uniqueBookCountInCollection,
        int quantityOfUniqueCollections)
    {
        return uniqueBookCountInCollection switch
        {
            2 => quantityOfUniqueCollections * 2 * 8.00 * 0.95,
            3 => quantityOfUniqueCollections * 3 * 8.00 * 0.90,
            4 => quantityOfUniqueCollections * 4 * 8.00 * 0.80,
            5 => quantityOfUniqueCollections * 5 * 8.00 * 0.75,
            _ => quantityOfUniqueCollections * 8.00
        };
    }
}