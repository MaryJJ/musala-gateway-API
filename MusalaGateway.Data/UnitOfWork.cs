using MusalaGateway.Core.Repositories;
using MusalaGateway.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusalaGatewayDbContext _context;
        private bool disposed = false;
        public IGatewayRepository Gateways { get; set; }
        public IDeviceRepository Devices { get; set; }

        public UnitOfWork(MusalaGatewayDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Gateways = Gateways ?? new GatewayRepository(_context);
            Devices = Devices ?? new DeviceRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }
    }
}