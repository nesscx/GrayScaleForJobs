using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Puestos_de_Trabajo.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Puestos_de_Trabajo.Controllers
{
    public class PuestoTrabajoesController : Controller
    {
        private PuestosEntities db = new PuestosEntities();

        // GET: PuestoTrabajoes
        public ActionResult Index(String cargo)
        {
            var puestoTrabajo = from s in db.PuestoTrabajo select s;

            if (!String.IsNullOrEmpty(cargo))
    	    {
                puestoTrabajo = puestoTrabajo.Where(j => j.cargo.Contains(cargo));
            }
            return View(puestoTrabajo);
        }
    

        // GET: PuestoTrabajoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuestoTrabajo puestoTrabajo = await db.PuestoTrabajo.FindAsync(id);
            if (puestoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(puestoTrabajo);
        }

        // GET: PuestoTrabajoes/Create
        [Authorize(Roles = "Administrator, Poster")]
        public ActionResult Create()
        {
            PuestoTrabajo puesto = new PuestoTrabajo();
            puesto.estado = "Activo";
            puesto.fecha_Publicacion = DateTime.Now;
            ViewBag.tipo = new SelectList(db.Tipo, "Descripcion", "Descripcion");
            ViewBag.id_Usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "descripcion");
            ViewBag.id_Empresa = new SelectList(db.Empresa, "id", "nombre");
            return View(puesto);
        }

        // POST: PuestoTrabajoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Poster")]
        public async Task<ActionResult> Create([Bind(Include = "id,id_Empresa,id_Usuario,id_Categoria,url,cargo,estado,fecha_Publicacion,tipo,logo,descripcion,publico,dias_trabajo_linea")] PuestoTrabajo puestoTrabajo)
        {
            if (ModelState.IsValid)
            {
                puestoTrabajo.estado = "Activo";
                puestoTrabajo.fecha_Publicacion = DateTime.Now;
                puestoTrabajo.id_Usuario = User.Identity.GetUserId();
                db.PuestoTrabajo.Add(puestoTrabajo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipo = new SelectList(db.Tipo, "Descripcion", "Descripcion", puestoTrabajo.tipo);
            ViewBag.id_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", puestoTrabajo.id_Usuario);
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "descripcion", puestoTrabajo.id_Categoria);
            ViewBag.id_Empresa = new SelectList(db.Empresa, "id", "nombre", puestoTrabajo.id_Empresa);
            return View(puestoTrabajo);
        }

        // GET: PuestoTrabajoes/Edit/5
        [Authorize(Roles = "Administrator, Affilliate")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuestoTrabajo puestoTrabajo = await db.PuestoTrabajo.FindAsync(id);
            if (puestoTrabajo == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo = new SelectList(db.Tipo, "Descripcion", "Descripcion", puestoTrabajo.tipo);
            ViewBag.id_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", puestoTrabajo.id_Usuario);
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "descripcion", puestoTrabajo.id_Categoria);
            ViewBag.id_Empresa = new SelectList(db.Empresa, "id", "nombre", puestoTrabajo.id_Empresa);
            return View(puestoTrabajo);
        }

        // POST: PuestoTrabajoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Affilliate")]
        public async Task<ActionResult> Edit([Bind(Include = "id,id_Empresa,id_Usuario,id_Categoria,url,cargo,estado,fecha_Publicacion,tipo,logo,descripcion,publico,dias_trabajo_linea")] PuestoTrabajo puestoTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puestoTrabajo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipo = new SelectList(db.Tipo, "Descripcion", "Descripcion", puestoTrabajo.tipo);
            ViewBag.id_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", puestoTrabajo.id_Usuario);
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id", "descripcion", puestoTrabajo.id_Categoria);
            ViewBag.id_Empresa = new SelectList(db.Empresa, "id", "nombre", puestoTrabajo.id_Empresa);
            return View(puestoTrabajo);
        }

        // GET: PuestoTrabajoes/Delete/5

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuestoTrabajo puestoTrabajo = await db.PuestoTrabajo.FindAsync(id);
            if (puestoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(puestoTrabajo);
        }

        [Authorize(Roles = "Administrator")]
        // POST: PuestoTrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PuestoTrabajo puestoTrabajo = await db.PuestoTrabajo.FindAsync(id);
            db.PuestoTrabajo.Remove(puestoTrabajo);
            await db.SaveChangesAsync();
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
