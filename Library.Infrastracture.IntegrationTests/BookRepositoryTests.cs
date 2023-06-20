using AutoFixture;
using Library.Domain;
using System;
using Xunit;

namespace Library.Infrastracture.IntegrationTests
{
    public class BookRepositoryTests : IClassFixture<RealDatabaseFixture>
    {
        private readonly BookRepository _repository;
        private readonly Fixture _fixture;
        public BookRepositoryTests(RealDatabaseFixture dBfixture)
        {
            //dBfixture = new RealDatabaseFixture();
            _repository = new BookRepository(dBfixture.context);
            _fixture = new Fixture();
        }

        [Fact]
        public void Should_Add_New_Book()
        {
            //arrange
            Book book = new Book(0, "BDD", "MSN2011");
                

            //act
            int id = _repository.Add(book);

            //assert

            Assert.Equal(book.Id, id);  

        }

        [Fact]
        public void Should_Get_All_Books()
        {
            //arrange
            Book book = new Book(0, "BDD", "MSN2011");
            Book book2 = new Book(0, "DDD", "MSN2012");

            _repository.Add(book);
            _repository.Add(book2);
            //act
            var books = _repository.GetAll();

            //assert
            Assert.Contains(book, books);
            Assert.Contains(book2, books);

        }

        [Fact]
        public void Should_Get_With_Passed_Id()
        {
            //arrange
            Book book = new Book(0, "BDD", "MSN2011");
            int id = _repository.Add(book);

            //act
            var _book = _repository.Get(id);

            //assert
            Assert.Equal(_book.Id, id); 

        }

        [Fact]
        public void Should_Return_Null_When_NotFound_With_Passed_Id()
        {
            //arrange
            int id = 101;
            Book book = new Book(0, "BDD", "MSN2011");
            _repository.Add(book);

            //act
            var _book = _repository.Get(id);

            //assert
            Assert.Null(_book);
        }

        [Fact]
        public void Should_Update_Book()
        {
            //arrange
            Book book = new Book(0, "BDD", "MSN2011");
            int id = _repository.Add(book);
            string editedname = "TDD";
            string editedshabak = "MSN2020";
            book.Edit(editedname,editedshabak);
            //act
            _repository.Update(book);
            var b = _repository.Get(id);
            //assert
            Assert.Equal(editedshabak, b.Shabak);
            Assert.Equal(editedname,b.Name);
        }

        [Fact]
        public void Should_Delete_Book_With_Passed_Id()
        {
            //arrange
            Book book = new Book(0, "BDD", "MSN2011");
            int id = _repository.Add(book);

            //act 
            _repository.Delete(id);

            var b = _repository.Get(id);
            //assert

            Assert.Null(b);
        }

       
    }
}
