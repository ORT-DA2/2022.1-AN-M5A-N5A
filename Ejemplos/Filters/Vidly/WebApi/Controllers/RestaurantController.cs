using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Domain;
using BusinessLogicInterface;
using WebApi.Filters;

namespace WebApi
{
    [ApiController]
    //[ServiceFilter(typeof(AuthorizationFilter))]
    [ServiceFilter(typeof(ExceptionFilter))]
    [ServiceFilter(typeof(ResultFilter))]

    [Route("restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantLogic _restaurantLogic;
        
        public RestaurantController(IRestaurantLogic restaurantLogic)
        {
            this._restaurantLogic = restaurantLogic;
        }


        [AuthorizationWithParameterFilter("Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Restaurant> restaurants = this._restaurantLogic.GetAll();
            return Ok(restaurants);
        }

        [ServiceFilter(typeof(AuthorizationFilter))]
        [HttpGet("{restaurantId}")]
        public IActionResult GetById(int restaurantId)
        {
            Restaurant restaurant = this._restaurantLogic.GetById(restaurantId);

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Post(Restaurant restaurant)
        {
            Restaurant newRestaurant = this._restaurantLogic.Add(restaurant);

            return CreatedAtRoute("GetRestaurant", new { restaurantId = newRestaurant.Id }, newRestaurant);
        }

        [HttpPut("{restaurantId}")]
        public IActionResult Put(int restaurantId, Restaurant updatedRestaurant)
        {
            this._restaurantLogic.Update(restaurantId, updatedRestaurant);

            return NoContent();
        }

        [HttpDelete("{restaurantId}")]
        public IActionResult Delete(int restaurantId)
        {
            this._restaurantLogic.Delete(restaurantId);

            return NoContent();
        }


        [HttpGet("{EjemploExcpetion}")]
        public IActionResult GetConException()
        {
            this._restaurantLogic.DarExcpetion();
            return Ok("si esto llega a la api algo hice mal");
        }
    }
}
