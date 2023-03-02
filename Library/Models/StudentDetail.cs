using Library.Enums;

namespace Library.Models
{
    public class StudentDetail:BaseEntity
    {
        public string SchoolNumber { get; set; }
       
       
        public DateTime Birthday { get; set; }
        public int StudentID{ get; set; }

        //relational
        public Student Student { get; set; }

    }
}
