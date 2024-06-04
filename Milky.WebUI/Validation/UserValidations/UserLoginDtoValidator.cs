using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.UserDtos;

namespace Milky.WebUI.Validation.UserValidations
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}