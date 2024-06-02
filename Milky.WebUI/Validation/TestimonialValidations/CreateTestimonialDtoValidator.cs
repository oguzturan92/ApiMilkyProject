using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.TestimonialDtos;

namespace Milky.WebUI.Validation.TestimonialValidation
{
    public class CreateTestimonialDtoValidator : AbstractValidator<TestimonialCreateDto>
    {
        public CreateTestimonialDtoValidator()
        {
            RuleFor(x => x.TestimonialFullname).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.TestimonialComment).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.TestimonialDepartment).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.TestimonialImage).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}