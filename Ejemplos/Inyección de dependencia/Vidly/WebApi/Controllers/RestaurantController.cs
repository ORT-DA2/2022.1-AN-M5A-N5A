using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Domain;
using BusinessLogicInterface;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantLogic _restaurantLogic;
        
        public RestaurantController(IRestaurantLogic restaurantLogic)
        {
            this._restaurantLogic = restaurantLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Restaurant> restaurants = this._restaurantLogic.GetAll();

            return Ok(restaurants);
        }

        [HttpGet("{restaurantId}", Name = "GetRestaurant")]
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
    }
}
