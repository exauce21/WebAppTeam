using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPWebGroupe.Models;

namespace TPWebGroupe.Controllers
{
    public class ProduitsController : Controller
    {
        private dbTpUtilisateurContext db = new dbTpUtilisateurContext();

        // GET: Produits
        public ActionResult Index()
        {
            var produits = db.produits.Include(p => p.Categorie);
            return View(produits.ToList());
        }

        // GET: Produits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produits/Create
        public ActionResult Create()
        {
            ViewBag.idCategorie = new SelectList(db.categories, "IdCategorie", "libelleCategorie");
            return View();
        }

        // POST: Produits/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduit,Designation,PU,QteStock,QteMin,DatePeremption,idCategorie")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.produits.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategorie = new SelectList(db.categories, "IdCategorie", "libelleCategorie", produit.idCategorie);
            return View(produit);
        }

        // GET: Produits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategorie = new SelectList(db.categories, "IdCategorie", "libelleCategorie", produit.idCategorie);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduit,Designation,PU,QteStock,QteMin,DatePeremption,idCategorie")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategorie = new SelectList(db.categories, "IdCategorie", "libelleCategorie", produit.idCategorie);
            return View(produit);
        }

        // GET: Produits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produit produit = db.produits.Find(id);
            db.produits.Remove(produit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public DataTable GetTableProduit()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Designation", typeof(string));
            table.Columns.Add("PU", typeof(int));
            table.Columns.Add("QteStock", typeof(double));
            table.Columns.Add("QteMin", typeof(double));
            table.Columns.Add("DatePeremption", typeof(DateTime));
            var liste = db.produits.ToList();

            foreach (var i in liste)
            {
                table.Rows.Add(i.DatePeremption, i.PU, i.QteStock, i.QteMin, i.DatePeremption);
            }

            return table;
        }

        public ActionResult ImprimerListeProduit()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {
                rpt.Load(Server.MapPath("~/Report/rptListeProduit.rpt"));
                rpt.SetDataSource(GetTableProduit());
                Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.AppendHeader("Content-Disposition", "inline");
                return File(stream, "application/pdf");
            }
            finally
            {
                rpt.Dispose();
                rpt.Close();
            }
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
