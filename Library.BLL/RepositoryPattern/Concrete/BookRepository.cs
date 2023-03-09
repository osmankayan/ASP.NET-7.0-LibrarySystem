using Library.DAL.Context;
using Library.DTO;
using Library.MODEL.Models;
using Library.BLL.RepositoryPattern.Base;
using Library.BLL.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.RepositoryPattern.Concrete
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(MyDbContext db) : base(db)
        {
        }

        public List<BookDTO> GetBooks()
        {
            return table.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Include(x => x.Author).Include(x => x.BookType)
                .Select(x => new BookDTO()
                {
                    ID = x.ID,
                    BookName = x.Name,
                    BookTypeName = x.BookType.Name,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                }).ToList();
        }
    }
}
