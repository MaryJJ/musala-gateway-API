using MusalaGateway.Api.Helpers;
using MusalaGateway.Api.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Api.ValidationAttributes
{
    public sealed class IpMustBeValidIpV4 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GatewayForManipulationDto gateway = (GatewayForManipulationDto)validationContext.ObjectInstance;

            if (!Utils.ValidateIPv4(gateway.IpV4))
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(GatewayForManipulationDto) });
            }

            return ValidationResult.Success;
        }
    }
}