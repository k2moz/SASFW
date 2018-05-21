using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SASFW.Controllers
{
    public class PortfolioController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PortfolioItem(string itemId)
        {
            return View();
        }
    }
}