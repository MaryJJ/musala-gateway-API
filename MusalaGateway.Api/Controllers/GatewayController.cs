using System;
using System.Collections.Generic;
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
    [Route("api/gateways")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _gatewayService;
        private readonly IMapper _mapper;

        public GatewayController(IGatewayService gatewayService, IMapper mapper)
        {
            _gatewayService = gatewayService ?? throw new ArgumentNullException(nameof(gatewayService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<GatewayDto>>> GetGateways()
        {
            IEnumerable<Gateway> gateways = await _gatewayService.GetGatewaysAsync();
            return Ok(_mapper.Map<IEnumerable<GatewayDto>>(gateways));
        }

        [HttpGet("{gatewayId}", Name = "GetGateway")]
        public async Task<ActionResult<GatewayDto>> GetGateway(Guid gatewayId)
        {
            Gateway gateway = await _gatewayService.GetGatewayAsync(gatewayId);
            if (gateway == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GatewayDto>(gateway));
        }

        [HttpPost()]
        public async Task<ActionResult<GatewayDto>> CreateGateway(GatewayForCreationDto gateway)
        {
            Gateway newGateway = _mapper.Map<Gateway>(gateway);
            await _gatewayService.AddGatewayAsync(newGateway);

            var gatewayToReturn = _mapper.Map<GatewayDto>(newGateway);
            return CreatedAtRoute("GetGateway",
                new { gatewayId = gatewayToReturn.Id },
                gatewayToReturn);
        }

        [HttpDelete("{gatewayId}")]
        public async Task<ActionResult> DeleteGateway(Guid gatewayId)
        {
            Gateway gateway = await _gatewayService.GetGatewayAsync(gatewayId);
            if (gateway == null)
            {
                return NotFound();
            }
            await _gatewayService.DeleteGatewayAsync(gateway);
            return NoContent();
        }

        [HttpPatch("{gatewayId}")]
        public async Task<ActionResult<GatewayDto>> PartiallyUpdateGateway(Guid gatewayId, JsonPatchDocument<GatewayForUpdateDto> patchDocument)
        {
            Gateway gateway = await _gatewayService.GetGatewayAsync(gatewayId);

            GatewayForUpdateDto gatewayToPatch = _mapper.Map<GatewayForUpdateDto>(gateway);
            // add validation
            patchDocument.ApplyTo(gatewayToPatch, ModelState);

            if (!TryValidateModel(gatewayToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(gatewayToPatch, gateway);

            await _gatewayService.UpdateGatewayAsync();

            return _mapper.Map<GatewayDto>(gateway);
        }

        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}