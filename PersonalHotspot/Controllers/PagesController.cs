using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using PersonalHotspot.Areas.Management.Data;
using PersonalHotspot.Areas.Management.Models;
using PersonalHotspot.Services;

public class PagesController : Controller
{
    private readonly PersonalHotspotDBContext context;

    public PagesController()
    {
        context = new PersonalHotspotDBContext();
    }

    public new ActionResult Profile()
    {
        PersonalHotspotResume personalHotspotResume = context.PersonalHotspotResumes.FirstOrDefault();
        return View(personalHotspotResume);
    }

    [HttpPost]
    public bool SendMail(ContactMessage contactMessage)
    {
        string ipAddress = base.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
        if (base.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            ipAddress = base.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
        string address = Services.IpToAddress(ipAddress);
        DateTime now = DateTime.Now;
        contactMessage.IpAddress = ipAddress;
        contactMessage.IpAddressLocation = address;
        contactMessage.Timestamp = now;
        context.ContactMessages.Add(contactMessage);
        context.SaveChanges();
        return Services.SendMail(contactMessage);
    }
}