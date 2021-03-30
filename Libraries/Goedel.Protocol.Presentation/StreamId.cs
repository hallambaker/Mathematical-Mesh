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
using System.Threading;
using System.Collections.Generic;
using Goedel.Utilities;

namespace Goedel.Protocol.Presentation {
    public struct StreamId {
        #region // Properties

        public const string PrimaryTag = "StreamId";


        static ulong counter = 0;

        public const int SourceIdSize = 8;

        public ulong Value { get; }




        public PacketExtension PacketExtension => new PacketExtension() {
            Tag = PrimaryTag,
            Value = Value.BigEndian ()
            };

        #endregion

        #region // Destructor
        #endregion

        #region // Constructors




        public StreamId(ulong value) {
            Value = value;
            }

        #endregion


        #region // Methods 

        public int WriteSourceId(byte[] buffer) {
            buffer.SetBigEndian(Value);
            return SourceIdSize;
            }

        /// <summary>
        /// Process the initial bytes of the buffer to get the source ID value according to the 
        /// source ID processing mode specified for the session.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>The retrieved sourceId and position in the buffer.</returns>
        public static (StreamId, int) GetSourceId(byte[] buffer) =>
            (new StreamId(buffer.BigEndianInt(StreamId.SourceIdSize)), StreamId.SourceIdSize);


        public static StreamId GetStreamId() =>
                new StreamId(Interlocked.Increment(ref counter));


        #endregion

        }





    }