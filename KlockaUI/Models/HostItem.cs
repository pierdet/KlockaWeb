using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KlockaUI.Models
{
    public class HostItem
    {
        [Required]
        [MinLength(1, ErrorMessage = "Host name to short")]
        [MaxLength(100, ErrorMessage = "Host name to long")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Hostname/IP address to short")] // Ping 1.1 should be the lowest possible
        [MaxLength(255, ErrorMessage = "Hostname/IP address to long")]
        public string IpAddress { get; set; }
    }
}
