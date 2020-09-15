using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MusalaGateway.Core.Models;
using MusalaGateway.Core.Repositories;
using MusalaGateway.Data;
using MusalaGateway.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Tests
{
    public class GatewaysServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task NoMore10DeviceAllowed()
        {
            Gateway ga = new Gateway()
            {
                Id = Guid.NewGuid(),
                Name = "Testing",
                IpV4 = "127.0.0.1",
                Devices = new List<Device>()
            };
            for(int i = 1; i <= 11; i++)
            {
                ga.Devices.Add(new Device()
                {
                    CreatedDate = DateTime.Now,
                    Id = i,
                    Status = Core.Enums.DeviceStatus.Online,
                    Vendor = "Huawei Inc"
                });
            }

            var sp = new ServiceCollection().AddDbContext<MusalaGatewayDbContext>().BuildServiceProvider();

            var dbContext = sp.GetService<MusalaGatewayDbContext>();
            GatewayService gatewayService = new GatewayService(new UnitOfWork(dbContext));

            try
            {
                await gatewayService.AddGatewayAsync(ga);
            }catch(Exception e)
            {
                Assert.IsInstanceOf<ValidationException>(e);
            }

        }
    }
}
