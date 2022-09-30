using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaUBS.API.Controllers
{
    public class VacinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
