using Application.Entities.Models;

namespace Application.Abstractions;

public interface IPublisherDiscountService
{
    public double ApplyAllPublisherDiscounts(List<Book> books);
}