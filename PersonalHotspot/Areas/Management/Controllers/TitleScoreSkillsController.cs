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
    public class TitleScoreSkillsController : Controller
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
            return View(db.TitleScoreSkills.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleScoreSkill titleScoreSkill = db.TitleScoreSkills.Find(id);
            if (titleScoreSkill == null)
            {
                return HttpNotFound();
            }
            return View(titleScoreSkill);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Score,Title")] TitleScoreSkill titleScoreSkill)
        {
            if (base.ModelState.IsValid)
            {
                titleScoreSkill.Id = Guid.NewGuid();
                db.TitleScoreSkills.Add(titleScoreSkill);
                PersonalHotspotResume existingPersonalHotspotResume = db.PersonalHotspotResumes.FirstOrDefault();
                if (existingPersonalHotspotResume != null)
                {
                    existingPersonalHotspotResume.TitleScoreSkills.Add(titleScoreSkill);
                }
                else
                {
                    existingPersonalHotspotResume = new PersonalHotspotResume();
                    existingPersonalHotspotResume.TitleScoreSkills.Add(titleScoreSkill);
                    db.PersonalHotspotResumes.Add(existingPersonalHotspotResume);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titleScoreSkill);
        }

        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleScoreSkill titleScoreSkill = db.TitleScoreSkills.Find(id);
            if (titleScoreSkill == null)
            {
                return HttpNotFound();
            }
            return View(titleScoreSkill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Score,Title")] TitleScoreSkill titleScoreSkill)
        {
            if (base.ModelState.IsValid)
            {
                db.Entry(titleScoreSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titleScoreSkill);
        }

        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleScoreSkill titleScoreSkill = db.TitleScoreSkills.Find(id);
            if (titleScoreSkill == null)
            {
                return HttpNotFound();
            }
            return View(titleScoreSkill);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TitleScoreSkill titleScoreSkill = db.TitleScoreSkills.Find(id);
            db.TitleScoreSkills.Remove(titleScoreSkill);
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