//   Copyright © 2015 by Comodo Group Inc.
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
//  

using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {
    public abstract partial class JSONObject {

        /// <summary>
        /// Initialization constructor. Allows automatically generated 
        /// constructors to be overriden in child classes.
        /// </summary>
        protected virtual void _Initialize () {
            }

		public virtual string Tag () {
			return "MeshItem";
			}

		public JSONObject () {
            _Initialize();
			}
		public JSONObject (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}
        public JSONObject(string _String) {
			Deserialize (_String);
			}

		public override string ToString () {
			JSONWriter _JSONWriter = new JSONWriter ();
			Serialize (_JSONWriter, true);
			return _JSONWriter.GetUTF8;
			}

		public virtual  string GetUTF8 () {
			JSONWriter _JSONWriter = new JSONWriter ();
			Serialize (_JSONWriter, true);
			return _JSONWriter.GetUTF8;
			}

		public virtual  byte [] GetBytes () {
            return GetBytes(true);
            }

        public virtual byte[] GetBytes(bool tag) {
            JSONWriter _JSONWriter = new JSONWriter();
            Serialize(_JSONWriter, tag);
            return _JSONWriter.GetBytes;
            }

        public virtual void Serialize (Writer Writer) {
			Serialize (Writer, false);
			}

		public virtual void Serialize (Writer Writer, bool tag) {
			bool first = true;
			if (tag) {
				Writer.WriteObjectStart ();
				Writer.WriteToken(Tag(), 0);
				}
			
			Serialize (Writer, true, ref first);
			
			if (tag) {
				Writer.WriteObjectEnd ();
				}			
			}

		public virtual void Serialize (Writer Writer, bool wrap, ref bool first) {
			}

		public void SerializeX (Writer Writer, bool wrap, ref bool first) {
			}


        public static JSONObject From(byte[] _Data) {
            return null;
            }

        public static JSONObject From(string _Input) {
            return null;
            }

        public static JSONObject FromTagged(byte[] _Data) {
            return null;
            }

        public static JSONObject FromTagged(string _Input) {
            return null;
            }

        public virtual void Deserialize (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			Deserialize (JSONReader);
			}

        public static void FromTagged(JSONReader JSONReader) {
            }

        public virtual void Deserialize(JSONReader JSONReader) {

            bool Going = JSONReader.StartObject();
            while (Going) {
                string Token = JSONReader.ReadToken();
                if (Token == null) {
                    Going = false;
                    }
                else {
                    DeserializeToken(JSONReader, Token);
                    }
                Going = JSONReader.NextObject();
                }
            // JSONReader.EndObject (); Implicit 
            }

        public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
			} 


        }
    }
