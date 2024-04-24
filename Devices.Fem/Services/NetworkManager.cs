using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FanDevice.Services;

public class NetworkManager
{
    public virtual async Task<string> CheckConnectionActivityAsync(string ipAddress = "8.8.8.8")
    {
        var isConnected = await SendPingAsync(ipAddress);
        return isConnected ? "Coonected" : "Disconnected";
    }

    private async Task<bool> SendPingAsync(string ipAddress)
    {
        try
        {
            using var ping = new Ping();
            var reply = await ping.SendPingAsync(ipAddress, 1000, new byte[32], new());
            return reply.Status == IPStatus.Success;
        }
        catch { return false; }
    }
}
