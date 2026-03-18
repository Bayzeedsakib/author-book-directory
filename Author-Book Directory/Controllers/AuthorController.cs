using Author_Book_Directory.EF;
using Author_Book_Directory.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Author_Book_Directory.Controllers
{
    public class AuthorController : Controller
    {
        AuthorBookDirectoryContext db;

        public AuthorController(AuthorBookDirectoryContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Authors.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author a)
        {
            db.Authors.Add(a);
            db.SaveChanges();

            TempData["Msg"] = a.Name + " created successfully";
            return RedirectToAction("Index");
        }

    }
}
