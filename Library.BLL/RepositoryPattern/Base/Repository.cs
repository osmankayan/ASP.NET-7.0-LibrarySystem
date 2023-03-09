using Library.DAL.Context;
using Library.MODEL.Models;
using Library.BLL.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.BLL.RepositoryPattern.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        MyDbContext _db;
        protected DbSet<T> table;
        public Repository(MyDbContext db)
        {
            _db= db;
            table=db.Set<T>();  

        }
        private void SaveChanges()
        {
            _db.SaveChanges();
        }
        //public void Add(T item)
        //{
        //    table.Add(item);
        //    SaveChanges();
        //}

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public int Count()
        {
            return table.Count();
        }

        public List<T> GetActives()
        {
           return table.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> GetAll()
        {
           return table.ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id)!;
        }

        public void HardDelete(int id)
        {
           T item=table.Find(id)!;
            table.Remove(item);
            SaveChanges();
        }

        public List<T> SelectActivesByLimit(int count)
        {
            return table.Where(x=>x.Status!= MODEL.Enums.DataStatus.Deleted).Take(count).ToList();
        }

        public void SoftDelete(int id)
        {
            T item=table.Find(id)!;
            //T item=GetById(id);
            item.Status = MODEL.Enums.DataStatus.Deleted;
            item.ModifiedDate= DateTime.Now;
            table.Update(item);
            SaveChanges();
        }

        public void Update(T item)
        {
            item.Status = MODEL.Enums.DataStatus.Deleted;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            SaveChanges();
        }

        public T Default(Expression<Func<T, bool>> exp)
        {
          return  table.FirstOrDefault(exp)!;
        }

        public void Add(T item)
        {
            table.Add(item);
            SaveChanges();
        }
    }
}
