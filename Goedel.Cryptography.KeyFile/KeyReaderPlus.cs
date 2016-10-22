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
            BuildTag1.Append(c.ToASCII());
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
            BuildTag2.Append(c.ToASCII());
            }

        /// <summary>
        /// Verify the initial BEGIN tag
        /// </summary>
        /// <param name="c">Character that was read</param>
        StringBuilder BuildTagBegin = new StringBuilder();
        public virtual void Begin (int c) {
            BuildTagBegin.Append(c.ToASCII());
            }

        /// <summary>
        /// Verify the final End tag
        /// </summary>
        /// <param name="c">Character that was read</param>
        StringBuilder BuildTagEnd = new StringBuilder();
        public virtual void End(int c) {
            BuildTagEnd.Append(c.ToASCII());
            }


        public virtual void AddTag(int c) {
            }

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c"></param>
        public virtual void Abort(int c) {
            }


        public TaggedData GetTaggedData() {
            bool Strict = Armor1 == Armor2 & Armor1 == Armor3 &
                Armor1 == Armor4;
            string Tag = BuildTag1.ToString();

            Strict &= Tag == BuildTag2.ToString() & BuildTagBegin.ToString() == "BEGIN" &
                BuildTagEnd.ToString() == "END";

            var Base64Data = BuildBase64.ToString();
            var Data = BaseConvert.FromBase64urlString(Base64Data);

            var Result = new TaggedData {
                Strict = Strict,
                Count = Armor1,
                Tag = Tag,
                Data = Data};

            return Result;
            }

        }

    public class TaggedData {
        public bool Strict;
        public int Count;
        public string Tag;
        public byte[] Data;

        }

    }
