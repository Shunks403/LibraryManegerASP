﻿using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Services;

public class BookService : IBookService
{
    private readonly IRepository _repository;
    
    public BookService()
    {
        
    }
    
    public Task<Book> AddBook(Book book)
    {
        return _repository.Add(book);
    }

    public Task<Book> UpdateBook(Book book)
    {
        return _repository.Update(book);
    }

    public IEnumerable<Book> GetAllBooks(int page, int size)
    {
        return _repository.GetAll<Book>().Skip((page - 1) * size).Take(size).ToList();
        
    }

    public Task DeleteBook(int id)
    {
        return _repository.Delete<Book>(id);
    }
}