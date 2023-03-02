using Library.Context;
using Library.DTO;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.RepositoryPattern.Concrete
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(MyDbContext db) : base(db)
        {
        }

        public List<BookDTO> GetBooks()
        {
            return table.Where(x => x.Status != Enums.DataStatus.Deleted).Include(x => x.Author).Include(x => x.BookType)
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
