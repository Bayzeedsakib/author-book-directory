using Author_Book_Directory.EF;
using Author_Book_Directory.EF.Tables;
using Microsoft.AspNetCore.Mvc;

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
            var data = db.Books.ToList();
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


    }
}
