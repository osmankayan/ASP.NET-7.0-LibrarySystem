using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Initializer
{
    public static class DataInitializer
    {
        public static void seed(ModelBuilder modelBuilder)
        {
            string passw1 = BCrypt.Net.BCrypt.HashPassword("123");
            string passw2 = BCrypt.Net.BCrypt.HashPassword("123");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() {ID=1, UserName = "admin", Password = passw1, role = Enums.Role.admin },
                new AppUser() {ID=2, UserName = "osman", Password = passw2, role = Enums.Role.user }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student() {ID=1,FirstName="kemal",LastName="akca" ,gender=Enums.Gender.Erkek },
                new Student() {ID=2,FirstName="sabiha",LastName="abadan" ,gender=Enums.Gender.Kadın },
                new Student() {ID=3,FirstName="oguz",LastName="karadag" ,gender=Enums.Gender.Erkek }
                
                );
            modelBuilder.Entity<StudentDetail>().HasData(
               new StudentDetail() {ID=1,StudentID=1,SchoolNumber="345",Birthday=new DateTime(2000,11,28) },
               new StudentDetail() {ID=2,StudentID=2,SchoolNumber="456",Birthday=new DateTime(1999,5,30) },
               new StudentDetail() {ID=3,StudentID=3,SchoolNumber="745",Birthday=new DateTime(2001,8, 2)}
               
               );
           


        }
    }
}
