
//  Copyright (c) 2016 by .
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
using System;
using System.Collections.Generic;

using Goedel.Protocol;





namespace Goedel.XUnit {


    /// <summary>
    ///
    /// Classes to be used to test serialization an deserialization.
    /// </summary>
    public abstract partial class TestSchema : global::Goedel.Protocol.JsonObject {

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag => __Tag;

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public new const string __Tag = "TestSchema";

        /// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
        public static Dictionary<string, JsonFactoryDelegate> _TagDictionary =
                new() {

                        { "MultiInstance", MultiInstance._Factory },
                        { "MultiArray", MultiArray._Factory },
                        { "MultiStruct", MultiStruct._Factory }
                    };

        /// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JsonReader JSONReader, out JsonObject Out) =>
            Out = JSONReader.ReadTaggedObject(_TagDictionary);

        }



    // Service Dispatch Classes



    // Transaction Classes
    /// <summary>
    ///
    /// Contains one instance of each type of field.
    /// </summary>
    public partial class MultiInstance : TestSchema {
        bool __FieldBoolean = false;
        private bool _FieldBoolean;
        /// <summary>
        /// </summary>

        public virtual bool FieldBoolean {
            get => _FieldBoolean;
            set { _FieldBoolean = value; __FieldBoolean = true; }
            }
        bool __FieldInteger = false;
        private int _FieldInteger;
        /// <summary>
        /// </summary>

        public virtual int FieldInteger {
            get => _FieldInteger;
            set { _FieldInteger = value; __FieldInteger = true; }
            }
        /// <summary>
        /// </summary>

        public virtual DateTime? FieldDateTime { get; set; }
        /// <summary>
        /// </summary>

        public virtual string FieldString { get; set; }
        /// <summary>
        /// </summary>

