using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DiningVsCodeNew.Models; // Import your model
using DiningVsCodeNew; // Import your repository

namespace DiningVsCodeNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvailableMealController : ControllerBase
    {
        private readonly AvailableMealRepository availableMealRepo;

        public AvailableMealController(AvailableMealRepository availableMealRepo)
        {
            this.availableMealRepo = availableMealRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AvailableMeal>> GetAllAvailableMeals()
        {
            var availableMeals = availableMealRepo.GetAllAvailableMeals();
            return Ok(availableMeals);
        }


        [HttpGet("ActiveMeals")]
        public ActionResult<IEnumerable<AvailableMeal>> GetActiveMeals()
        {
            var activeMeals = availableMealRepo.GetActiveMeals();
            return Ok(activeMeals);
        }

        [HttpGet("InactiveMeals")]
        public ActionResult<IEnumerable<AvailableMeal>> GetInactiveMeals()
        {
            var inactiveMeals = availableMealRepo.GetInactiveMeals();
            return Ok(inactiveMeals);
        }


        [HttpPost]
        public IActionResult InsertAvailableMeal([FromBody] AvailableMeal availableMeal)
        {
            availableMeal.DateCreated = DateTime.Now;
            availableMealRepo.InsertAvailableMeal(availableMeal);
            return Ok(availableMeal);
        }

        [HttpPost("update")]
        public IActionResult UpdateAvailableMeal([FromBody] AvailableMeal availableMeal)
        {
            // Your validation or logic here

            availableMealRepo.UpdateAvailableMeal(availableMeal);
            return Ok(availableMeal);
        }

        [HttpPost("deleteavailablemeal")]
        public IActionResult DeleteAvailableMeal([FromBody] AvailableMeal availableMeal)
        {
            int deletedId = availableMealRepo.DeleteAvailableMeal(availableMeal);
            return Ok(deletedId);
        }

        // Other custom actions as needed


    }
}
