using MusalaGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Core.Services
{
    public interface IGatewayService
    {
        Task<IEnumerable<Gateway>> GetGatewaysAsync();

        Task<Gateway> GetGatewayAsync(Guid gatewayId);

        Task AddGatewayAsync(Gateway gateway);

        Task DeleteGatewayAsync(Gateway gateway);

        Task UpdateGatewayAsync();

        bool GatewayExists(Guid gatewayId);

        int GetDevicesCount(Guid gatewayId);
    }
}