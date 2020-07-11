﻿
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
using Goedel.Protocol;

using System;
using System.Collections.Generic;


namespace Goedel.XUnit {


    /// <summary>
    ///
    /// Classes that represent data written to the portal log.
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
                new Dictionary<string, JsonFactoryDelegate>() {

            {"TestEntry", TestEntry._Factory},
            {"TestItem", TestItem._Factory}         };

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
    /// An entry in the test log
    /// </summary>
    abstract public partial class TestEntry : TestSchema {
        /// <summary>
        ///Time the pending item was created.
        /// </summary>

        public virtual DateTime? Created { get; set; }
        /// <summary>
        ///Time the pending item was last modified.
        /// </summary>

        public virtual DateTime? Modified { get; set; }

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag => __Tag;

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public new const string __Tag = "TestEntry";

        /// <summary>
        /// Factory method. Throws exception as this is an abstract class.
        /// </summary>
        /// <returns>Object of this type</returns>
        public static new JsonObject _Factory() => throw new CannotCreateAbstract();


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
            if (Created != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("Created", 1);
                _Writer.WriteDateTime(Created);
                }
            if (Modified != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("Modified", 1);
                _Writer.WriteDateTime(Modified);
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
        public static new TestEntry FromJson(JsonReader JSONReader, bool Tagged = true) {
            if (JSONReader == null) {
                return null;
                }
            if (Tagged) {
                var Out = JSONReader.ReadTaggedObject(_TagDictionary);
                return Out as TestEntry;
                }
            throw new CannotCreateAbstract();
            }

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken(JsonReader JSONReader, string Tag) {

            switch (Tag) {
                case "Created": {
                    Created = JSONReader.ReadDateTime();
                    break;
                    }
                case "Modified": {
                    Modified = JSONReader.ReadDateTime();
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
    ///
    /// Test account...
    /// </summary>
    public partial class TestItem : TestEntry {
        /// <summary>
        ///Assigned account identifier, e.g. 'alice@example.com'. Account names are 
        ///not case sensitive.
        /// </summary>

        public virtual string AccountID { get; set; }
        /// <summary>
        ///Fingerprint of associated user profile
        /// </summary>

        public virtual string UserProfileUDF { get; set; }
        /// <summary>
        ///Status of the account, valid values are 'Open', 'Closed',
        ///'Suspended'
        /// </summary>

        public virtual string Status { get; set; }

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag => __Tag;

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public new const string __Tag = "TestItem";

        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
        public static new JsonObject _Factory() => new TestItem();


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
            ((TestEntry)this).SerializeX(_Writer, false, ref _first);
            if (AccountID != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("AccountID", 1);
                _Writer.WriteString(AccountID);
                }
            if (UserProfileUDF != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("UserProfileUDF", 1);
                _Writer.WriteString(UserProfileUDF);
                }
            if (Status != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("Status", 1);
                _Writer.WriteString(Status);
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
        public static new TestItem FromJson(JsonReader JSONReader, bool Tagged = true) {
            if (JSONReader == null) {
                return null;
                }
            if (Tagged) {
                var Out = JSONReader.ReadTaggedObject(_TagDictionary);
                return Out as TestItem;
                }
            var Result = new TestItem();
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
                case "AccountID": {
                    AccountID = JSONReader.ReadString();
                    break;
                    }
                case "UserProfileUDF": {
                    UserProfileUDF = JSONReader.ReadString();
                    break;
                    }
                case "Status": {
                    Status = JSONReader.ReadString();
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

