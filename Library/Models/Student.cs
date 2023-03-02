using Library.Enums;

namespace Library.Models
{
    public class Student:BaseEntity
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public Gender gender{ get; set; }
        

        //relational
        public List<Operation> Operations { get; set; }
        public StudentDetail StudentDetail { get; set; }
    }
}
