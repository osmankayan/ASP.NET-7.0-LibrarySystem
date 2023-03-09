using Library.MAP.Configuration;
//using Library.DAL.Initializer;
using Library.MODEL.Models;
using Microsoft.EntityFrameworkCore;
using Library.DAL.Context;

namespace Library.DAL.Context
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DataInitializer.seed(modelBuilder);
            DataInitializer.seed(modelBuilder);
             
            //enroll table için baseentityden kalıtılan id yi devre dışı bırakıyoruz
            modelBuilder.Entity<Operation>().Ignore(x=>x.ID);
            //enroll table için 2 primary key belirliyoruz
            modelBuilder.Entity<Operation>().HasKey("StudentID","BookID");
            //student-student detail arasındaki one to one rel.
            modelBuilder.Entity<Student>().HasOne<StudentDetail>(s => s.StudentDetail).WithOne(sd => sd.Student)
                                     .HasForeignKey<StudentDetail>(fk => fk.StudentID);
            //book-author ve book-booktype arasındaki one to many rel.

            //modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(fk => fk.AuthorID);
            //modelBuilder.Entity<Book>().HasOne(b => b.BookType).WithMany(bt => bt.Books).HasForeignKey(fk => fk.BookTypeID);
            modelBuilder.ApplyConfiguration(new BookConfiguration()); 

            //book ve student arasındaki many to manyi operation enrolu ile 2 tane one to many olarak alıyoruz.
            modelBuilder.Entity<Operation>().HasOne(o=>o.Book).WithMany(b=>b.Operations).HasForeignKey(fk=>fk.BookID);
            modelBuilder.Entity<Operation>().HasOne(o=>o.Student).WithMany(b=>b.Operations).HasForeignKey(fk=>fk.StudentID);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
