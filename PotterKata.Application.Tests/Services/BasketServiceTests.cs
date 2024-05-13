using Application.Abstractions;
using Application.Entities.Models;
using Application.Services;
using FluentAssertions;
using Xunit;

namespace PotterKata.Application.Tests.Services;

public class BasketServiceTests
{
    private readonly IBasketService _basketService;
    
    public BasketServiceTests()
    {
        IDiscountService discountService = new DiscountService();
        _basketService = new BasketService(discountService);
    }
    
    [Fact]
    public void GivenAnEmptyBasket_WhenGetTotalIsCalled_ThenPriceOfZeroIsReturned()
    {
        // Given 
        var basket = new Basket();

        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(0.00);
    }
    

    [Fact]
    public void GivenOneHarryPotterBook_WhenGetTotalIsCalled_ThenNoDiscountIsApplied()
    {
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
            }
        };
        
        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(8.00);
    }
    
    [Fact]
    public void GivenTwoDuplicateHarryPotterBook_WhenGetTotalIsCalled_ThenNoDiscountIsApplied()
    {
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
            }
        };

        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(16.00);
    }
    
    [Fact]
    public void GivenOneNonHarryPotterBook_WhenGetTotalIsCalled_ThenNoDiscountIsApplied()
    {
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Not Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 10.00
                }
            }
        };
        
        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(10.00);
    }
    
    [Fact]
    public void GivenTwoSeparateHarryPotterBooks_WhenGetTotalIsCalled_Then5PercentDiscountShouldBeApplied()
    {
        
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 2",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
            }
        };

        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(15.20);
    }

    [Fact]
    public void GivenThreeSeparateHarryPotterBooks_WhenGetTotalIsCalled_Then10PercentDiscountShouldBeApplied()
    {
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 2",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 3",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
            }
        };

        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(21.60);
    }
    
    [Fact]
    public void GivenFourSeparateHarryPotterBooks_WhenGetTotalIsCalled_Then20PercentDiscountShouldBeApplied()
    {
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 2",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 3",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 4",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
            }
        };

        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(25.60);
    }

    [Fact]
    public void GivenFiveSeparateHarryPotterBooks_WhenGetTotalIsCalled_Then25PercentDiscountShouldBeApplied()
    {
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 2",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 3",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 4",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 5",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
            }
        };
        
        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(30.00);
    }

    [Fact]
    public void GivenThreeSeparateHarryPotterBooksAndOneDuplicate_WhenGetTotalIsCalled_ThenCorrectDiscountShouldBeApplied()
    {
                // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 2",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 3",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
            }
        };
        
        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(29.60);
    }
    
    [Fact]
    public void GivenOneFullCollectionAndAnotherContainingThreeUniqueTitles_WhenGetTotalIsCalled_ThenCorrectDiscountShouldBeApplied()
    {
        // Given 
        var basket = new Basket
        {
            Books = new List<Book>
            {
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 1",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 2",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 2",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
                ,
                new()
                {
                    Title = "Book 3",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 3",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 4",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                },
                new()
                {
                    Title = "Book 5",
                    Author = "JK Rowking",
                    Collection = "Harry Potter",
                    Genre = "Fiction",
                    Publisher = "PotterPublishing",
                    Price = 8.00
                }
                
            }
        };
        
        // When
        var result = _basketService.GetTotal(basket);

        // Then
        result.Should().Be(51.60);
    }
}