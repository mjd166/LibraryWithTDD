using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Shabak { get; set; }
        public bool IsDeleted { get; set; } = false;
        public LinkedList<BookAuthor> BookAuthors { get; set; }
        public Book()
        {

        }
        public Book(int id, string name, string shabak)
        {
            Id = id;
            Name = name;
            Shabak = shabak;
            BookAuthors = new LinkedList<BookAuthor>();
        }

        public void Restore()
        {
            this.IsDeleted = false;
        }

        public void Remove()
        {
            this.IsDeleted =true;
        }

        public void AddBookAuthor(BookAuthor bookAuthor)
        {
            var exists = this.BookAuthors
                .Any(x=>x.BookId==bookAuthor.BookId && x.AuthorId==bookAuthor.AuthorId);
            if (exists) throw new BookAuthorDoublicatedException();
            this.BookAuthors.AddLast(bookAuthor);
        }

        public void AddBookAuthors(List<BookAuthor> bookauthors)
        {
            foreach (var item in bookauthors) this.AddBookAuthor(item);
        }

        public void Edit(string newName, string newShabak)
        {
            Name = newName;
            Shabak = newShabak;
        }
    }
}