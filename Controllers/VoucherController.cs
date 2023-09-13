using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew;

namespace DiningVsCodeNew.Controllers;

[ApiController]
[Route("[controller]")]
public class VoucherController : ControllerBase
{
    VoucherRepository RepVoucher;
    public VoucherController(VoucherRepository repVoucher)
    {
        this.RepVoucher = repVoucher;
    }
    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult> GetVouchers()
    {
        return new OkObjectResult(RepVoucher.GetPymtVouchers());
    }
    // GET: api/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetVoucher(int id)
    {
        return new OkObjectResult(RepVoucher.GetVouchers(id));

    }
    // PUT: api/users/5
    // To protect from overposting attacks, see https://go.microsoft.com/
    // fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVoucher(int id, Voucher voucher)
    {
        if (id != voucher.Id)
        {
            return BadRequest();
        }
        // _context.Entry(state).State = EntityState.Modified;

        RepVoucher.updateVoucher(voucher);
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
    public async Task<ActionResult<Voucher>> PostVoucher(Voucher voucher)
    {

        if (voucher != null)
        {
            RepVoucher.insertVoucher(voucher);
        }
        return Ok(voucher);

    }

    // DELETE: api/Cities/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Voucher>> DeleteVoucher(int id, Voucher voucher)
    {


        if (id != voucher.Id)
        {
            return NotFound();
        }
        id = RepVoucher.deleteVoucher(voucher);
        return Ok("Record Deleted succesfully");
    }
    //private bool StateExists(int id)
    // {
    // return _context.States.Any(e => e.Id == id);
    // }

}