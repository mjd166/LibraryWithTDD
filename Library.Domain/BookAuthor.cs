namespace Library.Domain.Tests
{
    public class BookAuthor
    {
       public int Id { get; set; }
       public int BookId { get; set; }
       public int AuthorId { get; set; }

        public BookAuthor(int id, int bookid, int authorid)
        {
            Id = id;
            BookId = bookid;
            AuthorId = authorid;
        }

       

    }
}