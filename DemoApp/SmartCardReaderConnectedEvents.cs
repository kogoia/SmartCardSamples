﻿using System;
using System.Linq;
using System.Management;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DemoApp.Infrastructure;
using PCSC;
using SmartCardApi.SmartCard.Reader;

namespace DemoApp
{
    public class SmartCardReaderConnectEvents : ISource<IReader> 
    {
        public IObservable<IReader> Source()
        {
            var cardContext = ContextFactory.Instance.Establish(SCardScope.System);
            var usbDevices = new USBDevices();
            return Observable
                .FromEventPattern<EventArrivedEventHandler, EventArrivedEventArgs>(
                    h => usbDevices.DeviceConnectEvent += h,
                    h => usbDevices.DeviceConnectEvent -= h
                )
                .SelectMany(e => new ConnectedReaders(cardContext))
                .Merge(
                    new SmartCardConnectedEvent(cardContext)
                            .Source()
                );
        }
    }
}

