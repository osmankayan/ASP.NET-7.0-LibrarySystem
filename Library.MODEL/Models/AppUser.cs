using Library.MODEL.Enums;

namespace Library.MODEL.Models
{
    public class AppUser:BaseEntity
    {
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public Role role{ get; set; }
    }
}
