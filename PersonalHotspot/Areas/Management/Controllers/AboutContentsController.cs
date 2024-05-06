using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PersonalHotspot.Areas.Management.Data;
using PersonalHotspot.Areas.Management.Models;

namespace PersonalHotspot.Areas.Management.Controllers
{
    [RouteArea("Management")]
    public class AboutContentsController : Controller
    {
        private readonly PersonalHotspotDBContext db = new PersonalHotspotDBContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["CanAccess"].ToString() == "Y")
            {
                base.ViewBag.ResumeProfiles = db.PersonalHotspotResumes.ToList();
                base.OnActionExecuting(filterContext);
            }
            else
            {
                string redirectionUrl = base.Request.Url.Scheme + "://" + base.Request.Url.Authority;
                Redirect(redirectionUrl).ExecuteResult(filterContext);
            }
        }

        public ActionResult Index()
        {
            return View(db.AboutContents.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutContent aboutContent = db.AboutContents.Find(id);
            if (aboutContent == null)
            {
                return HttpNotFound();
            }
            return View(aboutContent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProfileTitle,Technology,Description")] AboutContent aboutContent)
        {
            if (base.ModelState.IsValid)
            {
                aboutContent.Id = Guid.NewGuid();
                aboutContent.YearsOfExperience = DateTime.Now.Year - 2017;
                db.AboutContents.Add(aboutContent);
                PersonalHotspotResume existingPersonalHotspotResume = db.PersonalHotspotResumes.FirstOrDefault();
                if (existingPersonalHotspotResume != null)
                {
                    existingPersonalHotspotResume.AboutContent = aboutContent;
                }
                else
                {
                    existingPersonalHotspotResume = new PersonalHotspotResume();
                    existingPersonalHotspotResume.AboutContent = aboutContent;
                    db.PersonalHotspotResumes.Add(existingPersonalHotspotResume);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutContent);
        }

        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutContent aboutContent = db.AboutContents.Find(id);
            if (aboutContent == null)
            {
                return HttpNotFound();
            }
            return View(aboutContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfileTitle,Technology,Description,YearsOfExperience")] AboutContent aboutContent)
        {
            if (base.ModelState.IsValid)
            {
                db.Entry(aboutContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutContent);
        }

        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutContent aboutContent = db.AboutContents.Find(id);
            if (aboutContent == null)
            {
                return HttpNotFound();
            }
            return View(aboutContent);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AboutContent aboutContent = db.AboutContents.Find(id);
            db.AboutContents.Remove(aboutContent);
            db.SaveChanges();
            return RedirectToAction("Index");
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