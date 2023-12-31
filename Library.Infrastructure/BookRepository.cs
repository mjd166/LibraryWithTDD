﻿using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Infrastracture
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public int Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void Delete(int id)
        {
            var item = Get(id);
            _context.Books.Remove(item);
            _context.SaveChanges();
        }

        public Book Get(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public Book Get(string name)
        {
            return _context.Books.FirstOrDefault(x => x.Name == name);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

       

       
    }
}