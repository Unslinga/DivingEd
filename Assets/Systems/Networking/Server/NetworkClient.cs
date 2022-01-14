// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace Networking
{
    public class NetworkClient : MonoBehaviour
    {
        public const int BUFFER_SIZE = 4096;

        #region Fields
        
        private NetworkStream stream;
        private byte[] receiveBuffer;
        private Packet receivedPacket;

        #endregion

        #region Properties

        [field: SerializeField]
        public NetworkEventsNamedSet NetworkEvents { get; set; }

        [field: SerializeField]
        public StringReference ServerName { get; set; }

        [field: SerializeField]
        public string Name { get; set; }

        public TcpClient Client { get; private set; } = null;

        #endregion

        #region Public Methods

        public void Connect(TcpClient client)
        {
            Client = client;

            Client.ReceiveBufferSize = BUFFER_SIZE;
            Client.SendBufferSize = BUFFER_SIZE;

            stream = Client.GetStream();

            receivedPacket = new Packet();
            receiveBuffer = new byte[BUFFER_SIZE];

            stream.BeginRead(receiveBuffer, 0, receiveBuffer.Length, receiveCallback, null);

            Debug.Log("Server: Sending Welcome Packet");
            NetworkEvents["Server.Welcome"]?.Send(ServerName.Value);
        }

        #endregion

        #region Private Methods

        private void receiveCallback(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        #endregion

    } 
}