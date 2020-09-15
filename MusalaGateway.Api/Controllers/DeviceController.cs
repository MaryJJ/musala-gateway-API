using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MusalaGateway.Api.Resources;
using MusalaGateway.Core.Models;
using MusalaGateway.Core.Services;

namespace MusalaGateway.Api.Controllers
{
    [Route("api/gateways/{gatewayId}/devices")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IGatewayService _gatewayService;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IGatewayService gatewayService, IMapper mapper)
        {
            _deviceService = deviceService ?? throw new ArgumentNullException(nameof(deviceService));
            _gatewayService = gatewayService ?? throw new ArgumentNullException(nameof(gatewayService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<DeviceDto>>> GetDevicesForGateway(Guid gatewayId)
        {
            if (!_gatewayService.GatewayExists(gatewayId))
            {
                return NotFound();
            }
            IEnumerable<Device> devices = await _deviceService.GetDevicesAsync(gatewayId);
            return Ok(_mapper.Map<IEnumerable<DeviceDto>>(devices));
        }

        [HttpGet("{deviceId}", Name = "GetDeviceForGateway")]
        [Produces("application/json")]
        public async Task<ActionResult<DeviceDto>> GetDeviceForGateway(Guid gatewayId, int deviceId)
        {
            if (!_gatewayService.GatewayExists(gatewayId))
            {
                return NotFound();
            }
            Device device = await _deviceService.GetDeviceAsync(gatewayId, deviceId);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DeviceDto>(device));
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<DeviceDto>> CreateDeviceForGateway(Guid gatewayId, DeviceForCreationDto device)
        {
            if (!_gatewayService.GatewayExists(gatewayId))
            {
                return NotFound();
            }
            try
            {
                Device newDevice = _mapper.Map<Device>(device);
                await _deviceService.AddDeviceAsync(gatewayId, newDevice);
                var deviceToReturn = _mapper.Map<DeviceDto>(newDevice);
                return CreatedAtRoute("GetDeviceForGateway",
                    new { gatewayId, deviceId = deviceToReturn.Id },
                    deviceToReturn);
            }
            catch(ValidationException e)
            {
                return Problem(e.Message, null, StatusCodes.Status422UnprocessableEntity);
            }
        }

        [HttpDelete("{deviceId}")]
        [Produces("application/json")]
        public async Task<ActionResult> DeleteDeviceForGateway(Guid gatewayId, int deviceId)
        {
            if (!_gatewayService.GatewayExists(gatewayId))
            {
                return NotFound();
            }
            Device device = await _deviceService.GetDeviceAsync(gatewayId, deviceId);
            if (device == null)
            {
                return NotFound();
            }
            await _deviceService.DeleteDeviceAsync(device);
            return NoContent();
        }

        [HttpPatch("{deviceId}")]
        [Produces("application/json")]
        public async Task<ActionResult<DeviceDto>> PartiallyUpdateGateway(Guid gatewayId, int deviceId, JsonPatchDocument<DeviceForUpdateDto> patchDocument)
        {
            if (!_gatewayService.GatewayExists(gatewayId))
            {
                return NotFound();
            }
            Device device = await _deviceService.GetDeviceAsync(gatewayId, deviceId);

            DeviceForUpdateDto deviceToPatch = _mapper.Map<DeviceForUpdateDto>(device);
            // add validation
            patchDocument.ApplyTo(deviceToPatch, ModelState);

            if (!TryValidateModel(deviceToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(deviceToPatch, device);

            await _deviceService.UpdateDeviceAsync();

            return _mapper.Map<DeviceDto>(device);
        }

        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}