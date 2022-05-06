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
    public class SanphamsController : Controller
    {
        private Mypham db = new Mypham();

        // GET: Admin/Sanphams
        public ActionResult Index()
        {
            var sanphams = db.Sanphams.Include(s => s.Loaisanpham).Include(s => s.Nhacungcap);
            return View(sanphams.ToList());
        }

        // GET: Admin/Sanphams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Create
        public ActionResult Create()
        {
            ViewBag.LoaisanphamID = new SelectList(db.Loaisanphams, "LoaisanphamID", "Tenloaisp");
            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC");
            return View();
        }

        // POST: Admin/Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SanphamID,TeSP,Giacu,Giamoi,Ngaycapnhat,Thanhphan,Mota,Hinhanh,Soluongton,Soluongxem,Soluongmua,NhacungcapID,LoaisanphamID")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Sanphams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaisanphamID = new SelectList(db.Loaisanphams, "LoaisanphamID", "Tenloaisp", sanpham.LoaisanphamID);
            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC", sanpham.NhacungcapID);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaisanphamID = new SelectList(db.Loaisanphams, "LoaisanphamID", "Tenloaisp", sanpham.LoaisanphamID);
            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC", sanpham.NhacungcapID);
            return View(sanpham);
        }

        // POST: Admin/Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SanphamID,TeSP,Giacu,Giamoi,Ngaycapnhat,Thanhphan,Mota,Hinhanh,Soluongton,Soluongxem,Soluongmua,NhacungcapID,LoaisanphamID")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaisanphamID = new SelectList(db.Loaisanphams, "LoaisanphamID", "Tenloaisp", sanpham.LoaisanphamID);
            ViewBag.NhacungcapID = new SelectList(db.Nhacungcaps, "NhacungcapID", "TenNCC", sanpham.NhacungcapID);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: Admin/Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            db.Sanphams.Remove(sanpham);
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
