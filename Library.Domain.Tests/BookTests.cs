using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
namespace Library.Domain.Tests
{
    public class BookTests
    {
        [Fact]
        public void Should_Create_Book_Properly()
        {
            //act
            int id = 0;
            string name = "TDD";
            string shabak = "2121515851215";
            //act
            var _book = new Book(id, name, shabak);

            //Assert
            Assert.Equal(name, _book.Name);
            Assert.Equal(_book.Id, id);
            Assert.Equal(_book.Shabak, shabak);

        }



        [Fact]
        public void Should_Set_IsDelted_To_True()
        {
            //act
            int id = 0;
            string name = "TDD";
            string shabak = "2121515851215";
            var _book = new Book(id, name, shabak);

            //act
            _book.Remove();

            //Asssert
            Assert.Equal(_book.IsDeleted, true);

        }
        [Fact]
        public void Should_set_Isdeleted_To_False()
        {
            //act
            int id = 0;
            string name = "TDD";
            string shabak = "2121515851215";
            var _book = new Book(id, name, shabak);

            //act
            _book.Restore();

            //assert
            Assert.Equal(_book.IsDeleted, false);
        }

        [Fact]
        public void Shoul_Add_BookAuthor_To_Book_BookAuthors()
        {
            //arrange
            var fixture = new Fixture();
            var book = fixture.Create<Book>();
            var bookAuthor = fixture.Create<BookAuthor>();
            //act
            book.AddBookAuthor(bookAuthor);

            //assert
            Assert.Contains(bookAuthor,book.BookAuthors);

        }
        [Fact]
        public void Should_Throw_Exception_When_BookAuthor_Exists()
        {
            //arrange
            var fixture = new Fixture();
            var book = fixture.Create<Book>();
            var bookAuthor = fixture.Create<BookAuthor>();
            book.AddBookAuthor(bookAuthor);
            //act  //assert
            Assert.Throws<BookAuthorDoublicatedException>(() => book.AddBookAuthor(bookAuthor));
        }

        [Fact]
        public void Should_Add_BookAuthors_To_BookAuthors()
        {
            //arrange
            var fixture = new Fixture();
            var book = fixture.Create<Book>();
            var bookauthors = new List<BookAuthor>();
            var bookAuthor = fixture.Build<BookAuthor>()
                .With(x => x.BookId, 56)
                .With(x => x.AuthorId, 606)
                .Create();
            var bookAuthor1 = fixture.Build<BookAuthor>()
                .With(x => x.BookId, 506)
                .With(x=>x.AuthorId,66)
                .Create();

            bookauthors.Add(bookAuthor);
            bookauthors.Add(bookAuthor1);

            //act
            book.AddBookAuthors(bookauthors);

            //assert
            Assert.Contains(bookAuthor, book.BookAuthors);
            Assert.Contains(bookAuthor1, book.BookAuthors);

        }

        [Fact]
        public void Should_Edit_Book_Info()
        {
            //arrange
            var fixture = new Fixture();
            var _book = fixture.Build<Book>()
                .With(x=>x.Shabak ,"MSN123")
                .With(x=>x.Name,"TDD Tutorial").Create();
            string newName = "OnionArch";
            string newShabak = "MSN147";
            //act
            _book.Edit(newName, newShabak);

            //assert
            _book.Name.Should().Be(newName);
            _book.Shabak.Should().Be(newShabak);

        }
    }
}
