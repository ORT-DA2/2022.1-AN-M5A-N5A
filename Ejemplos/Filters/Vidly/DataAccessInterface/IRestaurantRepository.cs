using System;
using System.Collections.Generic;
using Domain;

namespace DataAccessInterface
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        List<Product> GetProductsOrderByPrice(int idRestaurant);
    }
}
