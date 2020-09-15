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
            builder.Entity<Gateway>().HasData(
                new Gateway()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Gateway Musala Home",
                    IpV4 = "127.0.0.1"
                }, 
                new Gateway()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Name = "Gateway Musala Home",
                    IpV4 = "127.0.0.1"
                },
                new Gateway()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    Name = "Gateway Musala Home",
                    IpV4 = "127.0.0.1"
                },
                new Gateway()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                    Name = "Gateway Musala Home",
                    IpV4 = "127.0.0.1"
                }
            );
            builder.Entity<Device>().HasData(
                new Device()
                {
                    Id = 1,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Offline,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 2,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 3,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 4,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 5,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 6,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 7,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 8,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 9,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 10,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 11,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 12,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 13,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 14,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 15,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 16,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 17,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 18,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 19,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 20,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 21,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 22,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 23,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 24,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                },
                new Device()
                {
                    Id = 25,
                    GatewayId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                    Vendor = "Huawei Inc.",
                    Status = Core.Enums.DeviceStatus.Online,
                    CreatedDate = DateTime.Now
                }
            );
            base.OnModelCreating(builder);
        }
    }
}