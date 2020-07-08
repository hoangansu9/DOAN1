using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using doan_1.Models;

namespace doan_1.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
        
            var book = db.Book.Include(b => b.Author).Include(b => b.Category).Include(b => b.Provider).Include(b => b.Publisher);
            return View(book.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Author, "AuthorID", "AuthorName");
            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName");
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "ProviderName");
            ViewBag.PublisherID = new SelectList(db.Publisher, "PublisherID", "PublisherName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.ImageUpLoad != null)
                {
                    string fileNameImg = Path.GetFileNameWithoutExtension(book.ImageUpLoad.FileName);
                    string extension = Path.GetExtension(book.ImageUpLoad.FileName);
                    fileNameImg = fileNameImg + extension;
                    book.Image = "~/Content/Images/" + fileNameImg;
                    book.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileNameImg));
                }
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Author, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName", book.CateID);
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "ProviderName", book.ProviderID);
            ViewBag.PublisherID = new SelectList(db.Publisher, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }
        [Authorize(Roles = "Admin")]
        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Author, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName", book.CateID);
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "ProviderName", book.ProviderID);
            ViewBag.PublisherID = new SelectList(db.Publisher, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,BookName,BookPrice,BookDescription,PublisherDate,Image,AuthorID,PublisherID,ProviderID,CateID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Author, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName", book.CateID);
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "ProviderName", book.ProviderID);
            ViewBag.PublisherID = new SelectList(db.Publisher, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }
        [Authorize(Roles = "Admin")]
        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Book.Find(id);
            db.Book.Remove(book);
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
