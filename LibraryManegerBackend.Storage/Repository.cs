﻿using LibraryManegerBackend.Core.Interfaces;

namespace LibraryManegerBackend.Storage;

public class Repository : IRepository
{
    private readonly LibraryContext _context;


    public Repository(LibraryContext context)
    {
        _context = context;
    }
    
    
    public async Task<T> Add<T>(T entity) where T : class
    {
        var entityFromBD = _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entityFromBD.Entity;
    }

    public async Task<T> Update<T>(T entity) where T : class
    {
        var updated = _context.Update(entity);
        await _context.SaveChangesAsync();
        return updated.Entity;
    }

    public async Task Delete<T>(int id) where T : class
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        
    }

    public async Task<T> GetById<T>(int id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }
}