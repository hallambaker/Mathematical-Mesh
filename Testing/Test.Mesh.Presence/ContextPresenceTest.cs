using Goedel.Presence.Client;
using Goedel.Mesh;
using Goedel.Presence;
using System.Net.Sockets;
using Goedel.Protocol.Presentation;
using System;
using Goedel.Mesh.Client;

namespace Goedel.XUnit;

public class ContextPresenceTest : ContextPresence {
    public int Skip { get; set; }
    public int Stride { get; set; }

    public int Count { get; set; } = 0;

    public ContextPresenceTest(ContextUser contextUser, 
            ServiceAccessToken serviceAccessToken) :
        base(contextUser, serviceAccessToken) {
        }


    protected override void SendData(PresenceFromClient message, byte[] token) {
        if (Skip <= 0 || Count++ < Stride) {
            base.SendData(message, token);
            return;
            }
        Console.WriteLine("Skip client");

        if (Count > Skip + Stride) {
            Count = 0;
            }
        }


    }
