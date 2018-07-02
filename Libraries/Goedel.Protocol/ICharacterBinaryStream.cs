namespace Goedel.Protocol {

    /// <summary>
    /// Character stream reader with methods to read individual characters, JSON
    /// escaped and base64 binary encoded strings.
    /// </summary>
    public interface ICharacterStream {

        /// <summary>If true, end of file has been reached. </summary>
        bool EOF { get; }

        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        char PeekChar();

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream</returns>
        char ReadChar();

        /// <summary>
        /// Read a complete JSON escape encoded string value encoded.
        /// </summary>
        /// <returns>The string value.</returns>
        string GetStringJSON();

        /// <summary>
        /// Read a complete base64 enccoded binary value.
        /// </summary>
        /// <returns>The string value.</returns>
        byte[] GetBinaryBase64();

        /// <summary>
        /// Get the next byte in the stream without advancing the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        byte PeekByte();

        /// <summary>
        /// Get the next byte in the stream and advance the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        byte ReadByte();
        }

    /// <summary>
    /// An IBinaryStream is a binary stream that exposes the ICharacterStream and
    /// provides binary read access;
    /// </summary>
    public interface IBinaryStream : ICharacterStream {
        /// <summary>
        /// If positive, contains the second character in a two character UTF16 character 
        /// sequence.
        /// </summary>
        int UTF16Shift { get; set; }




        /// <summary>
        /// Read a complete UTF8 string value.
        /// </summary>
        /// <param name="Length">The number of bytes to read.</param>
        /// <returns>The string that was read.</returns>
        string ReadStringUTF8(int Length);

        /// <summary>
        /// Read a complete binary value.
        /// </summary>
        /// <param name="Length">The number of bytes to read.</param>
        /// <returns>The binary data that was read.</returns>
        byte[] ReadBinary(int Length);
        }





    /// <summary>
    /// Interface allowing a character or binary stream reader to checkpoint the
    /// current point in the stream and return to it to re-read data.
    /// </summary>
    public interface IBufferedStream  {

        /// <summary>Create a restore point in the stream.</summary>
        void Mark();

        /// <summary>Return the stream to the position that the reader was at the last time
        /// Mark() was called.</summary>
        void Restore();


        }

    /// <summary>
    /// An ICharacterBufferedStream is an ICharacterStream that is also an IBufferedStream
    /// </summary>
    public interface ICharacterBufferedStream : ICharacterStream, IBufferedStream {
        }

    }