using Microsoft.AspNetCore.Mvc;
using DiningVsCodeNew;
using System.Text.Unicode;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using DiningVsCodeNew.Models;

namespace DiningVsCodeNew.Controllers;

[ApiController]
[Route("[controller]")]
public class WebhookController : ControllerBase
{

    PaymentMainRepository _reppymtMain;
    UserRepository _userrep;
    PaymentDetailsRepository _repPayDetails;
    OnlinePaymentRepository _reponlinePayment;
    OrderedMealRepository _ordMeal;


    int idvalue = 0;
    public WebhookController(PaymentMainRepository reppymtMain, UserRepository userrep, PaymentDetailsRepository repPayDetails, OnlinePaymentRepository reponlinePayment, OrderedMealRepository omeal)
    {
        this._reppymtMain = reppymtMain;
        this._userrep = userrep;
        this._repPayDetails = repPayDetails;
        this._reponlinePayment = reponlinePayment;
        this._ordMeal = omeal;

    }
    // GET: api/Cities
    [HttpPost]
    public async Task<IActionResult> PostTransaction([FromBody] Transaction payload)
    {
        string key = "sk_test_c35634b6a8685736ba950f5dbb0492ebeb4257f9";
        Transaction trans = payload;
        string retvalue = "500";
        if (trans.@event == "charge.success")
        {
<<<<<<< HEAD

            User us = _userrep.GetUser(trans.data.customer.email);
            if (us != null && trans.data.metadata.voucherId != 10)
            {
                List<PaymentDetails> pyds = new List<PaymentDetails>();
                float totalAmt = 0;
                pyds = _repPayDetails.GetPymtDetails(us.id);
                if (pyds != null)
                {
                    foreach (PaymentDetails pyd in pyds)
                    {
                        PaymentMain pytMain = new PaymentMain();
                        pytMain.Amount = pyd.amount;
                        pytMain.CustCode = pyd.custCode;
                        pytMain.DateEntered = pyd.dateEntered;
                        pytMain.EnteredBy = pyd.enteredBy;
                        pytMain.Id = pyd.id;
                        pytMain.Paymentmodeid = pyd.paymentmodeid;
                        pytMain.Unit = pyd.unit;
                        pytMain.VoucherId = pyd.voucherid;
                        pytMain.ServedBy = "";
                        pytMain.opaymentid = 1111;
                        pytMain.Paid = true;
                        pytMain.timepaid = pyd.dateEntered;
                        pytMain.PaymentType = 0;
                        pytMain.CustTypeiD = pyd.custtypeid;
                        pytMain.VoucherDescription = "";
                        pytMain.DateServed = DateTime.Now;
                        totalAmt = pyd.amount;
                        _reppymtMain.updatePaymentMain(pytMain);
                    }
                    OnlinePayment opaymt = new OnlinePayment();
                    opaymt.AmountPaid = totalAmt;
                    opaymt.Paidby = int.Parse(pyds[0].enteredBy);
                    opaymt.TransRefNo = trans.data.reference;
                    opaymt.TransDate = DateTime.Now;
                    int opaymtid = _reponlinePayment.insertOnlinePayment(opaymt);
                    foreach (PaymentDetails pyd in pyds)
                    {
                        _reppymtMain.updatePaymentMainbyid(opaymtid, pyd.id);
                    }
                }
                retvalue = "200";
            }
            else if (us != null && trans.data.metadata.voucherId == 10)
            {
                List<PaymentDetails> pyds = new List<PaymentDetails>();
                List<OrderedMeal> omeals = new List<OrderedMeal>();
                float totalAmt = 0;
                pyds = _repPayDetails.GetPymtDetails(us.id);
                omeals = _ordMeal.GetOrderedMealsbyCust(us);
                if (omeals.Count > 0)
                {
                    float omealsamount = 0;
                    foreach (OrderedMeal omeal in omeals)
                    {
                        omealsamount = omeal.Amount;
                    }
                    OnlinePayment opaymt = new OnlinePayment();
                    opaymt.AmountPaid = totalAmt;
                    opaymt.Paidby = us.id;
                    opaymt.TransRefNo = trans.data.reference;
                    opaymt.TransDate = DateTime.Now;
                    int opaymtid = _reponlinePayment.insertOnlinePayment(opaymt);
                    int opymtid = 0;
                    PaymentMain pytMain = new PaymentMain();
                    pytMain.Amount = omealsamount;
                    pytMain.CustCode = us.custId;
                    pytMain.DateEntered = DateTime.Now;
                    pytMain.EnteredBy = us.id.ToString();
                    pytMain.Paymentmodeid = 3;
                    pytMain.Unit = 1;
                    pytMain.VoucherId = 10;
                    pytMain.ServedBy = "";
                    pytMain.opaymentid = opaymtid;
                    pytMain.Paid = true;
                    pytMain.timepaid = DateTime.Now;
                    pytMain.PaymentType = 1;
                    pytMain.CustTypeiD = us.custTypeId;
                    pytMain.opaymentid = opaymtid;
                    pytMain.DateServed = DateTime.Now;
                    opymtid = _reppymtMain.insertPaymentMain(pytMain);
                    foreach (OrderedMeal omeal in omeals)
                    {
                        omeal.Submitted = true;
                        omeal.paymentMainId = opymtid;
                    }
                }
                retvalue = "200";

            }
        }
        return Ok(retvalue);
    }



=======
            this._repCustRoute=repCustRoute;
        }
        // GET: api/Cities
        [HttpPost]
        public async Task<ActionResult<string>> PostTransaction([FromBody] Transaction payload)
        {
        //     string key="sk_test_c35634b6a8685736ba950f5dbb0492ebeb4257f9";
        //     string jsonInput = payload; //the json input
        //     string inputString = Convert.ToString(new JValue(jsonInput));
           String result = "";
        //     byte[] secretkeyBytes = System.Text.Encoding.UTF8.GetBytes(key);
        //     byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
        //     using (var hmac = new HMACSHA512(secretkeyBytes))
        //     {
        //         byte[] hashValue = hmac.ComputeHash(inputBytes);
        //         result = BitConverter.ToString(hashValue).Replace("-", string.Empty);;
        //     }
        //       String xpaystackSignature = ""; //put in the request's header value for x-paystack-signature
        //       //hash == req.headers['x-paystack-signature']
        //       string signature = Request.Headers["SIGNATURE"];
        //       if(result.ToLower().Equals(xpaystackSignature)) {
        //   // you can trust the event, it came from paystack
        //   // respond with the http 200 response immediately before attempting to process the response
        //   //retrieve the request body, and deliver value to the customer
        //     } 
        //      else {
        //          // this isn't from Paystack, ignore it
        //           }
            return result;
         }
        
      
       
>>>>>>> 7a97e75b7c41694e461d645fff86dfcc33382717
}