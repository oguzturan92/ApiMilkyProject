using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.ProductDtos;

namespace Milky.WebUI.Validation.ProductValidations
{
    public class UpdateProductDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.ProductTitle).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.ProductImage).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.ProductSalePrice).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x => x.ProductLink).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}