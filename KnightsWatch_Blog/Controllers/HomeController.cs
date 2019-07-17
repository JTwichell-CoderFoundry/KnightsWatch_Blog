using KnightsWatch_Blog.Models;
using KnightsWatch_Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace KnightsWatch_Blog.Controllers
{
    public class HomeController : Controller
    {
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
        public async Task<ActionResult> Contact(EmailModel email)
        {
            // JasonTwichell@mailinator.com<jasontwichellsr@gmail.com>
            //var from = string.Format("{0}<{1}>", email.FromEmail, WebConfigurationManager.AppSettings["emailto"]);
            var from = $"{email.FromEmail}<{WebConfigurationManager.AppSettings["emailto"]}>";

            var emailMessage = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
            {
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true
            };

            var svc = new PersonalEmail();
            await svc.SendAsync(emailMessage);

            return RedirectToAction("Index");
        }


    }
}