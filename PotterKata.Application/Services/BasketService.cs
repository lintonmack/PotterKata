using Application.Abstractions;
using Application.Entities.Models;

namespace Application.Services;

public class BasketService : IBasketService
{
    private readonly IDiscountService _discountService;

    public BasketService(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public double GetTotal(Basket basket)
    {
        if (basket.Books == null || !basket.Books.Any())
        {
            return 0.00;
        }

        return _discountService.ApplyAllDiscounts(basket);
    }
}