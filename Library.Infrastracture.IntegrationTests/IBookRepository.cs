using Library.Domain;

namespace Library.Infrastracture.IntegrationTests
{
    public interface IBookRepository
    {
        int Add(Book book);
        Book Get(int id);
        void Update(Book book);
        void Delete(int id);    
    }
}