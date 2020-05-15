namespace Goedel.Cryptography.Dare {


    public partial class ContainerInfo {
        ///<summary>If true, the field ExchangePosition is specified</summary>
        public bool HasExchangePosition() => __ExchangePosition;
        }

    public partial class DareHeader {


        ///<summary>The container index value.</summary>
        public int Index => ContainerInfo.Index;


        ///<summary>If true, the field ExchangePosition is specified</summary>
        public bool HasExchangePosition => ContainerInfo.HasExchangePosition();
        // Should get rid of these and use nullable types.




        }


    }
