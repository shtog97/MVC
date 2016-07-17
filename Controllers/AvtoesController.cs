using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApllication4.Models;

namespace WebApplication4.Controllers
{
    public class AvtoesController : Controller
    {
        private AvtoContext db = new AvtoContext();
        [Authorize(Roles = "admin")]
        // GET: Avtoes
        public ActionResult Index()
        {
            return View(db.Avtos.ToList());
        }

        // GET: Avtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avto avto = db.Avtos.Find(id);
            if (avto == null)
            {
                return HttpNotFound();
            }
            return View(avto);
        }

        // GET: Avtoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avtoes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "Id,Name,dataVipuska,ImagePath,opisanie,price")]Avto avto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                List<string> extensions = new List<string>() { ".jpg", ".png" };
                if (extensions.Contains(extension))
                {
                    file.SaveAs(Server.MapPath("/Image/" + fileName));
                    ViewBag.Message = "Файл сохранен";
                }
                else
                {
                    ViewBag.Message = "Ошибка расширения файлов ";
                }

                avto.ImagePath = "/Image/" + fileName;
                db.Avtos.Add(avto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avto);
        }

        // GET: Avtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avto avto = db.Avtos.Find(id);
            if (avto == null)
            {
                return HttpNotFound();
            }
            return View(avto);
        }

        // POST: Avtoes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,dataVipuska,ImagePath,opisanie,price")] Avto avto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avto);
        }

        // GET: Avtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avto avto = db.Avtos.Find(id);
            if (avto == null)
            {
                return HttpNotFound();
            }
            return View(avto);
        }

        // POST: Avtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avto avto = db.Avtos.Find(id);
            db.Avtos.Remove(avto);
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
