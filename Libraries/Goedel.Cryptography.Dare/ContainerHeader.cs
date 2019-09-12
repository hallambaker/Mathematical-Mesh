using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {
    //public partial class ContainerHeaderFirst {

    //    /// <summary>
    //    /// Default constructor. Specifies an index value of 0.
    //    /// </summary>
    //    public ContainerHeaderFirst() : base() => Index = 0;
    //    }


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


        ///// <summary>
        ///// Create a container header from the specified DareHeader copying over only the parts that
        ///// are common to the envelope and the container.
        ///// </summary>
        ///// <param name="dareHeader"></param>
        //public DareHeader(DareHeader dareHeader) {
        //    Cloaked = dareHeader.Cloaked;
        //    ContentInfoData = dareHeader.ContentInfoData;
        //    EDSS = dareHeader.EDSS;
        //    Signers = dareHeader.Signers;
        //    Recipients = dareHeader.Recipients;
        //    }


        ///// <summary>
        ///// Apply the specified cryptographic options.
        ///// </summary>
        ///// <param name="CryptoStack">The cryptographic enhancements to apply.</param>
        ///// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        ///// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        /////     as an EDSS header entry.</param>
        //public override void ApplyCryptoStack (
        //            CryptoStack CryptoStack,
        //            byte[] Cloaked = null,
        //            List<byte[]> DataSequences = null) {
        //    base.ApplyCryptoStack(CryptoStack, Cloaked, DataSequences);

        //    if (CryptoStack.FrameIndex >= 0) {
        //        ExchangePosition = CryptoStack.FrameIndex;
        //        }
        //    else {
        //        CryptoStack.FrameIndex = Index;
        //        }

        //    }




        }


    }
