namespace Library.Application.Tests
{
    public interface IBookService
    {
        int Create(CreateBook command);
        void Edit(EditBook editBookDto);
    }
}