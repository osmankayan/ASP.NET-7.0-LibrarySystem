namespace Library.MODEL.Models
{
    public class BookType:BaseEntity
    {
        public string Name{ get; set; }

        //relational
        public List<Book> Books { get; set; }
    }
}
