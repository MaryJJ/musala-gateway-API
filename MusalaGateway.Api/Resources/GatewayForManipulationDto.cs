using MusalaGateway.Api.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Api.Resources
{
    [IpMustBeValidIpV4(
      ErrorMessage = "The IP address must be a valid IPV4 address.")]
    public abstract class GatewayForManipulationDto
    {
        [MaxLength(100, ErrorMessage = "The name shouldn't have more than 100 characters.")]
        public virtual string Name { get; set; }

        public virtual string IpV4 { get; set; }

        public virtual ICollection<DeviceForCreationDto> Devices { get; set; }
        = new List<DeviceForCreationDto>();
    }
}