using Goedel.Mesh;
using Goedel.Presence;

namespace Goedel.XUnit;

public class ContextPresenceTest : ContextPresence {
    //public int Skip { get; set; }
    //public int Stride { get; set; }

    //public int Count { get; set; } = 0;

    CommunicationDisruptor CommunicationDisruptor { get; set; }


    public ContextPresenceTest(

            ContextUser contextUser,
            ServiceAccessToken serviceAccessToken,
            CommunicationDisruptor communicationDisruptor) :
        base(contextUser, serviceAccessToken) {
        CommunicationDisruptor = communicationDisruptor;
        HeartbeatMilliSeconds = communicationDisruptor.HeartbeatMilliSeconds;
        RetransmitHeartbeatMilliSeconds = communicationDisruptor.RetransmitHeartbeatMilliSeconds;
        }


    protected override void SendData(PresenceFromClient message, byte[] token) {
        if (CommunicationDisruptor.DoSend()) {
            base.SendData(message, token);
            }

        }


    }
