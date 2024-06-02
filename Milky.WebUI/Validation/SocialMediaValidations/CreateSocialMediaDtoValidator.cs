using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.SocialMediaDtos;

namespace Milky.WebUI.Validation.SocialMediaValidations
{
    public class CreateSocialMediaDtoValidator : AbstractValidator<SocialMediaCreateDto>
    {
        public CreateSocialMediaDtoValidator()
        {
            RuleFor(x => x.SocialMediaLink).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.SocialMediaIcon).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}