using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.UserDtos;

namespace Milky.WebUI.Validation.UserValidations
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.UserAdi).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.UserSoyadi).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.RePassword).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}