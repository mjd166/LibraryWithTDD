namespace Library.Domain
{
    public interface IBookRepository
    {
        int Add(Book book);
        Book Get(int id);
        Book Get(string name);
        void Update(Book book);
        void Delete(int id);    
    }
}