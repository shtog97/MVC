using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class adminController
    {
        public class HomeController : Controller
        {

            [Authorize(Roles = "admin")]
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }





        }
    }
}