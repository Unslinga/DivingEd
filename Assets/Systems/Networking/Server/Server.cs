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
using System.Linq;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;

namespace Networking
{
    public class Server : MonoBehaviour
    {
        #region Fields
        private TcpListener tcpListener = null;
        private UdpClient udpListener = null;
        #endregion

        #region Properties

        [field: SerializeField]
        public IntReference ServerPort { get; set; }

        [field: SerializeField]
        public GameObject NetworkClientPrefab { get; set; }

        [field: SerializeField]
        public NetworkEventsNamedSet NetworkEventsSet { get; set; }

        [field: SerializeField]
        public NetworkClientsRuntimeSet NetworkClientsSet { get; set; }

        #endregion

        #region Public Methods

        public void OnTest(object[] data)
        {

        }

        #endregion

        #region Private Methods

        private void ServerStart()
        {
            tcpListener = new TcpListener(IPAddress.Any, ServerPort);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectionCallback), null);

            udpListener = new UdpClient(ServerPort);
            udpListener.BeginReceive(UDPReceibeCallback, null);

            Debug.Log($"Server started on [{ServerPort.Value}]");

            //NetworkEventsSet["Server.Started"]?.Raise();
            NetworkEventsSet["Server.Welcome"].Send(("Test", 2));
        }

        private void TCPConnectionCallback(IAsyncResult result)
        {
            try
            {
                TcpClient client = tcpListener.EndAcceptTcpClient(result);
                tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectionCallback), null);

                Debug.Log("Server: Incoming Connection");

                var clientObject = Instantiate(NetworkClientPrefab, transform);
                var networkClient = clientObject.GetComponent<NetworkClient>();

                this.CheckNull(networkClient, true);

                networkClient.Connect(client);
            }
            catch (NullReferenceException) { }
            catch (ObjectDisposedException) { }
        }

        private void UDPReceibeCallback(IAsyncResult ar)
        {

        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            this.Instance<Server>();

            this.CheckNull(NetworkClientPrefab, true);
            this.CheckNull(NetworkClientsSet, true);

            this.CheckNull(NetworkEventsSet, true);
            NetworkEventsSet.Initialize();

            ServerStart();
        }

        private void Update()
        {

        }

        #endregion
    }
}