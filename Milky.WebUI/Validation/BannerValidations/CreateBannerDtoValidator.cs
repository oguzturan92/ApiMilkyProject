using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.BannerDtos;

namespace Milky.WebUI.Validation.BannerValidations
{
    public class CreateBannerDtoValidator : AbstractValidator<BannerCreateDto>
    {
        public CreateBannerDtoValidator()
        {
            RuleFor(x => x.BannerImage).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.BannerTitle).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.BannerSubTitle).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.BannerLink).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}