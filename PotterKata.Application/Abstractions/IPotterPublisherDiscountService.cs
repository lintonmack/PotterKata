using Application.Entities.Models;

namespace Application.Abstractions;

public interface IPotterPublisherDiscountService
{
    public double ApplyDiscountOnBookCollection(KeyValuePair<string, List<Book>> booksByCollection);
}