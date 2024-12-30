using FluentValidation;

namespace Medicines_Management.Models
{
    public class Validation : AbstractValidator<Medicine>
    {
        public Validation()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(m => m.Type)
                .NotEmpty().WithMessage("Type is required.")
                .Length(5, 50).WithMessage("Type must be between 2 and 50 characters.");


        }
    }

}
