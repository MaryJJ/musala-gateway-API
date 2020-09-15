using MusalaGateway.Core.Models;
using MusalaGateway.Core.Repositories;
using MusalaGateway.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _uow;

        public DeviceService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task AddDeviceAsync(Guid gatewayId, Device device)
        {
            if(_uow.Gateways.GetDevicesCount(gatewayId) >= 10)
            {
                throw new ValidationException("No more than 10 devices are allowed for a Gateway");
            }
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            device.GatewayId = gatewayId;
            await _uow.Devices.AddAsync(device);
            await _uow.CommitAsync();
        }

        public async Task DeleteDeviceAsync(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            _uow.Devices.Remove(device);
            await _uow.CommitAsync();
        }

        public async Task<Device> GetDeviceAsync(Guid gatewayId, int deviceId)
        {
            if (gatewayId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(gatewayId));
            }
            if (deviceId == 0)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }
            return await _uow.Devices.SingleOrDefaultAsync(d => d.GatewayId == gatewayId && d.Id == deviceId);
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync(Guid gatewayId)
        {
            if (gatewayId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(gatewayId));
            }
            return await _uow.Devices.FindAsync(d => d.GatewayId == gatewayId);
        }

        public async Task UpdateDeviceAsync()
        {
            await _uow.CommitAsync();
        }
    }
}