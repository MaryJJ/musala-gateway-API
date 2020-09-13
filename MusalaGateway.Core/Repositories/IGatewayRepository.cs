using MusalaGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Core.Repositories
{
    public interface IGatewayRepository : IRepository<Gateway>
    {
        int GetDevicesCount(Guid gatewayId);
    }
}