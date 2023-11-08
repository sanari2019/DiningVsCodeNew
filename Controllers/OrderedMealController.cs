using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew;

namespace DiningVsCodeNew.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderedMealController : ControllerBase
{
    OrderedMealRepository ordMeal;
    public OrderedMealController(OrderedMealRepository ordMeal)
    {
        this.ordMeal = ordMeal;
    }
    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult> GetOrdMeals()
    {
        return new OkObjectResult(ordMeal.GetOrderedMeals());
    }
    // GET: api/Cities/5
    [HttpPost("getordmealsbycust")]
    public async Task<ActionResult<IEnumerable<OrderedMeal>>> GetorderedMealsbyCust([FromBody] User us)
    {
        return ordMeal.GetOrderedMealsbyCust(us);
    }
    [HttpPost("getordmealsbypymtid")]
    public async Task<ActionResult<IEnumerable<OrderedMeal>>> GetorderedMealsbyPymtId([FromBody] PaymentMain pymtmain)
    {
        return ordMeal.GetPaidOrderedMeals(pymtmain);
    }

    // GET: api/OrderedMeal/AlacarteOrders
    [HttpGet("AlacarteOrders")]
    public ActionResult<IEnumerable<ServedAlacarteVoucherModel>> GetAlacarteOrders([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var alacarteOrders = ordMeal.ExecuteAlacarteOrders(startDate, endDate);
        return Ok(alacarteOrders);
    }
    // PUT: api/users/5
    // To protect from overposting attacks, see https://go.microsoft.com/
    // fwlink/?linkid=2123754
    [HttpPost("{id}")]
    public async Task<IActionResult> PutOrdMeal(int id, OrderedMeal ordMeal)
    {
        if (id != ordMeal.Id)
        {
            return BadRequest();
        }
        // _context.Entry(state).State = EntityState.Modified;

        this.ordMeal.updateOrderedMeal(ordMeal);
        return new OkObjectResult(ordMeal);

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
    public async Task<ActionResult<OrderedMeal>> PostOrderedMeal(OrderedMeal omeal)
    {

        if (omeal != null)
        {
            Menu selectedmenu = new Menu();
            omeal.Active = true;
            ordMeal.insertOrderedMeal(omeal);
        }
        return new OkObjectResult(omeal);

    }
    [HttpPost("deleteorderedmeal")]
    public async Task<IActionResult> Delete([FromBody] OrderedMeal omeal)
    {


        var id = ordMeal.deleteOrderedMeal(omeal);
        return Ok(omeal);
    }
    //private bool StateExists(int id)
    // {
    // return _context.States.Any(e => e.Id == id);
    // }

}