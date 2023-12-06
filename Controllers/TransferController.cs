using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DiningVsCodeNew.Models; // Import your model
using DiningVsCodeNew;
using Microsoft.AspNetCore.Cors; // Import your repository

namespace DiningVsCodeNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyAllowSpecificOrigins")]
    public class TransferController : ControllerBase
    {
        private readonly TransferRepository transferRepo;
        private readonly PaymentMainRepository paymentMainRepo;

        public TransferController(TransferRepository transferRepo, PaymentMainRepository paymentMainRepo)
        {
            this.transferRepo = transferRepo;
            this.paymentMainRepo = paymentMainRepo;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<Transfer>> GetAllTransfers()
        // {
        //     var transfers = transferRepo.GetAllTransfers();
        //     return Ok(transfers);
        // }

        // [HttpPost]
        public IActionResult InsertTransfer([FromBody] Transfer transfer)
        {
            // Perform validation or other logic here if needed
            transfer.DateTransferred = DateTime.Now;
            transferRepo.InsertTransfer(transfer);
            return Ok(transfer);
        }

        [HttpPost("update")]
        public IActionResult UpdateTransfer([FromBody] Transfer transfer)
        {
            // Your validation or logic here

            transferRepo.UpdateTransfer(transfer);
            return Ok(transfer);
        }

        // [HttpPost("delete")]
        // public IActionResult DeleteTransfer([FromBody] Transfer transfer)
        // {
        //     int deletedId = transferRepo.DeleteTransfer(transfer);
        //     return Ok(deletedId);
        // }

        // // Other custom actions as needed
        // [HttpPost("completeTransaction")]
        // public IActionResult CompleteTransaction([FromBody] TransferTransaction transactionModel)
        // {
        //     try
        //     {
        //         // Extract the relevant data from the transaction model
        //         PaymentMain updatedPaymentMain = transactionModel.UpdatedPaymentMainData;
        //         PaymentMain newPaymentMain = transactionModel.PaymentMainData;
        //         Transfer newTransfer = transactionModel.TransferData;

        //         // Call the transaction service to complete the transaction
        //         // var transactionService = new TransactionService(paymentMainRepo, transferRepo);
        //         transferRepo.CompleteTransaction(updatedPaymentMain, newPaymentMain, newTransfer);

        //         return Ok("newTransfer");
        //     }
        //     catch (Exception ex)
        //     {
        //         // Handle and log exceptions
        //         return StatusCode(500, "Transaction failed: " + ex.Message);
        //     }
        // }


        [HttpPost("completeTransaction2")]
        public IActionResult CompleteTransaction2([FromBody] TransferTransaction transferTransaction)
        {
            try
            {
                transferRepo.CompleteTransaction2(transferTransaction.UpdatedPaymentMainData, transferTransaction.PaymentMainData, transferTransaction.TransferData);
                return Ok(transferTransaction);
            }
            catch (Exception ex)
            {
                // Handle errors and return an error response
                return BadRequest($"Transaction failed: {ex.Message}");
            }
        }


    }



}


