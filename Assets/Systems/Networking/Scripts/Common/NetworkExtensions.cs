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
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Networking
{
    public static class NetworkExtensions
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        public static void CreatePacket(this NetworkClient client, NetworkEvent networkEvent)
        {
            (new List<NetworkClient> { client }, networkEvent).Send();
        }

        public static void CreatePacket(this NetworkClientsRuntimeSet clients, NetworkEvent networkEvent)
        {
            (clients.Items, networkEvent).Send();
        }

        public static void GenerateUniqueID(this NetworkClientsRuntimeSet clients, NetworkClient client)
        {
            while (true)
            {
                StringBuilder str = new StringBuilder();
                Enumerable
                    .Range(65, 26)
                    .Select(e => $"{(char)e}")
                    .Concat(Enumerable.Range(97, 26)
                        .Select(e => $"{(char)e}"))
                    .Concat(Enumerable.Range(0, 10)
                        .Select(e => $"{e}"))
                    .OrderBy(e => Guid.NewGuid())
                    .Take(11)
                    .ToList().ForEach(e => str.Append(e));
                string id = str.ToString();

                if (!clients.Items.Any(e => e.ID == id))
                {
                    client.ID = id;
                    return;
                }
            }
        }

        public static void Send(this (List<NetworkClient> clients, NetworkEvent networkEvent) info, params object[] data)
        {
            using(Packet packet = new Packet(info.networkEvent.ID))
            {
                info.networkEvent.SendMethod.Invoke(packet, data);
            }
        }

        public static void Send(this Packet packet)
        {

        }

        #endregion

        #region Private Methods

        #endregion        
    } 
}