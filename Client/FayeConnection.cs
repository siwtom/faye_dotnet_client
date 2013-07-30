﻿#region

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bsw.FayeDotNet.Messages;
using Bsw.WebSocket4NetSslExt.Socket;

#endregion

namespace Bsw.FayeDotNet.Client
{
    internal class FayeConnection : IFayeConnection
    {
        private readonly IWebSocket _socket;
        private readonly HandshakeResponseMessage _handshakeResponse;

        public FayeConnection(IWebSocket socket,
                              HandshakeResponseMessage handshakeResponse)
        {
            _handshakeResponse = handshakeResponse;
            _socket = socket;
            ClientId = handshakeResponse.ClientId;
        }

        public string ClientId { get; private set; }

        public Task Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task Subscribe(string channel,
                              Action<object> messageReceived)
        {
            throw new NotImplementedException();
        }

        public Task Unsubscribe(string channel)
        {
            throw new NotImplementedException();
        }

        public Task Publish(string channel,
                            object message)
        {
            throw new NotImplementedException();
        }
    }
}