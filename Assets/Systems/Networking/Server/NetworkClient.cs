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

        public string Name { get; set; }
        
        #endregion

        #region Public Methods

        public void Connect(TcpClient client)
        {

        }

        #endregion

        #region Private Methods

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