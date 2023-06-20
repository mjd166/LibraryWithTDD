using System;

namespace Library.Domain
{
    public class Author
    {
        public int Id;
        public string Name;
        public string Family;
        public string Email;
        public DateTime Birthday;
        public Gender _Gender;

        public Author(int id, string name, string family, string email, DateTime birthday, Gender male)
        {
            Id = id;
            Name = name;
            Family = family;
            Email = email;
            Birthday = birthday;
            _Gender = male;
        }
    }
}