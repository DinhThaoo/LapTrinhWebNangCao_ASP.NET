using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMypham.Areas.Admin.Context;
using WebMypham.Areas.Admin.Model;

namespace WebMypham.Areas.Admin.Controllers
{
    public class PhieunhapsController : Controller
    {
        private Mypham db = new Mypham();

        // GET: Admin/Phieunhaps
        public ActionResult Index()
        {
            var phieunhaps = db.Phieunhaps.Include(p => p.Nhacungcap);
            return View(phieunhaps.ToList());
        }

        // GET: Admin/Phieunhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieunhap phieunhap = db.Phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // GET: Admin/Phieunhaps/Create
        public ActionResult Create()
        {
            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC");
            return View();
        }

        // POST: Admin/Phieunhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhieunhapID,NhacungcapID,Ngaynhap,Daxoa")] Phieunhap phieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Phieunhaps.Add(phieunhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC", phieunhap.NhacungcapID);
            return View(phieunhap);
        }

        // GET: Admin/Phieunhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieunhap phieunhap = db.Phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC", phieunhap.NhacungcapID);
            return View(phieunhap);
        }

        // POST: Admin/Phieunhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhieunhapID,NhacungcapID,Ngaynhap,Daxoa")] Phieunhap phieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieunhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC", phieunhap.NhacungcapID);
            return View(phieunhap);
        }

        // GET: Admin/Phieunhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieunhap phieunhap = db.Phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // POST: Admin/Phieunhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phieunhap phieunhap = db.Phieunhaps.Find(id);
            db.Phieunhaps.Remove(phieunhap);
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
