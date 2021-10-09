#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using System.Collections.Generic;

using Goedel.Utilities;

namespace Goedel.Protocol.Presentation {





    /// <summary>
    /// Packet options (to be specified).
    /// </summary>
    public struct PacketExtension {
        #region // Properties


        ///<summary>Registered extension tag</summary> 
        public string Tag;
        ///<summary>Extension value</summary> 
        public byte[] Value;
        #endregion
        #region // Methods 

        /// <summary>
        /// Convenience method scans the list <paramref name="packetExtensions"/> and returns the
        /// first matching the tag <paramref name="PrimaryTag"/>.
        /// </summary>
        /// <param name="packetExtensions">The extensions to scan. If this is a null pointer the
        /// null value is returned.</param>
        /// <param name="PrimaryTag">The tag to find.</param>
        /// <returns>The first value matching the specified tag if found, otherwise null.</returns>
        public static byte[] GetExtensionByTag(List<PacketExtension> packetExtensions, string PrimaryTag) {
            if (packetExtensions == null) {
                return null;
                }
            foreach (var extension in packetExtensions) {
                if (extension.Tag == PrimaryTag) {

                    return extension.Value;
                    }
                }
            return null;
            }

        /// <summary>
        /// Debug routine, print the tag value to the screen.
        /// </summary>
        public void Dump() {
            //Screen.WriteInfo($"    {Tag} -> {Value.ToStringBase16()}");
            }

        #endregion

        }


    /// <summary>
    /// Base class for packet classes.
    /// </summary>
    public class Packet {
        #region // Properties

        ///<summary>The packet payload.</summary> 
        public byte[] Payload { get; set; }

        ///<summary>The source address and port.</summary> 
        public byte[] SourceId;



        ///<summary>Options specified in the packet plaintext.</summary> 
        public List<PacketExtension> PlaintextExtensions { get; set; }

        #endregion
        #region // Methods 
        /// <summary>
        /// Debug output, remove for final release.
        /// </summary>
        public virtual void Dump() {
            if (PlaintextExtensions != null) {
                //Screen.WriteLine("Plaintext extensions");
                foreach (var extension in PlaintextExtensions) {
                    extension.Dump();
                    }
                }

            }
        #endregion
        }

    /// <summary>
    /// Packet data exchanged after negotiation has been completed.
    /// </summary>
    public class PacketData : Packet {
        #region // Properties
        ///<summary>Options specified in the packet ciphertext.</summary> 
        public List<PacketExtension> CiphertextExtensions { get; set; }

        #endregion

        }

    }
