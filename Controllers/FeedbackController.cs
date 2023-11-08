using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew;

namespace DiningVsCodeNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        FeedbackRepository feedbackRepository;

        public FeedbackController(FeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        [HttpPost]
        public ActionResult PostFeedback([FromBody] Feedback feedback)
        {
            if (feedback != null)
            {
                feedbackRepository.InsertFeedback(feedback);
                return Ok(feedback);
            }

            return BadRequest("Invalid feedback data");
        }

        // Add additional endpoints for retrieving, updating, and deleting feedback if needed
    }
}
