using Microsoft.EntityFrameworkCore;
using MusalaGateway.Core.Models;
using MusalaGateway.Core.Repositories;
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

        private MusalaGatewayDbContext MusalaGatewayDbContext
        {
            get { return Context as MusalaGatewayDbContext; }
        }
    }
}