using Library.Application.Services;
using NSubstitute;
using Xunit;
namespace Library.Presentation.API.Tests
{
    public class LibraryControllerTests
    {
        [Fact]
        public void Should_Return_All_Books()
        {
            //arrange
            var bookservice = Substitute.For<IBookService>();
            var _controller = new BookController(bookservice);

            //act
            var result = bookservice.GetAll();


            ///assert 
            

           
        }
    }
}
