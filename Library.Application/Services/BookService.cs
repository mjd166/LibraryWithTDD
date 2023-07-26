using Library.Application.DTOs;
using Library.Common;
using Library.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public int Create(CreateBook command)
        {
            var _book = _repository.Get(command._name);
            if (_book != null)
                throw new EntityDoublicatedException();
            var book = new Book(0, command._name, command._shabank);
            return _repository.Add(book);
        }

        public void Edit(EditBook editBookDto)
        {
            var _book = _repository.Get(editBookDto.Id);
            if (_book is null)
                throw new EntityNotFoundException();
            _book.Edit(editBookDto.Title, editBookDto.Shabak);
            _repository.Update(_book);
        }

        public List<BookDto> GetAll()
        {
            var result = _repository.GetAll();

            return result.Select(b => new BookDto
            {
                Id = b.Id,
                Shabak = b.Shabak,
                Title = b.Name
            }).OrderByDescending(b => b.Id)
              .ToList();
        }
      
    }
}