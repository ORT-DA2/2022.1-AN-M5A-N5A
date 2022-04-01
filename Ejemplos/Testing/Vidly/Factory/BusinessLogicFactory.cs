using System;
using BusinessLogic;
using BusinessLogicInterface;
using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    public class BusinessLogicFactory
    {
        private readonly IServiceCollection _serviceCollection;
    
        public BusinessLogicFactory(IServiceCollection serviceCollection)
        {
            this._serviceCollection = serviceCollection;
        }

        public void AddBusinessLogicServices()
        {
            this._serviceCollection.AddScoped<IRestaurantLogic, RestaurantLogic>();
        }
    }
}
