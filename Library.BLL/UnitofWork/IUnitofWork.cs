using Library.MODEL.Models;
using Library.BLL.RepositoryPattern.Interfaces;

namespace Library.UnitofWork
{
    public interface IUnitofWork:IDisposable
    {
        //IRepository<T> GetRepository<T>() where T : BaseEntity;
        IBookRepository Book { get; }
        int SaveChanges();
    }
}
