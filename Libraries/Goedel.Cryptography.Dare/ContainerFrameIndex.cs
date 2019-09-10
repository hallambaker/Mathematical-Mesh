using System;
using System.IO;
using System.Collections.Generic;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;

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

        /////<summary>The first byte of the data segment (excluding the length indicator)</summary>
        //public long FramePosition;

        ///<summary>The first byte of the data segment (excluding the length indicator)</summary>
        public long DataPosition;

        ///<summary>The length of the data segment.</summary>
        public long DataLength;

        ///<summary>If true, the frame has a payload section</summary>
        public bool HasPayload => throw new NYI();

        KeyCollection KeyCollection;

        ///<summary>The envelope body</summary>
        public byte[] Payload => GetPayLoad().CacheValue(out payload);
        byte[] payload;

        public JSONObject JSONObject;

        JBCDStream JBCDStream;

        public byte[] GetPayLoad() {

            

            using (var input = JBCDStream.FramerGetReader(DataPosition, DataLength)) {

                var Decoder = Header.GetDecoder(
                            input, out var Reader,
                            KeyCollection: KeyCollection);

                using (var output = new MemoryStream()) {
                    Reader.CopyTo(output);
                    return output.ToArray();
                    }


                }
            }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jsonStream">Stream reader positioned to the start of the frame.</param>
        public ContainerFrameIndex(JBCDStream jsonStream, KeyCollection keyCollection, long Position = -1) {

            KeyCollection = keyCollection;
            JBCDStream = jsonStream;

            var length = jsonStream.FramerOpen(Position);

            var HeaderBytes = jsonStream.FramerGetData();
            var HeaderText = HeaderBytes.ToUTF8();
            Header = DareHeader.FromJSON(HeaderBytes.JSONReader(), false);

            jsonStream.FramerGetFrameIndex(out DataPosition, out DataLength);

            //Payload = JBCDStream.FramerGetData();

            //using (var Buffer = new MemoryStream()) {
            //    var Decoder = Header.GetDecoder(
            //                jsonReader, out var Reader,
            //                KeyCollection: keyCollection);
            //    Reader.CopyTo(Buffer);
            //    Decoder.Close();
            //    Payload= Buffer.ToArray();
            //    }

            var TrailerBytes = jsonStream.FramerGetData();
            if (TrailerBytes != null && TrailerBytes.Length > 0) {
                var TrailerText = TrailerBytes.ToUTF8();
                Trailer = DareTrailer.FromJSON(TrailerText.JSONReader(), false);
                }


            //if (Payload != null && Payload.Length > 0) {
            //    //var PayloadText = HeaderBytes.ToUTF8();
            //    //JSONObject = Payload.JSONReader().ReadTaggedObject(JSONObject.TagDictionary);

            //    }
            }


        public JSONObject GetJSONObject(Container container) =>
            Payload.JSONReader().ReadTaggedObject(JSONObject.TagDictionary);

            //GetReader(container).ReadTaggedObject(JSONObject.TagDictionary);


        /// <summary>
        /// Return a JSONReader for the content
        /// </summary>
        /// <param name="container">The indexed containerG.</param>
        /// <returns></returns>
        public JSONReader GetReader(Container container) => throw new NYI();

        /// <summary>
        /// Return the frame payload verbatim (i.e. ciphertext if encrypted).
        /// </summary>
        /// <param name="container">The indexed container.</param>
        /// <returns>The frame payload</returns>
        public byte[] GetData(Container container) => throw new NYI();


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
                Body = GetData(container)
                };

            if (!detatched | !Header.HasExchangePosition) {
                Header.Recipients = GetRecipients(container);
                }


            return envelope;

            }

        List<DareRecipient> GetRecipients (Container container) {
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


        public void CopyToFile(string file) {
            throw new NYI();
            }

        }





    }
