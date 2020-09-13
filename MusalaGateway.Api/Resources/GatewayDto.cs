using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Api.Resources
{
    public class GatewayDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IpV4 { get; set; }
        public int DevicesCount { get; set; }
    }
}