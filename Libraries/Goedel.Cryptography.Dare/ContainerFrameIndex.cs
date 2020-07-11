﻿using Goedel.Protocol;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;

namespace Goedel.Cryptography.Dare {

    ///<summary>Describe the integrity checking to be applied when reading a container.</summary>
    public enum ContainerIntegrity {
        ///<summary>Do not perform integrity checks.</summary>
        None,

        ///<summary>Check that the digest values specified in the headers and trailers are
        ///consistent with the payload digest value specified. Do not verify the payload digest 
        ///value.</summary>
        Trailer,

        ///<summary>Check that the digest values specified in the headers and trailers are
        ///consistent with the payload digest value specified and verify the payload digest 
        ///value against the payload contents.</summary>
        Full


        }

    /// <summary>
    /// Container index with the decoded head and tail and extent information for
    /// the body.
    /// </summary>
    public partial class ContainerFrameIndex {

        ///<summary>The frame header</summary>
        public DareHeader Header;

        ///<summary>The frame trailer</summary>
        public DareTrailer Trailer;

        ///<summary>The first byte of the data segment (excluding the length indicator)</summary>
        public long dataPosition;

        ///<summary>The length of the data segment.</summary>
        public long DataLength;

        ///<summary>If true, the frame has a payload section</summary>
        public bool HasPayload => throw new NYI();

        ///<summary>The decoded JSONObject</summary>
        public JsonObject JSONObject;


        JbcdStream jbcdStream;

        /// <summary>
        /// Return the frame payload.
        /// </summary>
        /// <returns>The frame payload data.</returns>
        public byte[] GetPayload(IKeyLocate keyCollection) {
            using var input = jbcdStream.FramerGetReader(dataPosition, DataLength);
            var Decoder = Header.GetDecoder(input, out var Reader,
                        keyCollection: keyCollection);

            using var output = new MemoryStream();
            Reader.CopyTo(output);
            return output.ToArray();
            }

        /// <summary>
        /// Constructor returning an instance for the envelope <paramref name="envelope"/>.
        /// </summary>
        /// <param name="envelope">The envelope to return an index for.</param>
        public ContainerFrameIndex(DareEnvelope envelope) {
            Header = envelope.Header;
            Trailer = envelope.Trailer;
            JSONObject = envelope.JSONObject;
            if (envelope.Body != null) {
                DataLength = envelope.Body.Length;
                }
            }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jsonStream">Stream reader positioned to the start of the frame.</param>
        /// <param name="keyCollection">The key collection to be used to obtain the decryption 
        /// key for the payload.</param>
        /// <param name="Position">The position in the file.</param>
        public ContainerFrameIndex(JbcdStream jsonStream, IKeyLocate keyCollection, long Position = -1) {

            //this.keyCollection = keyCollection;
            jbcdStream = jsonStream;

            var length = jsonStream.FramerOpen(Position);

            var HeaderBytes = jsonStream.FramerGetData();
            var HeaderText = HeaderBytes.ToUTF8();
            Header = DareHeader.FromJson(HeaderBytes.JsonReader(), false);

            jsonStream.FramerGetFrameIndex(out dataPosition, out DataLength);

            var TrailerBytes = jsonStream.FramerGetData();
            if (TrailerBytes != null && TrailerBytes.Length > 0) {
                var TrailerText = TrailerBytes.ToUTF8();
                Trailer = DareTrailer.FromJson(TrailerText.JsonReader(), false);
                }
            }

        /// <summary>
        /// Read the payload data from the specified position in <paramref name="container"/>
        /// and deserialize to return the corresponding object.
        /// </summary>
        /// <param name="container">The container that was indexed.</param>
        /// <returns>The deserialized object.</returns>
        public JsonObject GetJSONObject(Container container) => JSONObject ??
            GetPayload(container.KeyLocate).JsonReader().ReadTaggedObject(JsonObject.TagDictionary);

        /// <summary>
        /// Return a JSONReader for the content
        /// </summary>
        /// <param name="container">The indexed containerG.</param>
        /// <returns></returns>
        public JsonReader GetReader(Container container) => throw new NYI();

        /// <summary>
        /// Return the frame payload verbatim (i.e. ciphertext if encrypted).
        /// </summary>
        /// <param name="container">The indexed container.</param>
        /// <returns>The frame payload</returns>
        public byte[] GetBody(Container container) {
            using var input = container.JBCDStream.FramerGetReader(dataPosition, DataLength);
            using var output = new MemoryStream();
            input.CopyTo(output);
            return output.ToArray();

            }


        /// <summary>
        /// Return a DareEnvelope wrapping the fnewrame.
        /// </summary>
        /// <param name="container">The indexed container.</param>
        /// <param name="detatched">If true, </param>
        /// <returns>The frame payload</returns>      
        public DareEnvelope GetEnvelope(Container container, bool detatched = false) {
            var envelope = new DareEnvelope() {
                Header = Header,
                Trailer = Trailer,
                Body = GetBody(container)
                };

            if (!detatched | !Header.HasExchangePosition) {
                Header.Recipients = GetRecipients(container);
                }


            return envelope;

            }

        List<DareRecipient> GetRecipients(Container container) {
            if (!Header.HasExchangePosition) {
                return Header.Recipients;
                }
            var exchangeHeader = container.GetHeader(Header.ContainerInfo.ExchangePosition);

            if (Header.Recipients == null) {
                return exchangeHeader.Recipients;
                }
            else {
                // Not yet decided if it should be permissable to specify a previous exchange
                // and a current one.
                throw new NYI();
                }

            }

        /// <summary>
        /// Copy the payload data to file.
        /// </summary>
        /// <param name="file"></param>
        public void CopyToFile(string file) => throw new NYI();

        }





    }
