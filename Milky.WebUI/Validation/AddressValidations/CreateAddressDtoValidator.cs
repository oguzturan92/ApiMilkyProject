using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Milky.WebUI.Dtos.AddressDtos;

namespace Milky.WebUI.Validation.AddressValidations
{
    public class CreateAddressDtoValidator : AbstractValidator<AddressCreateDto>
    {
        public CreateAddressDtoValidator()
        {
            
        }
    }
}