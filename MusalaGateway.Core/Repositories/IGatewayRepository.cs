using MusalaGateway.Core.Models;
using MusalaGateway.Core.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Core.Repositories
{
    public interface IGatewayRepository : IRepository<Gateway>
    {
        int GetDevicesCount(Guid gatewayId);

        Task<PageList<Gateway>> GetGatewaysAsync(GatewayResourceParameters gatewayResourceParameters);
    }
}