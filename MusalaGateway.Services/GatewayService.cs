using MusalaGateway.Core.Models;
using MusalaGateway.Core.Repositories;
using MusalaGateway.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IUnitOfWork _uow;

        public GatewayService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task AddGatewayAsync(Gateway gateway)
        {
            if (gateway == null)
            {
                throw new ArgumentNullException(nameof(gateway));
            }
            gateway.Id = Guid.NewGuid();
            await _uow.Gateways.AddAsync(gateway);
            await _uow.CommitAsync();
        }

        public async Task DeleteGatewayAsync(Gateway gateway)
        {
            if (gateway == null)
            {
                throw new ArgumentNullException(nameof(gateway));
            }
            _uow.Gateways.Remove(gateway);
            await _uow.CommitAsync();
        }

        public bool GatewayExists(Guid gatewayId)
        {
            if (gatewayId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(gatewayId));
            }

            return _uow.Gateways.Exist(a => a.Id == gatewayId);
        }

        public int GetDevicesCount(Guid gatewayId)
        {
            return _uow.Gateways.GetDevicesCount(gatewayId);
        }

        public async Task<Gateway> GetGatewayAsync(Guid gatewayId)
        {
            if (gatewayId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(gatewayId));
            }
            return await _uow.Gateways.SingleOrDefaultIncludeAsync(g => g.Id == gatewayId, g => g.Devices);
        }

        public async Task<IEnumerable<Gateway>> GetGatewaysAsync()
        {
            return await _uow.Gateways.GetAllIncludeAsync(g => g.Devices);
        }

        public async Task UpdateGatewayAsync()
        {
            await _uow.CommitAsync();
        }
    }
}