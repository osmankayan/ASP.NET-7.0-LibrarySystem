using Library.DAL.Context;
using Library.MODEL.Models;
using Library.BLL.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Controllers
{
	[Area("Management")]
    [Authorize(Policy = "AdminPolicy")]
    public class BookTypeController : Controller
    {
       
        IRepository<BookType> _repoBookType;
        public BookTypeController(IRepository<BookType> repoBookType)
        {
            
            _repoBookType = repoBookType;
        }
        public IActionResult BookTypeList()
        {
            //List<BookType> booktypes = _db.BookTypes.ToList();
            List<BookType> booktypes = _repoBookType.GetAll();
            return View(booktypes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookType booktype)
        {
            //_db.BookTypes.Add(booktype);
            //_db.SaveChanges();
            _repoBookType.Add(booktype);
            return RedirectToAction("BookTypeList", "BookType", new { area = "Management" });
        }
        public IActionResult Edit() { return View(); }
        [HttpPost]
        public IActionResult Edit(BookType booktype)
        {
            //booktype.Status = Enums.DataStatus.Updated;
            //booktype.ModifiedDate= DateTime.Now;
            //_db.BookTypes.Update(booktype);
            //_db.SaveChanges();
            _repoBookType.Update(booktype);

            return RedirectToAction("BookTypeList", "BookType", new { area = "Management" });
        }
        public IActionResult HardDelete(int id) 
        {
            //BookType booktype=_db.BookTypes.Find(id)!;
           
            //_db.BookTypes.Remove(booktype);
            //_db.SaveChanges();
            _repoBookType.HardDelete(id);
            return RedirectToAction("BookTypeList", "BookType", new { area = "Management" });
        }


    }
}
