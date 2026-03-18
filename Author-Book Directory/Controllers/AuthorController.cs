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

        public IActionResult Details(int id)
        {
            var data = (from a in db.Authors where a.Id == id select a).SingleOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Authors.Find(id);
            string beforeName = data.Name;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Author a)
        {
            var data = db.Authors.Find(a.Id);
            string beforeName = data.Name;
            data.Name = a.Name;
            db.SaveChanges();

            TempData["Msg"] = "from " + beforeName + " to " + a.Name + " edit successfully";
            return RedirectToAction("Index");
        }
    }
}
