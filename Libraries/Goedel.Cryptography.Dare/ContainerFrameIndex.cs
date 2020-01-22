using Goedel.Protocol;
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

        /////<summary>The first byte of the data segment (excluding the length indicator)</summary>
        //public long FramePosition;

        ///<summary>The first byte of the data segment (excluding the length indicator)</summary>
        public long DataPosition;

        ///<summary>The length of the data segment.</summary>
        public long DataLength;

        ///<summary>If true, the frame has a payload section</summary>
        public bool HasPayload => throw new NYI();

        KeyCollection keyCollection;

        ///<summary>The envelope body</summary>
        public byte[] Payload => payload ?? GetPayLoad().CacheValue(out payload);
        byte[] payload;

        ///<summary>The decoded JSONObject</summary>
        public JSONObject JSONObject;


        JBCDStream jbcdStream;

        /// <summary>
        /// Return the frame payload.
        /// </summary>
        /// <returns>The frame payload data.</returns>
        public byte[] GetPayLoad() {
            using var input = jbcdStream.FramerGetReader(DataPosition, DataLength);
            var Decoder = Header.GetDecoder(input, out var Reader,
                        keyCollection: keyCollection);

            using var output = new MemoryStream();
            Reader.CopyTo(output);
            return output.ToArray();
            }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jsonStream">Stream reader positioned to the start of the frame.</param>
        /// <param name="keyCollection">The key collection to be used to obtain the decryption 
        /// key for the payload.</param>
        /// <param name="Position">The position in the file.</param>
        public ContainerFrameIndex(JBCDStream jsonStream, KeyCollection keyCollection, long Position = -1) {

            this.keyCollection = keyCollection;
            jbcdStream = jsonStream;

            var length = jsonStream.FramerOpen(Position);

            var HeaderBytes = jsonStream.FramerGetData();
            var HeaderText = HeaderBytes.ToUTF8();
            Header = DareHeader.FromJSON(HeaderBytes.JSONReader(), false);

            jsonStream.FramerGetFrameIndex(out DataPosition, out DataLength);

            var TrailerBytes = jsonStream.FramerGetData();
            if (TrailerBytes != null && TrailerBytes.Length > 0) {
                var TrailerText = TrailerBytes.ToUTF8();
                Trailer = DareTrailer.FromJSON(TrailerText.JSONReader(), false);
                }
            }

        /// <summary>
        /// Read the payload data from the specified position in <paramref name="container"/>
        /// and deserialize to return the corresponding object.
        /// </summary>
        /// <param name="container">The container that was indexed.</param>
        /// <returns>The deserialized object.</returns>
        public JSONObject GetJSONObject(Container container) =>
            Payload.JSONReader().ReadTaggedObject(JSONObject.TagDictionary);

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
        public byte[] GetBody(Container container) {
            using var input = container.JBCDStream.FramerGetReader(DataPosition, DataLength);
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
