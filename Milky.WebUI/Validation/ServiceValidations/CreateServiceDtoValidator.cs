using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.ServiceDtos;

namespace Milky.WebUI.Validation.ServiceValidation
{
    public class CreateServiceDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x => x.ServiceTitle).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.ServiceDescription).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.ServiceImage).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}