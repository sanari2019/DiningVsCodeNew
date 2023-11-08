using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew.Models;


namespace DiningVsCodeNew.Controllers;

[ApiController]
[Route("[controller]")]
public class OnlinePaymentController : ControllerBase
{
    private OnlinePaymentRepository reponlinePayment;
    private UserRepository repuser;
    int idvalue = 0;
    private EmailConfiguration _emailConfig;
    public OnlinePaymentController(OnlinePaymentRepository reponlinePymt, EmailConfiguration emailConfig, UserRepository repUser)
    {
        this.reponlinePayment = reponlinePymt;
        this._emailConfig = emailConfig;
        this.repuser = repUser;
    }
    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult> GetOnlinePayments()
    {
        return new OkObjectResult(reponlinePayment.GetOnlinePayments());
    }
    // GET: api/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OnlinePayment>> GetOnlinePayment(int id)
    {
        return new OkObjectResult(reponlinePayment.GetOnlinePayment(id));

    }

    //  [HttpGet("getuser/{userName}")]
    //  public async Task<ActionResult<User>> GetUser(string username)
    // {
    //     return new OkObjectResult(repuser.GetUser(username));  
    // }
    // PUT: api/users/5
    // To protect from overposting attacks, see https://go.microsoft.com/
    // fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOnlinePayment(int id, OnlinePayment onlinePymt)
    {
        if (id != onlinePymt.Id)
        {
            return BadRequest();
        }
        // _context.Entry(state).State = EntityState.Modified;

        this.reponlinePayment.updateOnlinePayment(onlinePymt);
        return new OkObjectResult(onlinePymt);

        // catch (DbUpdateConcurrencyException)
        // {
        // if (!StateExists(id))
        //  {
        //  return NotFound();
        // }
        // else
        //  {
        // throw;
        // }
    }
    //return NoContent();
    // POST: api/Cities
    // To protect from overposting attacks, see https://go.microsoft.com/
    //fwlink /? linkid = 2123754
    [HttpPost]
    public async Task<ActionResult<OnlinePayment>> PostOnlinePayment(OnlinePayment onlinePymt)
    {

        if (onlinePymt != null)
        {
            User us = new User();
            us = repuser.GetUser(onlinePymt.Paidby);
            EmailSender _emailSender = new EmailSender(this._emailConfig);
            Email em = new Email();
            string logourl = "";//"https://evercaregroup.com/wp-content/uploads/2020/12/EVERCARE_LOGO_03_LEKKI_PRI_FC_RGB.png";
            string applink = "https://cafeteria.evercare.ng";
            string salutation = "Dear " + us.firstName + ",";
            string emailcontent = "We have successfully received your payment of: " + "NGN" + onlinePymt.AmountPaid.ToString("N") + " Thanks for visiting Evercare's cafeteria";
            string narration1 = " ";
            string econtent = em.HtmlMail("Payment Confirmation", applink, salutation, emailcontent, narration1, logourl);
            var message = new Message(new string[] { us.userName }, "Cafeteria Application", econtent);
            await _emailSender.SendEmailAsync(message);
            reponlinePayment.insertOnlinePayment(onlinePymt);
        }
        return Ok(onlinePymt);

    }
    // DELETE: api/Cities/5
    [HttpPost("deleteonlinePayment")]
    public async Task<IActionResult> Delete([FromBody] OnlinePayment onlinePymt)
    {

        // if (idvalue != us.id)
        //  {
        //  return NotFound();
        //  }
        idvalue = reponlinePayment.deleteOnlinePayment(onlinePymt);
        return Ok(onlinePymt);
    }
    //private bool StateExists(int id)
    // {
    // return _context.States.Any(e => e.Id == id);
    // }
    [HttpGet("TotalRevenue")]
    public ActionResult<IEnumerable<TotalRevenueModel>> GetTotalRevenue([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var totalRevenue = reponlinePayment.GetTotalRevenue(startDate, endDate);
        return Ok(totalRevenue);
    }


}