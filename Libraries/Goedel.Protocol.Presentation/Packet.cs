using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;
using System.Threading.Tasks;

namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Base class for packet classes.
    /// </summary>
    public class Packet {
        ///<summary>The packet payload.</summary> 
        public byte[] Payload { get; set; }

        ///<summary>The source address and port.</summary> 
        public PortId SourcePortId;

        ///<summary>Options specified in the packet plaintext.</summary> 
        public List<PacketExtension> PlaintextExtensions { get; set; }

        }

    }
