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
            dBfixture = new RealDatabaseFixture();
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

       
    }
}
