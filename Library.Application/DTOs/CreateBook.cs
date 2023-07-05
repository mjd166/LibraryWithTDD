namespace Library.Application.DTOs
{
    public class CreateBook
    {
        public string _name;
        public string _shabank;

        public CreateBook(string name, string shabank)
        {
            _name = name;
            _shabank = shabank;
        }
    }
}