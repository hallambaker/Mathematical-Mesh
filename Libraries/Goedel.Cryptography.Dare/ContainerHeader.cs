namespace Goedel.Cryptography.Dare {


    public partial class SequenceInfo {
        ///<summary>If true, the field ExchangePosition is specified</summary>
        public bool HasExchangePosition() => __ExchangePosition;
        }

    public partial class DareHeader {


        ///<summary>The container index value.</summary>
        public int Index => SequenceInfo.Index;


        ///<summary>If true, the field ExchangePosition is specified</summary>
        public bool HasExchangePosition => SequenceInfo.HasExchangePosition();
        // Should get rid of these and use nullable types.




        }


    }
