using Microsoft.EntityFrameworkCore;
using MusalaGateway.Core.Models;
using MusalaGateway.Core.Repositories;
using MusalaGateway.Core.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusalaGateway.Data.Repositories
{
    public class GatewayRepository : Repository<Gateway>, IGatewayRepository
    {
        public GatewayRepository(MusalaGatewayDbContext context) : base(context)
        {
        }

        public int GetDevicesCount(Guid gatewayId)
        {
            return MusalaGatewayDbContext.Devices.Where(d => d.GatewayId == gatewayId).Count();
        }

        public async Task<PageList<Gateway>> GetGatewaysAsync(GatewayResourceParameters gatewayResourceParameters)
        {
            IQueryable<Gateway> gateways = MusalaGatewayDbContext.Gateways.Include(g => g.Devices);
            return await PageList<Gateway>.CreateAsync(gateways, gatewayResourceParameters.PageNumber, gatewayResourceParameters.PageSize);
        }

        private MusalaGatewayDbContext MusalaGatewayDbContext
        {
            get { return Context as MusalaGatewayDbContext; }
        }
    }
}