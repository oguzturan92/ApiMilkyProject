using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.TeamDtos;

namespace Milky.WebUI.Validation.TeamValidations
{
    public class CreateTeamDtoValidator : AbstractValidator<TeamCreateDto>
    {
        public CreateTeamDtoValidator()
        {
            RuleFor(x => x.TeamImage).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.TeamFullname).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.TeamDepartment).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}