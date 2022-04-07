using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly DbSet<Restaurant> dbSet;
        private readonly DbContext context;
        public RestaurantRepository(DbContext context) : base(context)
        {
            this.dbSet = context.Set<Restaurant>();
            this.context = context;


        }

        public List<Product> GetProductsOrderByPrice( int idRestaurant)
        {
            Restaurant rest = dbSet.Find(idRestaurant);
            List<Product> ret= (List<Product>)rest.Products.OrderBy(R => R.Price) ;
            return ret;

        }
    }
}
