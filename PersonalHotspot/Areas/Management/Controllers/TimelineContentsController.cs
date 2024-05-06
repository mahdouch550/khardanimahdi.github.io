using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalHotspot.Areas.Management.Data;
using PersonalHotspot.Areas.Management.Models;

namespace PersonalHotspot.Areas.Management.Controllers
{
    [RouteArea("Management")]
    public class TimelineContentsController : Controller
    {
        private PersonalHotspotDBContext db = new PersonalHotspotDBContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie canAccessCookie = base.Request.Cookies["CanAccess"];
            if (canAccessCookie != null && canAccessCookie.Value.Equals("Y"))
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
            return View(db.TimelineContents.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimelineContent timelineContent = db.TimelineContents.Find(id);
            if (timelineContent == null)
            {
                return HttpNotFound();
            }
            return View(timelineContent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Month,Title,Subtitle,Paragraph")] TimelineContent timelineContent)
        {
            if (base.ModelState.IsValid)
            {
                timelineContent.Id = Guid.NewGuid();
                db.TimelineContents.Add(timelineContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timelineContent);
        }

        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimelineContent timelineContent = db.TimelineContents.Find(id);
            if (timelineContent == null)
            {
                return HttpNotFound();
            }
            return View(timelineContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Month,Title,Subtitle,Paragraph")] TimelineContent timelineContent)
        {
            if (base.ModelState.IsValid)
            {
                db.Entry(timelineContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timelineContent);
        }

        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimelineContent timelineContent = db.TimelineContents.Find(id);
            if (timelineContent == null)
            {
                return HttpNotFound();
            }
            return View(timelineContent);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TimelineContent timelineContent = db.TimelineContents.Find(id);
            db.TimelineContents.Remove(timelineContent);
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