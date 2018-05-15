using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;

namespace Goedel.Cryptography.KeyFile {

    /// <summary>
    /// Read a PEM style private key file (unencrypted)
    /// </summary>
    public partial class KeyFileLex {
        int Armor1 = 0;
        int Armor2 = 0;
        int Armor3 = 0;
        int Armor4 = 0;

        StringBuilder BuildTag1 = new StringBuilder();
        StringBuilder BuildTag2 = new StringBuilder();
        StringBuilder BuildBase64 = new StringBuilder();

        StringBuilder BuildHeader = new StringBuilder();

        /// <summary>List of headers</summary>
        public List<Header> Headers = new List<Header>();
        Header CurrentHeader;

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Reset(int c) {
            }

        /// <summary>
        /// Count the inital staring armor tag
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Count1(int c) {
            Armor1++;
            }

        /// <summary>
        /// Count the inital finishing armor tag;
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Count2(int c) {
            Armor2++;
            }

        /// <summary>
        /// Count the final staring armor tag;
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Count3(int c) {
            Armor3++;
            }

        /// <summary>
        /// Count the final finishing armor tag;
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Count4(int c) {
            Armor4++;
            }

        /// <summary>
        /// Record the initial item description
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Tag1(int c) {
            if (!c.IsWhite()) {
                BuildTag1.Append(c.ToASCII());
                }
            }

        /// <summary>
        /// Record the encoded data
        /// </summary>
        /// <param name="c">Character that was read</param> 
        public virtual void Base64(int c) {
            if (c.IsBase64()) {
                BuildBase64.Append(c.ToASCII());
                }
            }

        /// <summary>
        /// Record the final item description
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Tag2(int c) {
            if (!c.IsWhite()) {
                BuildTag2.Append(c.ToASCII());
                }
            }


        StringBuilder BuildTagBegin = new StringBuilder();

        /// <summary>
        /// Verify the initial BEGIN tag
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void Begin(int c) {
            if (!c.IsWhite()) {
                BuildTagBegin.Append(c.ToASCII());
                }
            }

        StringBuilder BuildTagEnd = new StringBuilder();
        /// <summary>
        /// Verify the final End tag
        /// </summary>
        /// <param name="c">Character that was read</param>
        public virtual void End(int c) {
            if (!c.IsWhite()) {
                BuildTagEnd.Append(c.ToASCII());
                }
            }

        /// <summary>
        /// Add character to tag
        /// </summary>
        /// <param name="c">Character value to add</param>
        public virtual void AddTag(int c) {
            }

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c">Character value read</param>
        public virtual void Abort(int c) {
            }


        StringBuilder BuildHeaderValue = new StringBuilder();
        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c">Character value read</param>
        public virtual void StartHeader(int c) {
            CurrentHeader = new Header() {
                Tag = BuildBase64.ToString()
                };
            Headers.Add(CurrentHeader);
            BuildBase64.Clear();
            }

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c">Character value read</param>
        public virtual void HeaderAdd(int c) {
            BuildHeaderValue.Append(c.ToASCII());
            }

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c">Character value read</param>
        public virtual void CopyHeader(int c) {
            CurrentHeader.Value = BuildHeaderValue.ToString();
            BuildHeaderValue.Clear();
            }




        /// <summary>
        /// Process tagged data
        /// </summary>
        /// <returns>Summary of tagged data.</returns>
        public TaggedData GetTaggedData() {
            bool Strict = Armor1 == Armor2 & Armor1 == Armor3 &
                Armor1 == Armor4;
            string Tag = BuildTag1.ToString();

            Strict &= Tag == BuildTag2.ToString() & BuildTagBegin.ToString() == "BEGIN" &
                BuildTagEnd.ToString() == "END";

            var Base64Data = BuildBase64.ToString();
            var Data = BaseConvert.FromBase64(Base64Data);

            var Result = new TaggedData {
                Strict = Strict,
                Count = Armor1,
                Tag = Tag,
                Data = Data,
                Headers = Headers};

            return Result;
            }

        }

    /// <summary>Tagged data from file</summary>
    public class TaggedData {
        /// <summary>If true the file is strictly compliant with the PEM spec,
        /// the number of dashes at the start and end of the header and footer
        /// armor match.</summary>
        public bool Strict;
        /// <summary>Number of dashes counted</summary>
        public int Count;
        /// <summary>The tag (excluding BEGIN or END)</summary>
        public string Tag;
        /// <summary>The tagged data converted from Base64.</summary>
        public byte[] Data;

        /// <summary>Listy of header values</summary>
        public List<Header> Headers;
        }

    /// <summary>Header value</summary>
    public class Header {

        /// <summary>The header tag</summary>
        public string Tag;

        /// <summary>The header value</summary>
        public string Value;


        }

    }
