using Application.Entities.Models;

namespace Application.Abstractions;

public interface IBasketService
{
    public double GetTotal(Basket basket);
}