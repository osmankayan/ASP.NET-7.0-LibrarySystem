using Library.Context;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Controllers
{
    [Area("Management")]
    [Authorize(Policy ="AdminPolicy")]
    public class AuthorController : Controller
    {
        MyDbContext _db;
        public AuthorController(MyDbContext db)
        {
            _db = db;
        }
        
        public IActionResult AuthorList()
        {
            List<Author> authors = _db.Authors.Where(x=>x.Status!=Enums.DataStatus.Deleted).ToList();
            return View(authors);
        }
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //if (!ModelState.IsValid)
            //{
            //    return View(author);
            //}
            _db.Authors.Add(author);
            _db.SaveChanges();

            return RedirectToAction("AuthorList","Author",new {area="Management"});
        }
        public IActionResult Edit() { return View(); }
        //public IActionResult Edit(int id) 
        //{
        //    Author author=_db.Authors.Find(id)!;
        //    return View(author);
        //}
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            author.Status = Enums.DataStatus.Updated;
            author.ModifiedDate = DateTime.Now;
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("AuthorList", "Author", new { area = "Management" });
        }
        public IActionResult SoftDelete(int id)
        {
            Author author = _db.Authors.Find(id)!;
            author.Status=Enums.DataStatus.Deleted;
            author.ModifiedDate= DateTime.Now;
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("AuthorList", "Author", new { area = "Management" });
        }
    }
}
