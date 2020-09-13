using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGatewayRepository Gateways { get; }
        IDeviceRepository Devices { get; }

        Task<int> CommitAsync();
    }
}