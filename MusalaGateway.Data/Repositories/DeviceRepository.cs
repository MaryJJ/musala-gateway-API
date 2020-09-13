using Microsoft.EntityFrameworkCore;
using MusalaGateway.Core.Models;
using MusalaGateway.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusalaGateway.Data.Repositories
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(MusalaGatewayDbContext context) : base(context)
        {
        }
    }
}