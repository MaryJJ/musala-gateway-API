using MusalaGateway.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Api.Resources
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DeviceStatus Status { get; set; }
    }
}