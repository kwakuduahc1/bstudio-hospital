using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Accounts;
using WinClinic.Model;
using WinClinic.Models.ViewModels;

namespace WinClinic.Controllers.Accounts
{
    public class PaymentsController : Controller
    {
        readonly AccountsHelper db;

        public PaymentsController(DbContextOptions<DataContext> options) => db = new AccountsHelper(options);

        [HttpGet]
        public async Task<PaymentsVm> GetPayments(Guid id) => await db.GetPaymentsAsync(id);

        [HttpPost]
        public async Task<IActionResult> Receive([FromBody]PaymentsVm payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.ReceivePayment(payment, User.Identity.Name);
            int results = await db.Save();
            return Accepted();
        }
    }
}