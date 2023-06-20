using FluentAssertions;
using System;
using Xunit;
namespace Library.Domain.Tests
{
    public class AuthorTests
    {
        [Fact]
        public void Should_Create_Author_Properly()
        {
            //arrange
            string name = "Majid";
            string family = "Ghafari";
            string email = "mghafari41@yahoo.com";
          
            DateTime birthday = new DateTime(1993, 08, 28);
            // act
            var _author = new Author(0, name,family, 
                email,birthday, Gender.Male);


            //assert
            _author.Name.Should().Be(name);
            _author.Family.Should().Be(family);
            _author.Email.Should().Be(email);   
            _author.Birthday.Should().Be(birthday); 
            _author._Gender.Should().Be(Gender.Male);   
        }
    }
}
