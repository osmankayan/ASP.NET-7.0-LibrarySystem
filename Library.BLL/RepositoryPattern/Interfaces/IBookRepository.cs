using Library.DTO;
using Library.MODEL.Models;
using Library.BLL.RepositoryPattern.Base;

namespace Library.BLL.RepositoryPattern.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {
        List<BookDTO> GetBooks();
    }
}
