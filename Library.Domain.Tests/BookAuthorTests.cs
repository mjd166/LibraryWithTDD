using Xunit;

namespace Library.Domain.Tests
{
    public class BookAuthorTests
    {
        [Fact]
        public void Should_Create_BookAuthor_Properly()
        {
            //arrange
            int id = 1;
            int bookid=1;   
            int authorid=1; 
            //act
            BookAuthor author = new BookAuthor(id,bookid,authorid);
            //assert
            Assert.Equal(author.Id, id);
            Assert.Equal(author.BookId, bookid);
            Assert.Equal(author.AuthorId, authorid);    
        }

    }
}
