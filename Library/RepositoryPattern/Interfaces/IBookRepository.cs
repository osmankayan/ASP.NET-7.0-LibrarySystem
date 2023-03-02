using Library.DTO;
using Library.Models;
using Library.RepositoryPattern.Base;

namespace Library.RepositoryPattern.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {
        List<BookDTO> GetBooks();
    }
}
