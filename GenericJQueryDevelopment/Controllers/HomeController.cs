using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GenericJQueryDevelopment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.methodUrl = "home/SendList";
            ViewBag.Error = "An error accured";
            ViewBag.Empty = "No data found";
            return View();
        }

        [HttpPost]
        public JsonResult SendList(PersonModel n)
        {
            if (n != null && !string.IsNullOrWhiteSpace(n.Name))
            {
                // get from DB 

                string result = string.Empty;
                var rr = new JavaScriptSerializer().Deserialize<string[]>("[\"omid\",\"arthur\",\"arthur2\",\"cécile\"]");

                rr = rr.Where(k => k.ToLower().Contains(n.Name.ToLower())).ToArray();
                if (rr == null || !rr.Any())
                {
                    return Json("No data found");
                }
                return Json(rr);
            }

            return Json("An error accured");
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
    }

    public class PersonModel
    {
        public string Name { get; set; }
    }
}