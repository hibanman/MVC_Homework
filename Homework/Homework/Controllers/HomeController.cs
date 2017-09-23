using Homework.Models;
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
        DbModel db = new DbModel();

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
            var accounts = db.AccountBook.ToList().OrderBy(d=>d.Dateee);
            var model = new List<ListViewModel>();

            foreach (var account in accounts)
            {
                model.Add(new ListViewModel() {
                    Type = account.Categoryyy,
                    Date = account.Dateee,
                    Money = account.Amounttt });
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk")] AccountBook book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                book.Dateee = DateTime.Now;
                db.AccountBook.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}