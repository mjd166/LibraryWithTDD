using Library.Application.Services;

namespace Library.Presentation.API.Tests
{
    internal class BookController
    {
        private IBookService _bookservice;

        public BookController(IBookService bookservice)
        {
            _bookservice = bookservice;
        }
    }
}