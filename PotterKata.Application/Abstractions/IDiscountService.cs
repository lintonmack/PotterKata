using Application.Entities.Models;

namespace Application.Abstractions;

public interface IDiscountService
{
    public double GetAllDiscounts(Basket basket);
}