using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DiningVsCodeNew.Models; // Import your model
using DiningVsCodeNew; // Import your repository

namespace DiningVsCodeNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealActivityController : ControllerBase
    {
        private readonly MealActivityRepository MealActivityRepo;

        public MealActivityController(MealActivityRepository MealActivityRepo)
        {
            this.MealActivityRepo = MealActivityRepo;
        }






        [HttpPost]
        public IActionResult InsertMealActivity([FromBody] MealActivity MealActivity)
        {
            // MealActivity.DateCreated = DateTime.Now;
            MealActivityRepo.InsertMealActivity(MealActivity);
            return Ok(MealActivity);
        }

        [HttpPost("update")]
        public IActionResult UpdateMealActivity([FromBody] MealActivity MealActivity)
        {
            // Your validation or logic here

            MealActivityRepo.UpdateMealActivity(MealActivity);
            return Ok(MealActivity);
        }



        // Other custom actions as needed


    }
}
