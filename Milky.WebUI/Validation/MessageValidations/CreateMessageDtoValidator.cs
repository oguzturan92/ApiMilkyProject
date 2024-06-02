using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.MessageDtos;

namespace Milky.WebUI.Validation.MessageValidations
{
    public class CreateMessageDtoValidator : AbstractValidator<MessageCreateDto>
    {
        public CreateMessageDtoValidator()
        {
            RuleFor(x => x.MessageFullname).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.MessageMail).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}