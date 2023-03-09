﻿namespace Library.MODEL.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string PageCount { get; set; }
        //foreign key (for author)
        public int AuthorID { get; set; }
        public int BookTypeID { get; set; }

        //relational

        public Author Author { get; set; }
        public BookType BookType { get; set; }

        public List<Operation> Operations { get; set; }
    }
}
