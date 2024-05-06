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
    public class TitleDescriptionSkillsController : Controller
    {
        private PersonalHotspotDBContext db = new PersonalHotspotDBContext();

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
            return View(db.TitleDescriptionSkills.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleDescriptionSkill titleDescriptionSkill = db.TitleDescriptionSkills.Find(id);
            if (titleDescriptionSkill == null)
            {
                return HttpNotFound();
            }
            return View(titleDescriptionSkill);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Title")] TitleDescriptionSkill titleDescriptionSkill)
        {
            if (base.ModelState.IsValid)
            {
                titleDescriptionSkill.Id = Guid.NewGuid();
                db.TitleDescriptionSkills.Add(titleDescriptionSkill);
                PersonalHotspotResume existingPersonalHotspotResume = db.PersonalHotspotResumes.FirstOrDefault();
                if (existingPersonalHotspotResume != null)
                {
                    existingPersonalHotspotResume.TitleDescriptionSkills.Add(titleDescriptionSkill);
                }
                else
                {
                    existingPersonalHotspotResume = new PersonalHotspotResume();
                    existingPersonalHotspotResume.TitleDescriptionSkills.Add(titleDescriptionSkill);
                    db.PersonalHotspotResumes.Add(existingPersonalHotspotResume);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titleDescriptionSkill);
        }

        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleDescriptionSkill titleDescriptionSkill = db.TitleDescriptionSkills.Find(id);
            if (titleDescriptionSkill == null)
            {
                return HttpNotFound();
            }
            return View(titleDescriptionSkill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Title")] TitleDescriptionSkill titleDescriptionSkill)
        {
            if (base.ModelState.IsValid)
            {
                db.Entry(titleDescriptionSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titleDescriptionSkill);
        }

        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleDescriptionSkill titleDescriptionSkill = db.TitleDescriptionSkills.Find(id);
            if (titleDescriptionSkill == null)
            {
                return HttpNotFound();
            }
            return View(titleDescriptionSkill);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TitleDescriptionSkill titleDescriptionSkill = db.TitleDescriptionSkills.Find(id);
            db.TitleDescriptionSkills.Remove(titleDescriptionSkill);
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