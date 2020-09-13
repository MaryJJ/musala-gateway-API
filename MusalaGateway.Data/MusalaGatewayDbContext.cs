using Microsoft.EntityFrameworkCore;
using MusalaGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusalaGateway.Data
{
    public class MusalaGatewayDbContext : DbContext
    {
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }

        public MusalaGatewayDbContext(DbContextOptions<MusalaGatewayDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}