﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WinClinic.Controllers.Accounts
{
    public class DrugsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}