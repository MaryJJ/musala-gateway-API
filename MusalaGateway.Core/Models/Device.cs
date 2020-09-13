using MusalaGateway.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusalaGateway.Core.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Vendor { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DeviceStatus Status { get; set; }

        [ForeignKey("GatewayId")]
        public Gateway Gateway { get; set; }

        public Guid GatewayId { get; set; }
    }
}