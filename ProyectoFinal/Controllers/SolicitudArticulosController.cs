using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class SolicitudArticulosController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: SolicitudArticulos
        public ActionResult Index()
        {
            return View(db.SolicitudArticulos.ToList());
        }

        // GET: SolicitudArticulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudArticulo solicitudArticulo = db.SolicitudArticulos.Find(id);
            if (solicitudArticulo == null)
            {
                return HttpNotFound();
            }
            return View(solicitudArticulo);
        }

        // GET: SolicitudArticulos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitudArticulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Empleado,FechaSolicitud,Articulo,Cantidad,UnidadMedida,Estado")] SolicitudArticulo solicitudArticulo)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudArticulos.Add(solicitudArticulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solicitudArticulo);
        }

        // GET: SolicitudArticulos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudArticulo solicitudArticulo = db.SolicitudArticulos.Find(id);
            if (solicitudArticulo == null)
            {
                return HttpNotFound();
            }
            return View(solicitudArticulo);
        }

        // POST: SolicitudArticulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Empleado,FechaSolicitud,Articulo,Cantidad,UnidadMedida,Estado")] SolicitudArticulo solicitudArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudArticulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitudArticulo);
        }

        // GET: SolicitudArticulos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudArticulo solicitudArticulo = db.SolicitudArticulos.Find(id);
            if (solicitudArticulo == null)
            {
                return HttpNotFound();
            }
            return View(solicitudArticulo);
        }

        // POST: SolicitudArticulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudArticulo solicitudArticulo = db.SolicitudArticulos.Find(id);
            db.SolicitudArticulos.Remove(solicitudArticulo);
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
