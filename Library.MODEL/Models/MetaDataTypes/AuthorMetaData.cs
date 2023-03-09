using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Library.Models.MetaDataTypes
{
    public class AuthorMetaData
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [MaxLength(15)]
        [MinLength(3)]
        public string FirstName { get; set; }
    }
}
