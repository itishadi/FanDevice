﻿using FanDevice.Models.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace FanDevice.Services
{
    public class DeviceManager
    {
        private readonly DeviceConfiquration _config;
        private readonly DeviceClient _client;

        public DeviceManager(DeviceConfiquration config)
        {
            _config = config;
            _client = DeviceClient.CreateFromConnectionString(_config.ConnectionString);
            Task.FromResult(StartAsync());
        }

        public bool AllowSending() => _config.AllowSending;


        private async Task StartAsync()
        {
            await _client.SetMethodDefaultHandlerAsync(DirectMethodDefaultCallback, null);
        }

        private async Task<MethodResponse> DirectMethodDefaultCallback(MethodRequest req, object userContext)
        {
            var res = new DirectMethodDataResponse { Message = $"Executed method: {req.Name} successfully." };

            switch (req.Name.ToLower())
            {
                case "start":
                    _config.AllowSending = true;
                    break;

                case "stop":
                    _config.AllowSending = false;
                    break;

                default:
                    res.Message = $"Direct method {req.Name} not found.";
                    return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)), 404);
            }

            await Task.Delay(100);
            return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)), 200);
        }
    }
}
