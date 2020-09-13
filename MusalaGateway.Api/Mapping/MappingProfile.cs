using AutoMapper;
using MusalaGateway.Api.Resources;
using MusalaGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGateway.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gateway, GatewayDto>();
            CreateMap<GatewayForCreationDto, Gateway>();
            CreateMap<GatewayForUpdateDto, Gateway>();
            CreateMap<Gateway, GatewayForUpdateDto>();
            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceForCreationDto, Device>();
            CreateMap<Device, DeviceForCreationDto>();
            CreateMap<Device, DeviceForUpdateDto>();
            CreateMap<DeviceForUpdateDto, Device>();
        }
    }
}