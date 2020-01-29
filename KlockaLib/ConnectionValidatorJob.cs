using KlockaLib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlockaLib
{
    public class ConnectionValidatorJob
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ConnectionValidator _connectionValidator;
        public ConnectionValidatorJob(IInventoryRepository inventoryRepository, ConnectionValidator connectionValidator)
        {
            _inventoryRepository = inventoryRepository;
            _connectionValidator = connectionValidator;
        }
        
        public void CheckHosts()
        {
            var hosts = _inventoryRepository.GetAllHosts();
            foreach (var host in hosts)
            {
                var response = _connectionValidator.Validate(host.IpAddress);
                if (response.Success)
                {
                    host.IsOnline = true;
                    _inventoryRepository.UpdateHost(host);
                }
                else
                {
                    host.IsOnline = false;
                    _inventoryRepository.UpdateHost(host);
                }
            }
        }
    }
}
