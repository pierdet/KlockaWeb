using KlockaLib.Data;
using KlockaLib.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlockaLib.Repositories
{
    public interface IInventoryRepository
    {
        public void Add(string name);
        public IEnumerable<Inventory> GetAll();
        public Inventory GetByName(string name);
        public Inventory GetById(int id);
        public void UpdateInventory(Inventory inventory);
    }
    public class InventoryRepository : IInventoryRepository
    {
        public void Add(string name)
        {
            using (var context = new AppDbContext())
            {
                if(context.Inventories.Any(i => i.Name == name))
                {
                    throw new ApplicationException("Inventory already exists");
                }
                var entity = new Inventory { Name = name };

                context.Inventories.Add(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable<Inventory> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Inventories.ToList();
            }
        }

        public Inventory GetById(int id)
        {
            using(var context = new AppDbContext())
            {
                return context.Inventories
                    .Include(h => h.Hosts)
                    .FirstOrDefault(i => i.Id == id);
            }
        }

        public Inventory GetByName(string name)
        {
            using(var context = new AppDbContext())
            {
                return context.Inventories
                    .Include(h => h.Hosts)
                    .FirstOrDefault(i => i.Name == name);
            }
        }

        public void UpdateInventory(Inventory inventory)
        {
            using (var context = new AppDbContext())
            {
            context.Inventories.Update(inventory);
            context.SaveChanges();
            }
        }
    }
}
