//using Device.Fan;
//using Devices.Fem.Models.Devices;
//using Devices.Fem.Services;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows;

//namespace Devices.Fem
//{


//    public partial class App : Application
//    {
//        public static IHost? host { get; set; }

//        public App()
//        {
//            host = Host.CreateDefaultBuilder()
//                .ConfigureAppConfiguration((context, config)=>{

//            })
//               .ConfigureServices((config, services) =>
//               {
//                   services.AddSingleton<MainWindow>();
//                   services.AddSingleton(new DeviceConfiquration(config.Configuration.GetConnectionString("Device")!));
//                   services.AddSingleton<DeviceManager>();
//                   services.AddSingleton<NetworkManager>();

//               })
//               .Build();
//        }

//        protected override async void OnStarUp(StartupEventArgs e)
//        {
//            await host.StartAsync();
//            var mainWindow = host.Services.GetRequiredService<MainWindow>();
//            mainWindow.Show();
//            base.OnStartup(e);
//        }

//    }
//}
using Device.Fan;
using Devices.Fem.Models.Devices;
using Devices.Fem.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Devices.Fem
{
    public partial class App : Application
    {
        public static IHost? host { get; set; }

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) => {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
               .ConfigureServices((config, services) =>
               {
                   services.AddSingleton<MainWindow>();
                   services.AddSingleton(new DeviceConfiquration(config.Configuration.GetConnectionString("Device")!));
                   services.AddSingleton<DeviceManager>();
                   services.AddSingleton<NetworkManager>();

               })
               .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host!.StartAsync();
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}

