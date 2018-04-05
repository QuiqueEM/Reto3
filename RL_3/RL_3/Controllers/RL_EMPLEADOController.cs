using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RL_3.Models;

namespace RL_3.Controllers
{
    public class RL_EMPLEADOController : Controller
    {
        private MVCCHATEntities db = new MVCCHATEntities();

        // GET: RL_EMPLEADO
        public ActionResult Index()
        {
            var rL_EMPLEADO = db.RL_EMPLEADO.Include(r => r.RL_C_CORPORATIVOS).Include(r => r.RL_C_PUESTOS);
            return View(rL_EMPLEADO.ToList());
        }

        // GET: RL_EMPLEADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RL_EMPLEADO rL_EMPLEADO = db.RL_EMPLEADO.Find(id);
            if (rL_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(rL_EMPLEADO);
        }

        // GET: RL_EMPLEADO/Create
        public ActionResult Create()
        {
            ViewBag.CORPORATIVO = new SelectList(db.RL_C_CORPORATIVOS, "ID_CORPORATIVO", "DESC_CORPORATIVO");
            ViewBag.PUESTO = new SelectList(db.RL_C_PUESTOS, "ID_PUESTO", "DESC_PUESTO");
            return View();
        }

        // POST: RL_EMPLEADO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPLEADO,NO_EMPLEADO,NOMBRE,PATERNO,MATERNO,PUESTO,CORPORATIVO")] RL_EMPLEADO rL_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.RL_EMPLEADO.Add(rL_EMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CORPORATIVO = new SelectList(db.RL_C_CORPORATIVOS, "ID_CORPORATIVO", "DESC_CORPORATIVO", rL_EMPLEADO.CORPORATIVO);
            ViewBag.PUESTO = new SelectList(db.RL_C_PUESTOS, "ID_PUESTO", "DESC_PUESTO", rL_EMPLEADO.PUESTO);
            return View(rL_EMPLEADO);
        }

        // GET: RL_EMPLEADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RL_EMPLEADO rL_EMPLEADO = db.RL_EMPLEADO.Find(id);
            if (rL_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CORPORATIVO = new SelectList(db.RL_C_CORPORATIVOS, "ID_CORPORATIVO", "DESC_CORPORATIVO", rL_EMPLEADO.CORPORATIVO);
            ViewBag.PUESTO = new SelectList(db.RL_C_PUESTOS, "ID_PUESTO", "DESC_PUESTO", rL_EMPLEADO.PUESTO);
            return View(rL_EMPLEADO);
        }

        // POST: RL_EMPLEADO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPLEADO,NO_EMPLEADO,NOMBRE,PATERNO,MATERNO,PUESTO,CORPORATIVO")] RL_EMPLEADO rL_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rL_EMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CORPORATIVO = new SelectList(db.RL_C_CORPORATIVOS, "ID_CORPORATIVO", "DESC_CORPORATIVO", rL_EMPLEADO.CORPORATIVO);
            ViewBag.PUESTO = new SelectList(db.RL_C_PUESTOS, "ID_PUESTO", "DESC_PUESTO", rL_EMPLEADO.PUESTO);
            return View(rL_EMPLEADO);
        }

        // GET: RL_EMPLEADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RL_EMPLEADO rL_EMPLEADO = db.RL_EMPLEADO.Find(id);
            if (rL_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(rL_EMPLEADO);
        }

        // POST: RL_EMPLEADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RL_EMPLEADO rL_EMPLEADO = db.RL_EMPLEADO.Find(id);
            db.RL_EMPLEADO.Remove(rL_EMPLEADO);
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
