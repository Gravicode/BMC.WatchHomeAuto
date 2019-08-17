using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tizen.Wearable.CircularUI.Forms;
using BMSpace.helpers;

namespace BMSpace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage
    {
        static int Index;
        MqttService iot;
        List<DeviceData> Devices;
        public MainPage()
        {
            InitializeComponent();
            Setup();
        }
        void Setup()
        {
            Index = 0;
            iot = new MqttService();
            Devices = DeviceData.GetAllDevices();
            LoadDesc(Index);
        }

        void LoadDesc(int SelectedIndex)
        {
            if (SelectedIndex >= Devices.Count) SelectedIndex = 0;
            TxtDeviceName.Text = Devices[SelectedIndex].Name;

        }

        private void Control_Off_Device(object sender, EventArgs e)
        {
            
            var item = Devices[Index];
            if (item != null)
            {
                var state = false;
                SwitchDevice(state, item.IP);
            }
        }

        private void Control_On_Device(object sender, EventArgs e)
        {
            var item = Devices[Index];
            if (item != null)
            {
                var state = true;
                SwitchDevice(state, item.IP);
            }
        }
        private async void SwitchDevice(bool State, string IP)
        {
            
            if (State)
            {
                //string DeviceID = $"Device{btn.CommandArgument}IP";
                string URL = $"http://{IP}/cm?cmnd=Power%20On";
                await iot.InvokeMethod("BMCSecurityBot", "OpenURL", new string[] { URL });
            }
            else
            {
                //string DeviceID = $"Device{btn.CommandArgument}IP";
                string URL = $"http://{IP}/cm?cmnd=Power%20Off";
                await iot.InvokeMethod("BMCSecurityBot", "OpenURL", new string[] { URL });
            }
        }

        private void NextBtn_Clicked(object sender, EventArgs e)
        {
            Index++;
            LoadDesc(Index);
        }
    }
}