namespace Goedel.XUnit;


public enum Disruption {

    None,

    Initial,

    Retry,

    Disconnect,

    Light,

    Heavy,
    }


public class CommunicationConditions {

    ///<summary>Disruption to packets sent by the service</summary> 
    public CommunicationDisruptor Service { get; init; } = 
            CommunicationDisruptor.None;

    ///<summary>Disruption to packets sent by Alice</summary> 
    public CommunicationDisruptor Alice { get; init; } =
            CommunicationDisruptor.None;

    ///<summary>Disruption to packets sent by Bob</summary> 
    public CommunicationDisruptor Bob { get; init; } =
            CommunicationDisruptor.None;

    ///<summary>No disruption to communications.</summary> 
    public static CommunicationConditions Normal => new ();


    ///<summary>No disruption to communications.</summary> 
    public static CommunicationConditions Fast => new() {
        Alice= CommunicationDisruptor.Fast,
        Bob= CommunicationDisruptor.Fast,
        };

    }


public class CommunicationDisruptor {

    public int HeartbeatMilliSeconds { get; init; } = 30_000;
    public int RetransmitHeartbeatMilliSeconds { get; init; } = 6_000;

    public int Skip { get; init; } = 0;
    public int Stride { get; init; } = 5;

    public int Count { get; set; } = 0;

    public static CommunicationDisruptor Fast => new() {
        HeartbeatMilliSeconds = 1000,
        RetransmitHeartbeatMilliSeconds = 200,
        };

    public static CommunicationDisruptor None => new ();

    public static CommunicationDisruptor Connected => new() {
        Skip = 1,
        Stride = 5
        };

    public static CommunicationDisruptor Disconnect => new() {
        Skip = 5,
        Stride = 5
        };

    public static CommunicationDisruptor Initial => new() {
        Skip = 1,
        Stride = 5,
        Count = 5
        };


    public bool DoSend() {
        if (Skip <= 0 || Count++ < Stride) {
            return true;
            }
        if (Count > Skip + Stride) {
            Count = 0;
            }
        return false;
        }

    }
