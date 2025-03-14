using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeder;

internal class RestaurantsSeeder(RestaurantsDbContext dbContext) : IRestaurantsSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
        [
            new (UserRoles.User)
            {
                NormalizedName = UserRoles.User.ToUpper()
            },
            new (UserRoles.Owner)
            {
                NormalizedName = UserRoles.Owner.ToUpper()
            },
            new (UserRoles.Admin)
            {
                NormalizedName = UserRoles.Admin.ToUpper()
            },
        ];

        return roles;
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = new()
    {
        new Restaurant
        {
            Name = "KFC",
            Category = "Fast Food",
            Description = "Famous for fried chicken and quick meals.",
            ContactEmail = "contact@kfc.com",
            ContactNumber = "123-456-7890",
            HasDelivery = true,
            Address = new Address
            {
                City = "New York",
                Street = "123 Main St",
                PostalCode = "10001"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Original Recipe Chicken",
                    Description = "Crispy and juicy fried chicken.",
                    Price = 8.99M
                },
                new Dish
                {
                    Name = "Spicy Wings",
                    Description = "Hot and spicy chicken wings.",
                    Price = 6.50M
                }
            }
        },
        new Restaurant
        {
            Name = "Pizza Hut",
            Category = "Pizza",
            Description = "Serving delicious pizzas since 1958.",
            ContactEmail = "info@pizzahut.com",
            ContactNumber = "987-654-3210",
            HasDelivery = true,
            Address = new Address
            {
                City = "Chicago",
                Street = "456 Oak Ave",
                PostalCode = "60601"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Pepperoni Pizza",
                    Description = "Classic pizza with pepperoni and cheese.",
                    Price = 12.99M
                }
            }
        },
        new Restaurant
        {
            Name = "Sushi Zen",
            Category = "Japanese",
            Description = "Authentic Japanese sushi and sashimi.",
            ContactEmail = "sushizen@email.com",
            HasDelivery = false,
            Address = new Address
            {
                City = "San Francisco",
                Street = "789 Pine St",
                PostalCode = "94102"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Salmon Nigiri",
                    Description = "Fresh salmon over rice.",
                    Price = 5.99M
                }
            }
        },
        new Restaurant
        {
            Name = "Taco Bell",
            Category = "Mexican",
            Description = "Fast Mexican-inspired food.",
            ContactEmail = "tacobell@support.com",
            ContactNumber = "555-123-4567",
            HasDelivery = true,
            Address = new Address
            {
                City = "Los Angeles",
                Street = "101 Taco Rd",
                PostalCode = "90001"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Crunchy Taco",
                    Description = "Beef taco with lettuce and cheese.",
                    Price = 2.49M
                }
            }
        },
        new Restaurant
        {
            Name = "Olive Garden",
            Category = "Italian",
            Description = "Family-friendly Italian dining.",
            ContactEmail = "olivegarden@contact.com",
            HasDelivery = false,
            Address = new Address
            {
                City = "Miami",
                Street = "321 Olive Ln",
                PostalCode = "33101"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Fettuccine Alfredo",
                    Description = "Creamy pasta with parmesan.",
                    Price = 14.99M
                }
            }
        },
        new Restaurant
        {
            Name = "Burger King",
            Category = "Fast Food",
            Description = "Home of the Whopper.",
            ContactEmail = "bk@support.com",
            ContactNumber = "444-555-6666",
            HasDelivery = true,
            Address = new Address
            {
                City = "Houston",
                Street = "654 Burger Dr",
                PostalCode = "77001"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Whopper",
                    Description = "Flame-grilled burger with toppings.",
                    Price = 7.99M
                }
            }
        },
        new Restaurant
        {
            Name = "Cheesecake Factory",
            Category = "American",
            Description = "Extensive menu with signature cheesecakes.",
            ContactEmail = "info@cheesecakefactory.com",
            HasDelivery = false,
            Address = new Address
            {
                City = "Seattle",
                Street = "987 Cake St",
                PostalCode = "98101"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Original Cheesecake",
                    Description = "Creamy cheesecake with graham crust.",
                    Price = 8.50M
                }
            }
        },
        new Restaurant
        {
            Name = "Subway",
            Category = "Sandwiches",
            Description = "Customizable subs made fresh.",
            ContactEmail = "subway@contact.com",
            ContactNumber = "333-222-1111",
            HasDelivery = true,
            Address = new Address
            {
                City = "Boston",
                Street = "147 Sub Way",
                PostalCode = "02108"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Turkey Sub",
                    Description = "Turkey breast with veggies on wheat.",
                    Price = 6.99M
                }
            }
        },
        new Restaurant
        {
            Name = "Thai Spice",
            Category = "Thai",
            Description = "Spicy and flavorful Thai cuisine.",
            ContactEmail = "thaispice@email.com",
            HasDelivery = true,
            Address = new Address
            {
                City = "Denver",
                Street = "258 Spice Rd",
                PostalCode = "80202"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Pad Thai",
                    Description = "Stir-fried noodles with peanuts.",
                    Price = 11.99M
                }
            }
        },
        new Restaurant
        {
            Name = "Le Bistro",
            Category = "French",
            Description = "Elegant French dining experience.",
            ContactEmail = "lebistro@french.com",
            ContactNumber = "777-888-9999",
            HasDelivery = false,
            Address = new Address
            {
                City = "New Orleans",
                Street = "369 French St",
                PostalCode = "70112"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Coq au Vin",
                    Description = "Chicken braised in red wine.",
                    Price = 19.99M
                }
            }
        }
    };

        return restaurants;
    }

}