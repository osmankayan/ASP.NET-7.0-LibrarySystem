using Library.DAL.Context;
using Library.Models;
using Library.BLL.RepositoryPattern.Base;
using Library.BLL.RepositoryPattern.Concrete;
using Library.BLL.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.UnitofWork
{
    public class EfUnitofWork : IUnitofWork
    {
        MyDbContext db;
        IBookRepository dbBook;
        public EfUnitofWork(MyDbContext db)
        {
            this.db = db;
            Book = new BookRepository(db);
        }

        //public IBookRepository bookRepo => throw new NotImplementedException();
        public IBookRepository Book { get; private set; }

        public void Dispose()
        {
            db.Dispose();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
