using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KlockaLib.Data.Entities
{
    public class Host
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public bool? IsOnline { get; set; }
        public DateTime? LastChecked { get; set; }

        public Inventory Inventory { get; set; }
        public int InventoryId { get; set; }
    }
}
