namespace Library.Domain
{
    public class BookAuthor
    {
       public int Id { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public BookAuthor()
        {

        }
        public BookAuthor(int id, int bookid, int authorid)
        {
            Id = id;
            BookId = bookid;
            AuthorId = authorid;
        }

       

    }
}