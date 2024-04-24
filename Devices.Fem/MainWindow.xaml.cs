using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using FanDevice.Services;

namespace FanDevice
{
    public partial class MainWindow : Window
    {
        private readonly DeviceManager _deviceManager;
        private readonly NetworkManager _networkManager;
        private readonly Storyboard _fanStoryboard;
        private bool _isFanRunning;

        public MainWindow(DeviceManager deviceManager, NetworkManager networkManager)
        {
            InitializeComponent();

            _deviceManager = deviceManager;
            _networkManager = networkManager;

            _fanStoryboard = (Storyboard)this.FindResource("FanStoryboard");

            _isFanRunning = false;

            toggle.Click += ToggleButton_Click;
            Task.Run(CheckConnectivityAsync);
        }

        private async Task CheckConnectivityAsync()
        {
            while (true)
            {
                ConnectivityStatus.Text = await _networkManager.CheckConnectionActivityAsync();
                await Task.Delay(1000);
            }
        }
     
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isFanRunning)
            {
                _fanStoryboard.Stop();
                _isFanRunning = false;
                ConnectivityStatus.Text = "Disconnected";
            }
            else
            {
                _fanStoryboard.Begin();
                _isFanRunning = true;
                ConnectivityStatus.Text = "Connected";
            }
        }
    }
}
