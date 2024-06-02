using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.SliderDtos;

namespace Milky.WebUI.Validation.SliderValidation
{
    public class CreateSliderDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public CreateSliderDtoValidator()
        {
            RuleFor(x => x.SliderTitle).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.SliderSubTitle).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.SliderLink).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.SliderImage).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}