﻿using System;
using System.Threading.Tasks;

namespace Bsw.FayeDotNet.Client
{
    public delegate void ConnectionEvent(object sender, EventArgs args);

    public interface IFayeConnection
    {
        /// <summary>
        /// The client ID assigned by the server
        /// </summary>
        string ClientId { get; }

        Task Disconnect();

        Task Subscribe(string channel,
                       Action<string> messageReceived);

        Task Unsubscribe(string channel);

        Task Publish(string channel,
                     string message);

        event ConnectionEvent ConnectionLost;

        event ConnectionEvent ConnectionReestablished;
    }
}