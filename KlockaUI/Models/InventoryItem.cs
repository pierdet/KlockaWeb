using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KlockaUI.Models
{
    public class InventoryItem
    {
        [Required]
        [StringLength(100,ErrorMessage = "Name is to long")]
        [MinLength(1, ErrorMessage = "Name is to short")]
        public string Name { get; set; }
    }
}
