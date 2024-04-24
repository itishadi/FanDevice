namespace FanDevice.Models.Devices;
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
