using MusalaGateway.Api.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Api.ValidationAttributes
{
    public sealed class NoMore10DevicesAllowed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GatewayForManipulationDto gateway = (GatewayForManipulationDto)validationContext.ObjectInstance;

            if (gateway.Devices.Count > 10)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(GatewayForManipulationDto) });
            }

            return ValidationResult.Success;
        }
    }
}