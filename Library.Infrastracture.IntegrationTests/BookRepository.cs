using Library.Domain;
using System;

namespace Library.Infrastracture.IntegrationTests
{
    public class BookRepository: IBookRepository
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
    }
}