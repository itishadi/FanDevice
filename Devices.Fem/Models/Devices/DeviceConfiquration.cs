using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Fem.Models.Devices;

public class DeviceConfiquration
{
    private readonly string _connectionString;

   public DeviceConfiquration(string connectionString)
    {
        _connectionString = connectionString;
    }

    public string DeviceId => _connectionString.Split(',')[1].Split("=")[1];
    public string ConnectionString => _connectionString;
    public bool AllowSending { get; set; } = false;
    public int TelemetryInterval { get; set; } = 10000;
}
