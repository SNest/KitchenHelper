using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using KitchenHelperServer.EF;
using KitchenHelperServer.Models;

namespace KitchenHelperServer.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly EfContext db = new EfContext();

        [Authorize(Roles = "Administrator, User")]
        public ActionResult Index()
        {
            ViewBag.CurrentUser = db.Set<UserGroup>().SingleOrDefault(_ => _.Name == User.Identity.Name).Id;
            return View(db.UserGroups.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.UserGroups.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.UserGroups.Add(userGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userGroup);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.UserGroups.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userGroup);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.UserGroups.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.UserGroups.Find(id);
            db.UserGroups.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CurrentUser()
        {
            // ViewBag.CurrentRole = db.Set<User>().SingleOrDefault(_ => _.Login == User.Identity.Name).Role;
            // ViewBag.CurrentFullName = db.Set<User>().SingleOrDefault(_ => _.Login == User.Identity.Name).FullName;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}