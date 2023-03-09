//using FluentValidation;

namespace Library.Models.FluentValidators
{
    public class BookValidator/*:AbstractValidator<Book>*/
    {
        public BookValidator()
        {
            //RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Boş bırakılamaz");
            //RuleFor(x => x.Name).MinimumLength(3).WithMessage("3 karakterden fazla giriniz");


        }
    }
}
