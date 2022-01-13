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
        public NetworkEvents Events { get; set; }

        [field: SerializeField]
        public NetworkClientsRuntimeSet NetworkClients { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, ServerPort);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectionCallback), null);

            udpListener = new UdpClient(ServerPort);
            udpListener.BeginReceive(UDPReceibeCallback, null);

            Debug.Log($"Server started on [{ServerPort}]");

            Events["ServerStarted"]?.Raise();
        }

        private void TCPConnectionCallback(IAsyncResult result)
        {

        }

        private void UDPReceibeCallback(IAsyncResult ar)
        {

        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            this.Instance<Server>();
            this.CheckNull(Events, true);
            this.CheckNull(NetworkClients, true);


            //if (NetworkClients == null)
            //{
            //    Debug.LogError($"NetworkClients RuntimeSet not set in inspector in [{gameObject.name}]");
            //    this.Quit();
            //}

            //StartServer();

        }

        private void Update()
        {
            
        }

        #endregion
        
    } 
}