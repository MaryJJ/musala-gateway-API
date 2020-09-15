using MusalaGateway.Core.Models;
using MusalaGateway.Core.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Core.Services
{
    public interface IGatewayService
    {
        Task<IEnumerable<Gateway>> GetGatewaysAsync();

        Task<PageList<Gateway>> GetGatewaysAsync(GatewayResourceParameters gatewayResourceParameters);

        Task<Gateway> GetGatewayAsync(Guid gatewayId);

        Task AddGatewayAsync(Gateway gateway);

        Task DeleteGatewayAsync(Gateway gateway);

        Task UpdateGatewayAsync();

        bool GatewayExists(Guid gatewayId);

        int GetDevicesCount(Guid gatewayId);
    }
}