using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Goedel.Mesh {

    /// <summary>
    /// Enumeration of file formats recognized by the Mesh support library.
    /// </summary>
    public enum CatalogedEntryFormat {
        ///<summary>Dare enveloped format.</summary>
        Dare,

        ///<summary>Mesh JSON contact exchange</summary>
        Mjcx,

        ///<summary>Mesh JSON password exchange</summary>
        Mjpx,

        ///<summary>Mesh JSON task exchange</summary>
        Mjtx,

        ///<summary>Mesh JSON bookmark exchange</summary>
        Mjbx,

        ///<summary>Mesh JSON log exchange</summary>
        Mjlx,

        ///<summary>Mesh JSON network exchange</summary>
        Mjnx,

        ///<summary>Mesh JSON application exchange</summary>
        Mjax,

        ///<summary>Mesh JSON device exchange</summary>
        Mjdx,



        ///<summary>PKCS#7 enveloped format.</summary>
        Pkcs7,

        ///<summary>ICal format</summary>
        Ical,

        ///<summary>VCard format</summary>
        VCard,

        ///<summary>PEM public key format</summary>
        PemPublicKey,

        ///<summary>PEM private key format</summary>
        PemPrivateKey,

        ///<summary>PKCS#12 / PFX format</summary>
        Pkcs12,

        ///<summary>Unknown format type.</summary>
        Unknown,

        ///<summary>Default format type.</summary>
        Default
        }


    public partial class CatalogedEntry {

        /// <summary>
        /// Describe the entry, appending the output to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The output stream.</param>
        /// <param name="detail">If true, provide a detailed description.</param>
        public virtual void Describe(StringBuilder builder, bool detail = false) => builder.AppendLine(_Tag);


        // need to create a static method.

        //public virtual CatalogedEntry FromFile(
        //            string filename,
        //            CatalogedEntryFormat entryFormat
        //            ) {
        //    }


        /// <summary>
        /// Add the catalog entry to the stream <paramref name="stream"/> in the
        /// format specified by <paramref name="format"/>.
        /// </summary>
        /// <param name="stream">The stream to write the data to.</param>
        /// <param name="format">The file format to write the output in.</param>

        /// <returns></returns>
        public virtual void WriteToStream(
                    Stream stream,
                    CatalogedEntryFormat format = CatalogedEntryFormat.Default) {

            switch (format) {
                case CatalogedEntryFormat.Default: {
                    var writer = new JSONWriter(stream);
                    Serialize(writer, true);
                    return;
                    }
                }



            throw new InvalidFormat(args: format);
            }



        }
    }
