using MusalaGateway.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Api.Resources
{
    public class DeviceForCreationDto
    {
        [MaxLength(150, ErrorMessage = "The vendor shouldn't have more than 150 characters.")]
        public string Vendor { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DeviceStatus Status { get; set; }
    }
}