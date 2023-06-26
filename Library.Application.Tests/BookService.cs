using Library.Common;
using Library.Domain;

namespace Library.Application.Tests
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
    }
}