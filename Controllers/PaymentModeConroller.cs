using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew;

namespace DiningVsCodeNew.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentModeController : ControllerBase
{
        PaymentModeRepository repPymtMode;
        public PaymentModeController(PaymentModeRepository repPymtMode)
        {
            this.repPymtMode=repPymtMode;
        }
        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult> GetPaymentModes()
        {
             return new OkObjectResult(repPymtMode.GetPaymentModes());
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPymtMode(int id, PaymentMode pymtMode)
        {
            if (id != pymtMode.Id)
            {
                return BadRequest();
            }
           // _context.Entry(state).State = EntityState.Modified;
           
                repPymtMode.updatePaymentMode(pymtMode);
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
        public async Task<ActionResult<PaymentMode>> PostPymtMode(PaymentMode pymtMode)
        {
           
            if (pymtMode!=null)
            {
                repPymtMode.insertPaymentMode(pymtMode);
            }
            return Ok("Posted succesfully");
            
        }
        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentMode>> DeletePymtMode(int id,PaymentMode pymtmode)  
            {
              
              
                if (id != pymtmode.Id)
                 {
                 return NotFound();
                }
                 id= repPymtMode.deletePaymentMode(pymtmode);
                return Ok("Record Deleted succesfully");
            }
        //private bool StateExists(int id)
       // {
           // return _context.States.Any(e => e.Id == id);
       // }

}