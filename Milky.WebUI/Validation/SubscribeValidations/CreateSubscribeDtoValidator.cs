using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.SubscribeDtos;

namespace Milky.WebUI.Validation.SubscribeValidations
{
    public class CreateSubscribeDtoValidator : AbstractValidator<SubscribeCreateDto>
    {
        public CreateSubscribeDtoValidator()
        {
            RuleFor(x => x.SubscribeMail).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}