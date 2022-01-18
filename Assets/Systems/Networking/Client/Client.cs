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
    public class Client : MonoBehaviour
    {
        public const int BUFFER_SIZE = 4096;

        #region Fields

        private NetworkStream stream;
        private byte[] receiveBuffer;

        #endregion

        #region Properties

        [field: SerializeField]
        public NetworkEventsNamedSet NetworkEvents { get; set; }

        [field: SerializeField]
        public StringReference PlayerName { get; set; }

        [field: SerializeField]
        public StringReference ConnectIP { get; set; }

        [field: SerializeField]
        public IntReference ServerPort { get; set; }

        [field: Header("ClientStatus")]

        [field: ReadOnlyField]
        [field: SerializeField]
        public bool Connected { get; private set; }

        [field: ReadOnlyField]
        [field: SerializeField]
        public string ID { get; private set; }

        public TcpClient NetworkClient { get; set; }

        #endregion

        #region Public Methods

        public void Connect()
        {
            if (Connected)
            {
                Debug.LogWarning("Client already connected.");
                return;
            }
                
            if (string.IsNullOrEmpty(ConnectIP.Value))
            {
                Debug.LogWarning("Server IP address missing!");
                return;
            }
               
            if (string.IsNullOrEmpty(PlayerName.Value))
            {
                Debug.LogWarning("Client name missing!");
                return;
            }

            NetworkClient = new TcpClient
            {
                ReceiveBufferSize = BUFFER_SIZE,
                SendBufferSize = BUFFER_SIZE
            };

            receiveBuffer = new byte[BUFFER_SIZE];

            NetworkClient.BeginConnect(ConnectIP, ServerPort, ConnectCallback, NetworkClient);
        }

        public void Disconnect()
        {

        }

        #endregion

        #region Private Methods

        private void ConnectCallback(IAsyncResult result)
        {
            NetworkClient.EndConnect(result);

            if (!NetworkClient.Connected)
            {
                Debug.LogWarning("Client: Could not connect to server.");
                return; 
            }

            stream = NetworkClient.GetStream();

            stream.BeginRead(receiveBuffer, 0, BUFFER_SIZE, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                int length = stream.EndRead(result);

                if (length <= 0)
                {
                    Disconnect();
                    return;
                }

                byte[] data = new byte[length];
                Array.Copy(receiveBuffer, data, length);

                using (Packet packet = new Packet(data))
                {
                    NetworkEvents[packet.ReadInt()].Raise((ID, packet));
                }
            }
            catch (Exception)
            {
                Disconnect();
            }
        }

        #endregion

        #region Server Methods

        private void OnWelcome(object packet)
        {

        }

        #endregion

        #region Unity Methods
        private void Start()
        {
            this.Instance<Client>();

            this.CheckNull(ConnectIP.Variable, false);
            this.CheckNull(PlayerName.Variable, false);

            NetworkEvents["Server.Info"].CreateListener(gameObject, OnWelcome);
        }

        private void Update()
        {
            
        }
        #endregion
        
    } 
}