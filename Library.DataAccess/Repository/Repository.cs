﻿using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly LibraryDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(LibraryDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
        _db.Books.Include(x => x.Category);
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
    {
        IQueryable<T> query;

        if (tracked)
        {
            query = dbSet;
            return query.FirstOrDefault();
        }
        else
        {
            query = dbSet.AsNoTracking();
        }
        query = query.Where(filter);
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {

                query = query.Include(property);
            }
        }
        return query.FirstOrDefault();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }
        }
        return query.ToList();
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }
}
