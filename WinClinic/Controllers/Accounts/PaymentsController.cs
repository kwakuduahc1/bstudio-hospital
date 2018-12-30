using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}