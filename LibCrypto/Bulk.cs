//Sample license text.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Goedel.LibCrypto {


    /// <summary>
    /// Base class for providers of bulk cryptographic algorithms, e.g. encryption,
    /// digest, authentication.
    /// </summary>
    public abstract class CryptoProviderBulk : CryptoProvider {
        /// <summary>
        /// Memory stream used in part processing mode.
        /// </summary>
        protected MemoryStream MemoryStream;

        /// <summary>
        /// Processes the specified region of the specified byte array
        /// </summary>
        /// <param name="Buffer">The input to process</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public abstract CryptoData Process(byte[] Buffer, int offset, int count) ;

        // Convenience routines

        /// <summary>
        /// Processes the specified byte array
        /// </summary>
        /// <param name="Buffer">The input to process</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public virtual CryptoData Process(byte[] Buffer) {
            return Process(Buffer, 0, Buffer.Length);
            }

        /// <summary>
        /// Processes the specified string in UTF8 encoding.
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public virtual CryptoData Process(string Data) {
            return Process(Encoding.UTF8.GetBytes(Data));
            }

        /// <summary>
        /// Processes the specified input data.
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public virtual CryptoData Process(CryptoData Data) {
            return Process(Data.Data);
            }


        /// <summary>
        /// Part processes the specified region of the specified byte array.
        /// 
        /// [Efficiency] Currently the data is buffered internally and processed in one go.
        /// Use of the underlying TransformBlock methods would allow for more 
        /// efficient processing and reduce memory overhead.
        /// </summary>
        /// <param name="Buffer">The input to process</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        public virtual void ProcessPart(byte[] Buffer, int offset, int count) {
            if (MemoryStream == null) {
                MemoryStream = new MemoryStream();
                }
            MemoryStream.Write(Buffer, offset, count);
            }

        /// <summary>
        /// Part processes the specified region of the specified byte array.
        /// </summary>
        /// <param name="Buffer">The input to process</param>
        public virtual void ProcessPart(byte[] Buffer) {
            ProcessPart(Buffer, 0, Buffer.Length);
            }

        /// <summary>
        /// Part processes the specified region of the specified string in UTF8 encoding.
        /// </summary>
        /// <param name="Data">The input to process</param>
        public virtual void ProcessPart(string Data) {
            ProcessPart(Encoding.UTF8.GetBytes(Data));
            }

        /// <summary>
        /// Terminates a part processing session and returns the result.
        /// </summary>
        /// <returns>The result of the cryptographic operation.</returns>
        public virtual CryptoData TransformFinal() {
            if (MemoryStream == null) {
                MemoryStream = new MemoryStream();
                }
            return Process(MemoryStream.GetBuffer(), 0, (int) MemoryStream.Position);
            }


        }
    }
