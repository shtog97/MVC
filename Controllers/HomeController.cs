using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using WebApplication4.Models;
using Microsoft.AspNet.Identity.Owin;
using WebApllication4.Models;
using System.IO;
using System.Collections;

namespace WebApplication4.Controllers
{

    public class HomeController : Controller
    {
        AvtoContext db = new AvtoContext();
        public ActionResult Index()
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return View(roles);
        }
        public ActionResult OnasPage()
        {
            return View();
        }
        public ActionResult Toyota()
        {
            return View();
        }
        public ActionResult Tesla()
        {
            return View();
        }
        public ActionResult Nissan()
        {
            return View();
        }
        public ActionResult Zaz()
        {
            return View();
        }
        public ActionResult Honda()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Credit()
        {
            return View();
        }
        public ActionResult NewAvto()
        {
            return View(db.Avtos);
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }




}




