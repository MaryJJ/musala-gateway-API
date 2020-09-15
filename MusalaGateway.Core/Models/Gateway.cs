using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusalaGateway.Core.Models
{
    public class Gateway
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string IpV4 { get; set; }

        public ICollection<Device> Devices { get; set; }
            = new List<Device>();
    }
}