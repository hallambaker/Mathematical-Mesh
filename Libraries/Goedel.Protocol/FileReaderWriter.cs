using System;
using System.IO;

namespace Goedel.Protocol {
    // This implementation accesses the file directly.

    /// <summary>
    /// Character stream from file
    /// </summary>
    public class FileCharacterTextStream : CharacterTextStream {
        FileStream Source;

        /// <summary>
        /// Mark the current reader position.
        /// </summary>
        public override void Mark() {
            MarkPosition = Source.Position;
            MarkBuffer = Buffer;
            }

        /// <summary>
        /// Restore reader to previous reader position.
        /// </summary>
        public override void Restore() {
            if (MarkPosition >= 0) {
                Source.Seek(MarkPosition, SeekOrigin.Begin);
                Buffer = MarkBuffer;
                }
            }

        /// <summary>
        /// Construct from file stream.
        /// </summary>
        /// <param name="FileStream">Input file.</param>
        public FileCharacterTextStream(FileStream FileStream) {
            this.Source = FileStream;
            }

        /// <summary>
        /// Read a character.
        /// </summary>
        /// <returns>The character value.</returns>
        protected override int ReadChar() {
            var C1 = Source.ReadByte();
            if (C1 < 0) {
                _EOF = true;
                }
            return C1;
            }

        }

   }
