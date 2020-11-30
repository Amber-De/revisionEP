using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class SupportController : Controller
    {
        //this method will be called using a get request and its purpose is to load the page
        public IActionResult Contact()
        {
            return View();
        }

        //this will be used as a post..
        //So how can we have two methods with the same name? We override..therefore it has the same name but different parameters

        //this is an attribute and we are telling mvc that this method will be activated when there is a post request.
        //in order to pass the data to email and query...we have to name them in the Contact.html
        [HttpPost]
        public IActionResult Contact(string email, string query)
        {
            if(string.IsNullOrEmpty(query) || string.IsNullOrEmpty(email))
            {
                TempData["warning"] = "Please fill both boxes for the message to be sent!";
                
            }
            else
            {
                TempData["feedback"] = "Thankyou for your query we will get back to you asap !";
            }
            return View(); 
        }
    }
}
