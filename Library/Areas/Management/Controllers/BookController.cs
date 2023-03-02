using Library.Context;
using Library.DTO;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Areas.Controllers
{
	[Area("Management")]
    [Authorize(Policy = "AdminPolicy")]
    public class BookController : Controller
    {
        IBookRepository _bookRepository;
        MyDbContext _db;
        public BookController(MyDbContext db,IBookRepository bookRepository)
        {
            _db = db;
            _bookRepository = bookRepository;
        }
        public IActionResult BookList()
        {
            //List<BookDTO> books = _db.Books.Where(x => x.Status != Enums.DataStatus.Deleted).Include(x => x.Author).Include(x => x.BookType)
            //    .Select(x => new BookDTO()
            //    {
            //        ID = x.ID,
            //        BookName = x.Name,
            //        BookTypeName = x.BookType.Name,
            //        AuthorFirstName = x.Author.FirstName,
            //        AuthorLastName = x.Author.LastName

            //    }).ToList();
            List<BookDTO> books =_bookRepository.GetBooks();
            return View(books);
        }
        public IActionResult Create()
        {
            
            
            List<AuthorDTO> authors = _db.Authors.Where(x => x.Status != Enums.DataStatus.Deleted)
                .Select(x => new AuthorDTO() { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName }).ToList();

            List<BookTypeDTO> booktypes = _db.BookTypes.Where(x => x.Status != Enums.DataStatus.Deleted)
                .Select(x => new BookTypeDTO() { ID = x.ID, TypeName = x.Name }).ToList();

            return View((new Book(), authors, booktypes));
        }
        [HttpPost]
        public IActionResult Create([Bind(Prefix = "Item1")] Book book)
        {
            //if (!ModelState.IsValid)
            //{
            //    //------------------------------------------------------------------------------//
            //    //yukarıdan copy paste for fluent validation
            //    List<AuthorDTO> authors = _db.Authors.Where(x => x.Status != Enums.DataStatus.Deleted)
            //   .Select(x => new AuthorDTO() { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName }).ToList();

            //    List<BookTypeDTO> booktypes = _db.BookTypes.Where(x => x.Status != Enums.DataStatus.Deleted)
            //        .Select(x => new BookTypeDTO() { ID = x.ID, TypeName = x.Name }).ToList();
            //    //elimizdeki book nesnesi yukarıdan farklı
            //    return View((book, authors, booktypes));
            //    //------------------------------------------------------------------------------//

            //}
            //_db.Books.Add(book);
            //_db.SaveChanges();
            _bookRepository.Add(book);
            return RedirectToAction("BookList", "Book", new { area = "Management" });
        }
        public IActionResult Edit(int id)
        {
            Book book = _db.Books.Find(id)!;
            List<AuthorDTO> authors = _db.Authors.Where(x => x.Status != Enums.DataStatus.Deleted)
                 .Select(x => new AuthorDTO() { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName }).ToList();

            List<BookTypeDTO> booktypes = _db.BookTypes.Where(x => x.Status != Enums.DataStatus.Deleted)
                .Select(x => new BookTypeDTO() { ID = x.ID, TypeName = x.Name }).ToList();

            return View((book, authors, booktypes));

        }
        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "Item1")] Book book)
        {

            book.Status = Enums.DataStatus.Updated;
            book.ModifiedDate = DateTime.Now;
            _db.Books.Update(book);
            _db.SaveChanges();
            return RedirectToAction("BookList", "Book", new { area = "Management" });

        }
        public IActionResult HardDelete(int id)
        {
            Book book = _db.Books.Find(id)!;
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("BookList", "Book", new { area = "Management" });
        }
    }
}
