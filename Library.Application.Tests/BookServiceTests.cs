using FluentAssertions;
using Library.Common;
using Library.Domain;
using NSubstitute;
using System;
using Xunit;
namespace Library.Application.Tests
{
    public class BookServiceTests
    {
        private readonly IBookRepository _repository;
        private readonly IBookService _service;

        public BookServiceTests()
        {
            _repository = Substitute.For<IBookRepository>();
            _service = new BookService(_repository);
        }
        [Fact]
        public void Should_Create_Book()
        {
            //arrange 
            string name = "Test Driven Development";
            string shabank = "MNJD25d";
            var _command = new CreateBook(name, shabank);

            //act
            int id = _service.Create(_command);

            //assert
            _repository.Received(1).Add(Arg.Any<Book>());
            _repository.ReceivedWithAnyArgs().Add(default);

        }

        [Fact]
        public void Should_Create_A_New_Book_And_Retrun_Id()
        {
            //arrange 
            string name = "Test Driven Development";
            string shabank = "MNJD25d";
            var _command = new CreateBook(name, shabank);

            //act
            int id = _service.Create(_command);

            //assert
            id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Should_Throw_Exception_when_Doublicated()
        {
            //arrange 
            var book = new Book(10, "Test Driven Development", "MNJD5d");
            var command = new CreateBook("Test Driven Development", "MNJD5d");
            _repository.Get (Arg.Any<string>()).Returns(book);
            //act
            Action actual = () => _service.Create(command);

            //assert
            actual.Should().Throw<EntityDoublicatedException>();

        }

        
    }
}
