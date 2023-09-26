using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew;

namespace DiningVsCodeNew.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentDetailsController : ControllerBase
{
    PaymentDetailsRepository repPayDetails;
    public PaymentDetailsController(PaymentDetailsRepository repPayDetails)
    {
        this.repPayDetails = repPayDetails;
    }
    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails()
    {
        return new OkObjectResult(repPayDetails.GetPymtDetails());
    }
    // GET: api/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetailss(int id)
    {
        return new OkObjectResult(repPayDetails.GetPymtDetails(id));
    }
    // PUT: api/users/5
    // To protect from overposting attacks, see https://go.microsoft.com/
    // fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPymtDetails(int id, PaymentDetails pymtDetails)
    {
        if (id != pymtDetails.id)
        {
            return BadRequest();
        }

        repPayDetails.updatePaymentDetails(pymtDetails);
        return new OkObjectResult(pymtDetails);

    }

    [HttpPost]
    public async Task<ActionResult<PaymentDetails>> PostPymtDetails(PaymentDetails pymtDetails)
    {

        if (pymtDetails != null)
        {
            repPayDetails.insertPaymentDetails(pymtDetails);
        }
        return Ok("Posted succesfully");

    }
    // DELETE: api/Cities/5
    [HttpPost("deletepymtdetails")]
    public async Task<IActionResult> deletepymtdetails([FromBody] PaymentDetails pymtdetails)
    {
        //   string test=Request.Headers["Test"];
        int idvalue = 0;
        idvalue = repPayDetails.deletePymtDetails(pymtdetails);
        return Ok(pymtdetails);

    }
    //private bool StateExists(int id)
    // {
    // return _context.States.Any(e => e.Id == id);
    // }

}