using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
