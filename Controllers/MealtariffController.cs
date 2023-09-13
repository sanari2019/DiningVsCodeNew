using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew;

namespace DiningVsCodeNew.Controllers;

[ApiController]
[Route("[controller]")]
public class MealtariffController : ControllerBase
{
    MealtariffRepository mealtariffRepository;
    public MealtariffController(MealtariffRepository mealtariffRepository)
    {
        this.mealtariffRepository = mealtariffRepository;
    }
    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult> GetMenuMealtariffs()
    {
        return new OkObjectResult(mealtariffRepository.GetMenuMealtariffs());
    }
    // GET: api/Cities
    [HttpGet("maxtariff")]
    public async Task<ActionResult> GetMenuamdtariffs()
    {
        return new OkObjectResult(mealtariffRepository.GetMenuandtariff());
    }
    // GET: api/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetMenuMealtariffby(int id)
    {
        return new OkObjectResult(mealtariffRepository.GetMenuMealtariffby(id));

    }
    // GET api/mealtariff/maximum
    [HttpPost("maximum/{menuId}")]
    public ActionResult<Mealtariff> GetMenutarrifByMaximumID(int MenuId)
    {
        var maxMealtariff = mealtariffRepository.GetMenutarrifByMaximumID(MenuId);

        if (maxMealtariff == null)
        {
            return NotFound(); // Return 404 Not Found if no matching Mealtariff is found
        }

        return Ok(maxMealtariff);
    }

    // GET api/mealtariff/maximum/{menuId}
    [HttpGet("maximumof/{menuId}")]
    public ActionResult<Mealtariff> GetMenutarriffByMaximumID(int menuid)
    {
        if (menuid == 0)
        {
            return BadRequest("Menu object is required in the request body.");
        }

        var maxMealtariff = mealtariffRepository.GetMenutarriffByMaximumID(menuid);

        if (maxMealtariff == null)
        {
            return NotFound(); // Return 404 Not Found if no matching Mealtariff is found
        }

        return Ok(maxMealtariff);
    }

    // PUT: api/users/5
    // To protect from overposting attacks, see https://go.microsoft.com/
    // fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMenu(int id, [FromBody] Mealtariff mealtariff)
    {
        if (id != mealtariff.Id)
        {
            return BadRequest();
        }
        // _context.Entry(state).State = EntityState.Modified;

        mealtariffRepository.updateMealtariff(mealtariff);
        return Ok("Record updated successfully");

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
    public async Task<ActionResult<Menu>> PostMenu([FromBody] Mealtariff mealtariff)
    {

        if (mealtariff != null)
        {
            mealtariffRepository.insertMealtariff(mealtariff);
        }
        return Ok("Posted succesfully");

    }
    // DELETE: api/Cities/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Menu>> DeleteMenu(int id, [FromBody] Mealtariff mealtariff)
    {


        if (id != mealtariff.Id)
        {
            return NotFound();
        }
        id = mealtariffRepository.deleteMealtariff(mealtariff);
        return Ok("Record Deleted succesfully");
    }
    //private bool StateExists(int id)
    // {
    // return _context.States.Any(e => e.Id == id);
    // }

}