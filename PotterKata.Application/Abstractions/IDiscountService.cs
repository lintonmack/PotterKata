using Application.Entities.Models;

namespace Application.Abstractions;

public interface IDiscountService
{
    public double ApplyAllDiscounts(Basket basket);
}