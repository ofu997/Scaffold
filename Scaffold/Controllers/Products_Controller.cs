using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scaffold.Models;

namespace Scaffold.Controllers
{
    public class Products_Controller : Controller
    {
        private ScaffoldProductsEntities db = new ScaffoldProductsEntities();

        // GET: Products_
        public ActionResult Index()
        {
            return View(db.Products_.ToList());
        }

        // GET: Products_/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_ products_ = db.Products_.Find(id);
            if (products_ == null)
            {
                return HttpNotFound();
            }

			/*
			var myValue = Request.QueryString["somesuch"];
			var myOtherValue = Request["somesuch"];
			*/

            return View(products_);
        }

        // GET: Products_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Price")] Products_ products_)
        {
            if (ModelState.IsValid)
            {
                products_.ProductId = Guid.NewGuid();
                db.Products_.Add(products_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products_);
        }

        // GET: Products_/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_ products_ = db.Products_.Find(id);
            if (products_ == null)
            {
                return HttpNotFound();
            }
            return View(products_);
        }

        // POST: Products_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Price")] Products_ products_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products_);
        }

        // GET: Products_/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_ products_ = db.Products_.Find(id);
            if (products_ == null)
            {
                return HttpNotFound();
            }
            return View(products_);
        }

        // POST: Products_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Products_ products_ = db.Products_.Find(id);
            db.Products_.Remove(products_);
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
