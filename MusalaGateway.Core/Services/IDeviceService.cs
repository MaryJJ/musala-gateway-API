using MusalaGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Core.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetDevicesAsync(Guid gatewayId);

        Task<Device> GetDeviceAsync(Guid gatewayId, int deviceId);

        Task AddDeviceAsync(Guid gatewayId, Device device);

        Task UpdateDeviceAsync();

        Task DeleteDeviceAsync(Device device);
    }
}