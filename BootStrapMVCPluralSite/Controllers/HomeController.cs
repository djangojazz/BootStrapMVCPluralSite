﻿using BootStrapMVCPluralSite.Models;
using BootStrapMVCPluralSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapMVCPluralSite.Controllers
{
  public class HomeController : Controller
  {
    private IMailService _mail;

    public HomeController(IMailService mail)
    {
      _mail = mail;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    [HttpPost]
    public ActionResult Contact(ContactModel model)
    {
      var msg = string.Format($"Comment From: {model.Name}{Environment.NewLine}Email:{model.Email}{Environment.NewLine}Website:{model.Website}{Environment.NewLine}Comment:{model.Comment}{Environment.NewLine}");
      
      if (_mail.SendMail("noreply@yourdomain.com", "foo@yourdomain.com", "Website Contact", msg))
      {
        ViewBag.MailSent = true;
      }

      return View();
    }

    [Authorize]
    public ActionResult MyMessages()
    {
      return View();
    }
  }
}