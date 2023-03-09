﻿using Library.MODEL.Models;
using System.Linq.Expressions;

namespace Library.BLL.RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        List<T> GetAll();
        List<T> GetActives();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void SoftDelete(int id);
        void HardDelete(int id);
        List<T> GetByFilter(Expression<Func<T, bool>> exp);
        T Default(Expression<Func<T, bool>> exp);
        int Count();
        bool Any(Expression<Func<T, bool>> exp);
        List<T> SelectActivesByLimit(int count);
    }
}
