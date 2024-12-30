using FluentValidation;

namespace WebApplicationApiEF.Models
{
    public class PetValidator:AbstractValidator<PetAnimal>
    {
        public PetValidator()
        {
            RuleFor(pet => pet.petType).NotEmpty().WithMessage("please mention pet name");
            RuleFor(pet => pet.petName).NotEmpty().WithMessage("please mention pet name");

        }
    }
}
