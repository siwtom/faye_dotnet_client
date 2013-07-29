﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Bsw.FayeDotNet.Client;
using Bsw.FayeDotNet.Messages;
using Bsw.WebSocket4NetSslExt.Socket;
using FluentAssertions;
using MsbwTest;
using Newtonsoft.Json;
using NUnit.Framework;

#endregion

namespace Bsw.FayeDotNet.Test.Client
{
    [TestFixture]
    public class FayeClientTest : BaseTest
    {
        #region Test Fields

        private IWebSocket _websocket;
        private List<string> _messagesSent;
        private IFayeClient _fayeClient;

        #endregion

        #region Setup/Teardown

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _messagesSent = new List<string>();
            _fayeClient = null;
            _websocket = null;
        }

        #endregion

        #region Utility Methods

        private void InstantiateFayeClient()
        {
            _fayeClient = new FayeClient(_websocket);
        }

        private void SetupWebSocket(IWebSocket webSocket)
        {
            _websocket = webSocket;
        }

        private static string GetHandshakeResponse(bool successful = true)
        {
            var response =
                new
                {
                    channel = HandshakeRequestMessage.HANDSHAKE_MESSAGE,
                    version = HandshakeRequestMessage.BAYEUX_VERSION_1,
                    successful
                };
            return JsonConvert.SerializeObject(response);
        }

        #endregion

        #region Tests

        [Test]
        public async Task Connect_wrong_connectivity_info()
        {
            // arrange
            SetupWebSocket(new WebSocketClient(uri: "ws://foobar:8000"));
            InstantiateFayeClient();

            // act + assert
            var result = await _fayeClient.InvokingAsync(t => t.Connect())
                                          .ShouldThrow<Exception>();
            result.Message
                  .Should()
                  .Be("Websocket couldn't connect, TBD");
        }

        [Test]
        public async Task Connect_websocketopens_but_handshake_fails()
        {
            // arrange
            var mockSocket = new MockSocket
                             {
                                 OpenedAction = handler =>
                                                {
                                                    Thread.Sleep(100);
                                                    handler.Invoke(this,
                                                                   new EventArgs());
                                                },
                                 MessageReceiveAction = () =>
                                                        {
                                                            Thread.Sleep(100);
                                                            return GetHandshakeResponse(successful: false);
                                                        }
                             };
            
            SetupWebSocket(mockSocket);
            InstantiateFayeClient();

            // act + assert
            var result = await _fayeClient.InvokingAsync(t => t.Connect())
                                          .ShouldThrow<HandshakeException>();
            result.Message
                  .Should()
                  .Be("Handshaking with server failed.  Response from server was: foobar");
        }

        [Test]
        public async Task Connect_websocketopens_but_handshake_times_out()
        {
            // arrange
            var mockSocket = new MockSocket
                             {
                                 OpenedAction = handler =>
                                                {
                                                    Thread.Sleep(100);
                                                    handler.Invoke(this,
                                                                   new EventArgs());
                                                }
                             };
            
            SetupWebSocket(mockSocket);
            InstantiateFayeClient();
            _fayeClient.HandshakeTimeout = 150.Milliseconds();

            // act
            var result = await _fayeClient.InvokingAsync(t => t.Connect())
                                          .ShouldThrow<HandshakeException>();

            // assert
            result.Message
                  .Should()
                  .Be("Timed out at 150 milliseconds waiting for server to respond to handshake request.");
        }

        [Test]
        public async Task Connect_handshake_completes_ok()
        {
            // arrange

            // act

            // assert
            Assert.Fail("write test");
        }

        [Test]
        public async Task Disconnect()
        {
            // arrange

            // act

            // assert
            Assert.Fail("write test");
        }

        [Test]
        public async Task Connect_lost_connection_retry_happens_properly()
        {
            // arrange

            // act

            // assert
            Assert.Fail("write test");
        }

        [Test]
        public async Task Subscribe()
        {
            // arrange

            // act

            // assert
            Assert.Fail("write test");
        }

        [Test]
        public async Task Unsubscribe()
        {
            // arrange

            // act

            // assert
            Assert.Fail("write test");
        }

        [Test]
        public async Task Publish()
        {
            // arrange

            // act

            // assert
            Assert.Fail("write test");
        }

        #endregion
    }
}