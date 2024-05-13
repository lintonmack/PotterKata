using Application.Entities.Models;

namespace Application.Abstractions;

public interface IPotterPublisherDiscountService
{
    public double ApplyDiscountOfferOnBookCollection(KeyValuePair<string, List<Book>> booksByCollection);
}