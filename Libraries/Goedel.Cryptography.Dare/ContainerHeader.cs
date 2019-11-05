namespace Goedel.Cryptography.Dare {


    public partial class ContainerInfo {
        ///<summary>If true, the field ExchangePosition is specified</summary>
        public bool HasExchangePosition => __ExchangePosition;
        }

    public partial class DareHeader {

        ///// <summary>The container payload. Note that this is not a serialized field of the container
        ///// header.</summary>
        //public byte[] Payload;


        ///<summary>If true, the field ExchangePosition is specified</summary>
        public bool HasExchangePosition => ContainerInfo.HasExchangePosition;
        // Should get rid of these and use nullable types.




        }


    }
