using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.AboutDtos;

namespace Milky.WebUI.Validation.AboutValidations
{
    public class CreateAboutDtoValidator : AbstractValidator<AboutCreateDto>
    {
        public CreateAboutDtoValidator()
        {
            RuleFor(x => x.AboutTitle).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.AboutDescription).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.AboutImage1).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.AboutImage2).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.AboutImage3).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}