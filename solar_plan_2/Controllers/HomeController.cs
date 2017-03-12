using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
namespace solar_plan_2.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
           
            return View(db.Events.ToList());
        }
        public ActionResult Added()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Added(Events obj)
        {

            if (obj.End_Date < obj.Start_Date) { ModelState.AddModelError("End_Date", "Дата начала не может быть позже даты окончания события"); }
            if (obj.End_Date < obj.Start_Date) { ModelState.AddModelError("Start_Date", "Дата начала не может быть позже даты окончания события"); }
            if (ModelState.IsValid )
            {
                db.Events.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Added");
            }
            return View();
        }
        public ActionResult Edit(int? id = 1)
        {
            ViewBag.id = id;
           
            Events f = db.Events.Find(id);
            if (f == null)
            {
                return HttpNotFound();
            }
            return View(f);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Events obj)
        {
            if (obj.End_Date < obj.Start_Date) { ModelState.AddModelError("End_Date", "Дата начала не может быть позже даты окончания события"); }
            if (obj.End_Date < obj.Start_Date) { ModelState.AddModelError("Start_Date", "Дата начала не может быть позже даты окончания события"); }
           

                if (ModelState.IsValid)
            {
               
                UpdateModel(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        [HttpGet]
        public ActionResult Details(int? id = 1)
        {
            var l_id = db.Events.FirstOrDefault(p => p.ID == id);
            
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events obj =  db.Events.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(l_id);
        }
        public  ActionResult Delete(int? id = 1)
        {
            Events obj =  db.Events.Find(id);
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (obj == null)
            {
                return HttpNotFound();
            }


            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult DeleteConfirmed(int id = 1)
        {
            Events f =  db.Events.Find(id);
            db.Events.Remove(f);
            db.SaveChanges();
            ViewBag.Message = "Запись удалена";
            return RedirectToAction("Index");
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
}