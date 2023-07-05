using Library.Application.DTOs;
using Library.Domain;
using System.Collections.Generic;

namespace Library.Application.Services
{
    public interface IBookService
    {
        int Create(CreateBook command);
        void Edit(EditBook editBookDto);
        List<BookDto> GetAll();
    }
}