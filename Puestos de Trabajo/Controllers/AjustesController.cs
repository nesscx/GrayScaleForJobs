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

namespace Puestos_de_Trabajo.Controllers
{
    public class AjustesController : Controller
    {
        private PuestosEntities db = new PuestosEntities();

        // GET: Ajustes
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Ajustes.ToListAsync());
        }

        // GET: Ajustes/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ajustes ajustes = await db.Ajustes.FindAsync(id);
            if (ajustes == null)
            {
                return HttpNotFound();
            }
            return View(ajustes);
        }

        // GET: Ajustes/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ajustes ajustes = await db.Ajustes.FindAsync(id);
            if (ajustes == null)
            {
                return HttpNotFound();
            }
            return View(ajustes);
        }

        // POST: Ajustes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idioma,max_puestos")] Ajustes ajustes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ajustes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ajustes);
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
