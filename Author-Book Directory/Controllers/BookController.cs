using Author_Book_Directory.EF;
using Author_Book_Directory.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Author_Book_Directory.Controllers
{
    public class BookController : Controller
    {
        AuthorBookDirectoryContext db;

        public BookController(AuthorBookDirectoryContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Books.Include(b => b.Author).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors = db.Authors.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b)
        {
            db.Books.Add(b);
            db.SaveChanges();

            TempData["Msg"] = b.Name + " created successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from b in db.Books where b.Id == id select b).SingleOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Books.Find(id);
            ViewBag.Authors = db.Authors.ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Book b)
        {
            db.Books.Update(b);
            db.SaveChanges();

            TempData["Msg"] = b.Name + " updated successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var data = db.Books.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            string bookName = data.Name;
            db.Books.Remove(data);
            db.SaveChanges();

            TempData["Msg"] = bookName + " deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
