using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalHotspot.Areas.Management.Data;
using PersonalHotspot.Areas.Management.Models;

namespace PersonalHotspot.Areas.Management.Controllers
{
    [RouteArea("Management")]
    public class HomeContentsController : Controller
    {
        private readonly PersonalHotspotDBContext db = new();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["CanAccess"].ToString() == "Y")
            {
                base.ViewBag.ResumeProfiles = db.PersonalHotspotResumes.ToList();
                base.OnActionExecuting(filterContext);
            }
            else
            {
                string redirectionUrl = Request.Url.Scheme + "://" + Request.Url.Authority;
                Redirect(redirectionUrl).ExecuteResult(filterContext);
            }
        }

        public ActionResult Index()
        {
            return View(db.HomeContents.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeContent homeContent = db.HomeContents.Find(id);
            if (homeContent == null)
            {
                return HttpNotFound();
            }
            return View(homeContent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeContent homeContent, HttpPostedFileBase image)
        {
            if (ModelState.IsValid && image != null)
            {
                homeContent.ImageFileName = image.FileName;
                using (BinaryReader binaryReader = new BinaryReader(image.InputStream))
                {
                    homeContent.ImageByteArray = binaryReader.ReadBytes(image.ContentLength);
                }
                homeContent.Id = Guid.NewGuid();
                db.HomeContents.Add(homeContent);
                PersonalHotspotResume existingPersonalHotspotResume = db.PersonalHotspotResumes.FirstOrDefault();
                if (existingPersonalHotspotResume != null)
                {
                    existingPersonalHotspotResume.HomeContent = homeContent;
                }
                else
                {
                    existingPersonalHotspotResume = new PersonalHotspotResume();
                    existingPersonalHotspotResume.HomeContent = homeContent;
                    db.PersonalHotspotResumes.Add(existingPersonalHotspotResume);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeContent);
        }

        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeContent homeContent = db.HomeContents.Find(id);
            if (homeContent == null)
            {
                return HttpNotFound();
            }
            return View(homeContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HomeContent homeContent, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    homeContent.ImageFileName = image.FileName;
                    using BinaryReader binaryReader = new BinaryReader(image.InputStream);
                    homeContent.ImageByteArray = binaryReader.ReadBytes(image.ContentLength);
                }
                else
                {
                    HomeContent exisitingHomeContent = db.HomeContents.Find(homeContent.Id);
                    homeContent.ImageByteArray = exisitingHomeContent.ImageByteArray;
                    homeContent.ImageFileName = exisitingHomeContent.ImageFileName;
                }
                db.HomeContents.AddOrUpdate(homeContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeContent);
        }

        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeContent homeContent = db.HomeContents.Find(id);
            if (homeContent == null)
            {
                return HttpNotFound();
            }
            return View(homeContent);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            HomeContent homeContent = db.HomeContents.Find(id);
            db.HomeContents.Remove(homeContent);
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