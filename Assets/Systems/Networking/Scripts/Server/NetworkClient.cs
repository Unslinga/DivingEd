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
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Networking
{
    [Serializable]
    public class NetworkClient : IDisposable
    {
        public const int BUFFER_SIZE = 4096;

        #region Fields
        
        private NetworkStream stream;
        private byte[] receiveBuffer;

        #endregion

        #region Constructor

        public NetworkClient(Server server, TcpClient client)
        {
            Server = server;
            Client = client;

            Client.ReceiveBufferSize = BUFFER_SIZE;
            Client.SendBufferSize = BUFFER_SIZE;

            receiveBuffer = new byte[BUFFER_SIZE];

            stream = client.GetStream();

            stream.BeginRead(receiveBuffer, 0, BUFFER_SIZE, TCPReceiveCallback, null);
        }

        ~NetworkClient()
        {
            if (Client != null)
            {
                Client.Close();
            }

            stream = null;
            receiveBuffer = null;
            Client = null;

            Dispose();
        }

        #endregion

        #region Properties
        
        [field: Header("Client Info")]
        [field: ReadOnlyField]
        [field: SerializeField]
        public string Name { get; set; }

        [field: ReadOnlyField]
        [field: SerializeField]
        public string ID { get; set; }

        public Server Server { get; set; }

        public TcpClient Client { get; private set; } = null;

        #endregion

        #region Public Methods

        public void Dispose()
        {
            Server.NetworkClientSet.Remove(this);
        }

        public void SendData(Packet packet)
        {
            try
            {
                stream.BeginWrite(packet.Buffer, 0, packet.Length, null, null);
            }
            catch (Exception e)
            {
                Debug.LogError($"Network Client [{ID}, {Name}]: {e}");
                Dispose();
            }
        }

        #endregion

        #region Private Methods

        private void TCPReceiveCallback(IAsyncResult result)
        {
            try
            {
                int length = stream.EndRead(result);

                if (length <= 0)
                {
                    Dispose();
                    return;
                }

                stream.BeginRead(receiveBuffer, 0, BUFFER_SIZE, TCPReceiveCallback, null);

                byte[] data = new byte[length];

                Array.Copy(receiveBuffer, data, length);

                using (Packet packet = new Packet(data))
                {
                    Server.NetworkEventSet[packet.ReadInt()].Raise((ID, packet));
                }

            }
            catch (Exception)
            {
                Dispose();
            }
        }

        #endregion
    }
}