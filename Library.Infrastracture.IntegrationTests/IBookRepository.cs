using Library.Domain;

namespace Library.Infrastracture.IntegrationTests
{
    public interface IBookRepository
    {
        int Add(Book book);
    }
}