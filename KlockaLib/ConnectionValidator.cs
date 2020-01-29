using KlockaLib.Models;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace KlockaLib
{
    public class ConnectionValidator : IDisposable
    {
        private readonly Ping _pinger;
        public ConnectionValidator()
        {
            _pinger = new Ping();
        }

        public ConnectionValidatorResponse Validate(string connection)
        {
            try
            {
                var reply = _pinger.Send(connection, 1000);

                if (reply == null)
                {
                    return new ConnectionValidatorResponse
                    {
                        Connection = connection,
                        Success = false,
                        ErrorMessage = "could not receive a reply"
                    };
                }

                return new ConnectionValidatorResponse
                {
                    Connection = connection,
                    Success = reply.Status == IPStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ConnectionValidatorResponse
                {
                    Connection = connection,
                    Success = false,
                    ErrorMessage = $"unexpected error occurred: {e.Message}"
                };
            }
        }

        public void Dispose()
        {
            _pinger.Dispose();
        }
    }

    
}
