using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KlockaLib.Data.Entities
{
    public class Inventory
    {
        public Inventory()
        {
            Hosts = new List<Host>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Host> Hosts { get; set; }
    }
}