        public virtual byte[] FieldBinary { get; set; }

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag => __Tag;

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public new const string __Tag = "MultiInstance";

        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
        public static new JsonObject _Factory() => new MultiInstance();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize(Writer Writer, bool wrap, ref bool first) =>
            SerializeX(Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX(Writer _Writer, bool _wrap, ref bool _first) {
            if (_wrap) {
                _Writer.WriteObjectStart();
                }
            if (__FieldBoolean) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("FieldBoolean", 1);
                _Writer.WriteBoolean(FieldBoolean);
                }
            if (__FieldInteger) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("FieldInteger", 1);
                _Writer.WriteInteger32(FieldInteger);
                }
            if (FieldDateTime != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("FieldDateTime", 1);
                _Writer.WriteDateTime(FieldDateTime);
                }
            if (FieldString != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("FieldString", 1);
                _Writer.WriteString(FieldString);
                }
            if (FieldBinary != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("FieldBinary", 1);
                _Writer.WriteBinary(FieldBinary);
                }
            if (_wrap) {
                _Writer.WriteObjectEnd();
                }
            }

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MultiInstance FromJson(JsonReader JSONReader, bool Tagged = true) {
            if (JSONReader == null) {
                return null;
                }
            if (Tagged) {
                var Out = JSONReader.ReadTaggedObject(_TagDictionary);
                return Out as MultiInstance;
                }
            var Result = new MultiInstance();
            Result.Deserialize(JSONReader);
            return Result;
            }

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken(JsonReader JSONReader, string Tag) {

            switch (Tag) {
                case "FieldBoolean": {
                    FieldBoolean = JSONReader.ReadBoolean();
                    break;
                    }
                case "FieldInteger": {
                    FieldInteger = JSONReader.ReadInteger32();
                    break;
                    }
                case "FieldDateTime": {
                    FieldDateTime = JSONReader.ReadDateTime();
                    break;
                    }
                case "FieldString": {
                    FieldString = JSONReader.ReadString();
                    break;
                    }
                case "FieldBinary": {
                    FieldBinary = JSONReader.ReadBinary();
                    break;
                    }
                default: {
                    break;
                    }
                }
            // check up that all the required elements are present
            }


        }

    /// <summary>
    /// </summary>
    public partial class MultiArray : MultiInstance {
        /// <summary>
        /// </summary>

        public virtual List<bool> ArrayBoolean { get; set; }
        /// <summary>
        /// </summary>

        public virtual List<int> ArrayInteger { get; set; }
        /// <summary>
        /// </summary>

        public virtual List<DateTime?> ArrayDateTime { get; set; }
        /// <summary>
        /// </summary>

        public virtual List<string> ArrayString { get; set; }
        /// <summary>
        /// </summary>

        public virtual List<byte[]> ArrayBinary { get; set; }

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag => __Tag;

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public new const string __Tag = "MultiArray";

        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
        public static new JsonObject _Factory() => new MultiArray();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize(Writer Writer, bool wrap, ref bool first) =>
            SerializeX(Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX(Writer _Writer, bool _wrap, ref bool _first) {
            if (_wrap) {
                _Writer.WriteObjectStart();
                }
            ((MultiInstance)this).SerializeX(_Writer, false, ref _first);
            if (ArrayBoolean != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("ArrayBoolean", 1);
                _Writer.WriteArrayStart();
                bool _firstarray = true;
                foreach (var _index in ArrayBoolean) {
                    _Writer.WriteArraySeparator(ref _firstarray);
                    _Writer.WriteBoolean(_index);
                    }
                _Writer.WriteArrayEnd();
                }

            if (ArrayInteger != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("ArrayInteger", 1);
                _Writer.WriteArrayStart();
                bool _firstarray = true;
                foreach (var _index in ArrayInteger) {
                    _Writer.WriteArraySeparator(ref _firstarray);
                    _Writer.WriteInteger32(_index);
                    }
                _Writer.WriteArrayEnd();
                }

            if (ArrayDateTime != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("ArrayDateTime", 1);
                _Writer.WriteArrayStart();
                bool _firstarray = true;
                foreach (var _index in ArrayDateTime) {
                    _Writer.WriteArraySeparator(ref _firstarray);
                    _Writer.WriteDateTime(_index);
                    }
                _Writer.WriteArrayEnd();
                }

            if (ArrayString != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("ArrayString", 1);
                _Writer.WriteArrayStart();
                bool _firstarray = true;
                foreach (var _index in ArrayString) {
                    _Writer.WriteArraySeparator(ref _firstarray);
                    _Writer.WriteString(_index);
                    }
                _Writer.WriteArrayEnd();
                }

            if (ArrayBinary != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("ArrayBinary", 1);
                _Writer.WriteArrayStart();
                bool _firstarray = true;
                foreach (var _index in ArrayBinary) {
                    _Writer.WriteArraySeparator(ref _firstarray);
                    _Writer.WriteBinary(_index);
                    }
                _Writer.WriteArrayEnd();
                }

            if (_wrap) {
                _Writer.WriteObjectEnd();
                }
            }

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MultiArray FromJson(JsonReader JSONReader, bool Tagged = true) {
            if (JSONReader == null) {
                return null;
                }
            if (Tagged) {
                var Out = JSONReader.ReadTaggedObject(_TagDictionary);
                return Out as MultiArray;
                }
            var Result = new MultiArray();
            Result.Deserialize(JSONReader);
            return Result;
            }

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken(JsonReader JSONReader, string Tag) {

            switch (Tag) {
                case "ArrayBoolean": {
                    // Have a sequence of values
                    bool _Going = JSONReader.StartArray();
                    ArrayBoolean = new List<bool>();
                    while (_Going) {
                        bool _Item = JSONReader.ReadBoolean();
                        ArrayBoolean.Add(_Item);
                        _Going = JSONReader.NextArray();
                        }
                    break;
                    }
                case "ArrayInteger": {
                    // Have a sequence of values
                    bool _Going = JSONReader.StartArray();
                    ArrayInteger = new List<int>();
                    while (_Going) {
                        int _Item = JSONReader.ReadInteger32();
                        ArrayInteger.Add(_Item);
                        _Going = JSONReader.NextArray();
                        }
                    break;
                    }
                case "ArrayDateTime": {
                    // Have a sequence of values
                    bool _Going = JSONReader.StartArray();
                    ArrayDateTime = new List<DateTime?>();
                    while (_Going) {
                        DateTime? _Item = JSONReader.ReadDateTime();
                        ArrayDateTime.Add(_Item);
                        _Going = JSONReader.NextArray();
                        }
                    break;
                    }
                case "ArrayString": {
                    // Have a sequence of values
                    bool _Going = JSONReader.StartArray();
                    ArrayString = new List<string>();
                    while (_Going) {
                        string _Item = JSONReader.ReadString();
                        ArrayString.Add(_Item);
                        _Going = JSONReader.NextArray();
                        }
                    break;
                    }
                case "ArrayBinary": {
                    // Have a sequence of values
                    bool _Going = JSONReader.StartArray();
                    ArrayBinary = new List<byte[]>();
                    while (_Going) {
                        byte[] _Item = JSONReader.ReadBinary();
                        ArrayBinary.Add(_Item);
                        _Going = JSONReader.NextArray();
                        }
                    break;
                    }
                default: {
                    base.DeserializeToken(JSONReader, Tag);
                    break;
                    }
                }
            // check up that all the required elements are present
            }


        }

    /// <summary>
    /// </summary>
    public partial class MultiStruct : MultiArray {
        /// <summary>
        /// </summary>

        public virtual MultiInstance FieldMultiInstance { get; set; }
        /// <summary>
        /// </summary>

        public virtual List<MultiInstance> ArrayMultiInstance { get; set; }
        /// <summary>
        /// </summary>

        public virtual MultiInstance TFieldMultiInstance { get; set; }
        /// <summary>
        /// </summary>

        public virtual List<MultiInstance> TArrayMultiInstance { get; set; }

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag => __Tag;

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public new const string __Tag = "MultiStruct";

        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
        public static new JsonObject _Factory() => new MultiStruct();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize(Writer Writer, bool wrap, ref bool first) =>
            SerializeX(Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX(Writer _Writer, bool _wrap, ref bool _first) {
            if (_wrap) {
                _Writer.WriteObjectStart();
                }
            ((MultiArray)this).SerializeX(_Writer, false, ref _first);
            if (FieldMultiInstance != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("FieldMultiInstance", 1);
                FieldMultiInstance.Serialize(_Writer, false);
                }
            if (ArrayMultiInstance != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("ArrayMultiInstance", 1);
                _Writer.WriteArrayStart();
                bool _firstarray = true;
                foreach (var _index in ArrayMultiInstance) {
                    _Writer.WriteArraySeparator(ref _firstarray);
                    // This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
                    bool firstinner = true;
                    _index.Serialize(_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
                    }
                _Writer.WriteArrayEnd();
                }

            if (TFieldMultiInstance != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("TFieldMultiInstance", 1);
                // expand this to a tagged structure
                //TFieldMultiInstance.Serialize (_Writer, false);
                    {
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(TFieldMultiInstance._Tag, 1);
                    bool firstinner = true;
                    TFieldMultiInstance.Serialize(_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
                    }
                }
            if (TArrayMultiInstance != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("TArrayMultiInstance", 1);
                _Writer.WriteArrayStart();
                bool _firstarray = true;
                foreach (var _index in TArrayMultiInstance) {
                    _Writer.WriteArraySeparator(ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index._Tag, 1);
                    bool firstinner = true;
                    _index.Serialize(_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
                    }
                _Writer.WriteArrayEnd();
                }

            if (_wrap) {
                _Writer.WriteObjectEnd();
                }
            }

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MultiStruct FromJson(JsonReader JSONReader, bool Tagged = true) {
            if (JSONReader == null) {
                return null;
                }
            if (Tagged) {
                var Out = JSONReader.ReadTaggedObject(_TagDictionary);
                return Out as MultiStruct;
                }
            var Result = new MultiStruct();
            Result.Deserialize(JSONReader);
            return Result;
            }

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken(JsonReader JSONReader, string Tag) {

            switch (Tag) {
                case "FieldMultiInstance": {
                    // An untagged structure
                    FieldMultiInstance = new MultiInstance();
                    FieldMultiInstance.Deserialize(JSONReader);

                    break;
                    }
                case "ArrayMultiInstance": {
                    // Have a sequence of values
                    bool _Going = JSONReader.StartArray();
                    ArrayMultiInstance = new List<MultiInstance>();
                    while (_Going) {
                        // an untagged structure.
                        var _Item = new MultiInstance();
                        _Item.Deserialize(JSONReader);
                        // var _Item = new MultiInstance (JSONReader);
                        ArrayMultiInstance.Add(_Item);
                        _Going = JSONReader.NextArray();
                        }
                    break;
                    }
                case "TFieldMultiInstance": {
                    TFieldMultiInstance = MultiInstance.FromJson(JSONReader, true);  // A tagged structure
                    break;
                    }
                case "TArrayMultiInstance": {
                    // Have a sequence of values
                    bool _Going = JSONReader.StartArray();
                    TArrayMultiInstance = new List<MultiInstance>();
                    while (_Going) {
                        var _Item = MultiInstance.FromJson(JSONReader, true); // a tagged structure
                        TArrayMultiInstance.Add(_Item);
                        _Going = JSONReader.NextArray();
                        }
                    break;
                    }
                default: {
                    base.DeserializeToken(JSONReader, Tag);
                    break;
                    }
                }
            // check up that all the required elements are present
            }


        }

    }

