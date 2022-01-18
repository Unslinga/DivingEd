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
        #endregion

        #region Properties

        [field: SerializeField]
        public IntReference ServerPort { get; set; }

        [field: SerializeField]
        public NetworkEventsNamedSet NetworkEventSet { get; set; }

        [field: SerializeField]
        public NetworkClientsRuntimeSet NetworkClientSet { get; set; }

        [field: Header("Server Info")]
        [field: SerializeField]
        public StringReference SessionName { get; set; }

        #endregion

        #region Network Methods

        public void OnInfo(Packet payload, object[] data)
        {
            payload.Write(SessionName.Value);
        }

        #endregion

        #region Private Methods

        private void ServerStart()
        {
            tcpListener = new TcpListener(IPAddress.Any, ServerPort);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectionCallback), null);

            Debug.Log($"Server started on [{ServerPort.Value}]");
        }

        private void TCPConnectionCallback(IAsyncResult result)
        {
            try
            {
                TcpClient client = tcpListener.EndAcceptTcpClient(result);
                tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectionCallback), null);

                Debug.Log("Server: Incoming Connection");

                using (NetworkClient networkClient = new NetworkClient(this, client))
                {
                    NetworkClientSet.GenerateUniqueID(networkClient);

                    NetworkClientSet.Add(networkClient);


                    networkClient.CreatePacket(NetworkEventSet["Server.Info"]);
                }
            }
            catch (NullReferenceException) { }
            catch (ObjectDisposedException) { }
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            this.Instance<Server>();

            this.CheckNull(NetworkEventSet, true);
            NetworkEventSet.ValidateList();

            this.CheckNull(NetworkClientSet, true);

            ServerStart();
        }

        #endregion
    }
}