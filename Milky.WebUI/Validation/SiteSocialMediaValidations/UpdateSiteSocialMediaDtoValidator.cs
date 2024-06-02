using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.SiteSocialMediaDtos;

namespace Milky.WebUI.Validation.SiteSocialMediaValidations
{
    public class UpdateSiteSocialMediaDtoValidator : AbstractValidator<SiteSocialMediaUpdateDto>
    {
        public UpdateSiteSocialMediaDtoValidator()
        {
            RuleFor(x => x.SiteSocialMediaLink).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.SiteSocialMediaIcon).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}