using System;
using System.Web.Mvc;
using KitchenHelperServer.EF;
using KitchenHelperServer.Models;

namespace KitchenHelperServer.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private readonly EfContext _context = new EfContext();

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserGroup model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AppToken = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(10, 6);
                    _context.UserGroups.Add(model);
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
            }

            return View(model);
        }
    }
}