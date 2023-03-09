namespace Library.DTO
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string BookTypeName { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFullName { get { return $"{AuthorFirstName} {AuthorLastName}"; } }
        }
       
    }
