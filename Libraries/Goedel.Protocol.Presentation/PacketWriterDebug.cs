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
//  

using Goedel.Utilities;

using System;
using System.Collections.Generic;


namespace Goedel.Protocol.Presentation {
    public class PacketWriterDebug : PacketWriter {





        #region // Properties


        #endregion

        #region // Destructor
        #endregion

        #region // Constructors

        /// <summary>
        /// Constructor creating an instance of <see cref="PacketWriterDebug"/>
        /// </summary>
        /// <param name="packetSize">The number of bytes in the packet to be created.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        public PacketWriterDebug(
                    PacketWriter parent = null,
                    byte[] buffer = null,
                    int position = 0) : base(parent, buffer, position) {
            Debug("");
            Debug("");
            Debug("---Start");
            if (position > 0) {
                Debug($"Inner buffer start:{position} bytes{Packet.Length}");
                }
            }

        /// <summary>
        /// Factory method returning instance of <see cref="PacketWriterDebug"/>
        /// </summary>
        /// <param name="packetSize">The number of bytes in the packet to be created.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The created instance.</returns>
        public static new PacketWriter Factory(
            PacketWriter parent = null,
            byte[] buffer = null,
            int position = 0) => new PacketWriterDebug(parent, buffer, position);


        #endregion 
        #region // Methods 


        int positionDebug;

        /// <summary>
        /// Stub method to write debug output to the screeen for now, change this to
        /// write to the documentation.
        /// </summary>
        /// <param name="text"></param>

        void Debug(string text=null) {
            Screen.WriteLine(text?? "");
            positionDebug = Position;
            }

        void DebugBytes() {
            for (; positionDebug < Position; positionDebug++) {
                Screen.Write($"{Packet[positionDebug]:X2} ");


                }
            Screen.WriteLine();

            }


        ///<inheritdoc/>
        public override void WriteStreamId(byte[] data) {
            Debug("Stream Id");
            base.WriteStreamId(data);
            DebugBytes();
            }
        
        ///<inheritdoc/>
        public override void Write(InitiatorMessageType b) {
            Debug($"InitiatorMessageType {b}");
            base.Write(b);
            DebugBytes();
            }

        ///<inheritdoc/>
        public override void Write(ResponderMessageType b) {
            Debug($"ResponderMessageType {b}");
            base.Write(b);
            DebugBytes();
            }
        ///<inheritdoc/>
        public override void Write(int data) {
            Debug($"Integer: {data}");
            base.Write(data);
            DebugBytes();
            }
        ///<inheritdoc/>
        public override void Write(string data) {
            Debug($"String: {data ?? "<null>"}");
            base.Write(data);
            DebugBytes();
            }
        ///<inheritdoc/>
        public override void Write(byte[] data) {
            Debug($"Data");
            base.Write(data);
            DebugBytes();
            }
        ///<inheritdoc/>
        public override void WriteExtensions(List<PacketExtension> extensions = null) {
            Debug($"Extensions");
            base.WriteExtensions(extensions);
            DebugBytes();
            }

        ///<inheritdoc/>
        public override byte[] Wrap(byte[] streamId, byte[] key) => base.Wrap(streamId, key);


        ///<inheritdoc/>
        public override void Encrypt(byte[] key, PacketWriter writerIn, bool pad = true) {
            if (writerIn is PacketWriterDebug debug) {
                debug.Debug($"---- End");
                }


            if (pad) {
                Debug($"Encrypt {writerIn.Position} bytes key: {key.ToStringBase16()} with padding");
                }
            else {
                Debug($"Encrypt {writerIn.Position} bytes key: {key.ToStringBase16()} without padding");
                }
            base.Encrypt(key, writerIn, pad);


            DebugBytes();
            }

        #endregion 
        }

    }
