using Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
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

        public ActionResult List()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            DateTime date = DateTime.Now;

            var model = new List<ListViewModel>();

            for(int i=0; i<1000; i++)
            {
                date = date.AddDays(random.Next(3));
                model.Add(new ListViewModel() { Type = random.Next(2), Date = date, Money = random.Next(1,10000) });
            }

            

            return View(model);
        }
    }
}