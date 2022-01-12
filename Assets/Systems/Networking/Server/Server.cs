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
        //public NetworkEvents Events { get; set; }

        [field: SerializeField]
        public int ServerPort { get; set; } = 55676;

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

            //Events.ServerStarted.Raise();
        }

        private void TCPConnectionCallback(IAsyncResult result)
        {

        }

        private void UDPReceibeCallback(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            this.Instance<Server>();

            //if (NetworkClients == null)
            //{
            //    Debug.LogError($"NetworkClients RuntimeSet not set in inspector in [{gameObject.name}]");
            //    this.Quit();
            //}
        }

        private void Update()
        {
            
        }
        #endregion
        
    } 
}