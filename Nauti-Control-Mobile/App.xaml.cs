﻿using Nauti_Control_Mobile.ViewModels.Bluetooth;

namespace Nauti_Control_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            BluetoothManagerVM bluetoothManagerVM = new BluetoothManagerVM();
        }
    }
}