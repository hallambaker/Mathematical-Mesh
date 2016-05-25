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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Goedel.Protocol;

namespace Goedel.Mesh {

    /// <summary>
    /// Convenience class for reading and writing windows registry values to 
    /// an XML file.
    /// </summary>
    public class ConfigRegistry {
        string _Name;
        /// <summary>
        /// The registry name, used to create the topmost element.
        /// </summary>
        public virtual string Name {
            get {
                return _Name;
                }
            }

        /// <summary>
        /// Sorted dictionary mapping registry keys to entries. The original insertion
        /// order is preserved unless changed by the calling code (e.g. to sort). 
        /// Updated elements will remain in their original position.
        /// </summary>
        public SortedDictionary<string, ConfigRegistryEntry> Dictionary;

        /// <summary>
        /// Construct a new instance.
        /// </summary>
        /// <param name="Name">The topmost element of the registry.</param>
        public ConfigRegistry(string Name) {
            this._Name = Name;
            Dictionary = new SortedDictionary<string, ConfigRegistryEntry>();
            }

        /// <summary>
        /// Construct a new instance.
        /// </summary>
        /// <param name="Name">The topmost element of the registry.</param>
        /// <param name="FileName">The file to read</param>/// 
        public ConfigRegistry(string Name, string FileName) : this (Name) {
            Read(FileName);
            }


        /// <summary>
        /// Read the registry from an XML file.
        /// </summary>
        /// <param name="FileName">The file to read</param>
        public void Read(string FileName) {
            using (var Stream = new StreamReader(FileName)) {
                using (var Reader = XmlReader.Create(Stream)) {
                    Read(Reader);
                    }
                }
            }

        /// <summary>
        /// Read the registry from an XML stream.
        /// </summary>
        /// <param name="Reader">The stream to read</param>
        public void Read(XmlReader Reader) {

            string Name = null;
            string Type = null;

            while (Reader.Read()) {
                switch (Reader.NodeType) {
                    case XmlNodeType.Element: {
                        Name = Reader.Name;
                        Type = Reader.GetAttribute("type");
                        break;
                        }
                    case XmlNodeType.Text: {
                        Set(Name, Type, Reader.Value);
                        break;
                        }
                    }

                }
            }
        /// <summary>
        /// Write the registry to an XML file.
        /// </summary>
        /// <param name="FileName">The file to write.</param>
        public void Write(string FileName) {
            using (var Stream = new StreamWriter(FileName)) {
                var XmlWriterSettings = new XmlWriterSettings();
                XmlWriterSettings.Indent = true;
                using (var Writer = XmlWriter.Create(Stream, XmlWriterSettings)) {
                    Write(Writer);
                    }
                }
            }

        /// <summary>
        /// Write the registry to an XML stream.
        /// </summary>
        /// <param name="Writer">The stream to write</param>
        public void Write(XmlWriter Writer) {
            Writer.WriteStartElement(Name);
            foreach (var Entry in Dictionary) {
                Entry.Value.Write(Entry.Key, Writer);
                }
            Writer.WriteEndElement();
            Writer.Flush();
            }

        /// <summary>
        /// Lookup the key value and return the corresponding ConfigRegistryEntry.
        /// </summary>
        /// <param name="Key">The key to lookup.</param>
        /// <returns>Registry entry or null if not found.</returns>
        public ConfigRegistryEntry Get(string Key) {
            ConfigRegistryEntry Entry;
            bool Found = Dictionary.TryGetValue(Key, out Entry);
            return Found ? Entry : null;
            }

        /// <summary>
        /// Lookup the key value and return the corresponding value.
        /// </summary>
        /// <param name="Key">The key to lookup.</param>
        /// <returns>Registry value or null if not found.</returns>
        public string GetSZ(string Key) {
            var Entry = Get(Key) as ConfigRegistryEntrySZ;
            return Entry == null ? null : Entry.Value;
            }

        /// <summary>
        /// Lookup the key value and return the corresponding value.
        /// </summary>
        /// <param name="Key">The key to lookup.</param>
        /// <returns>Registry value or 0 (default value) if not found.</returns>
        public uint GetDWORD(string Key) {
            var Entry = Get(Key) as ConfigRegistryEntryDWORD;
            return Entry == null ? 0 : Entry.Value;
            }

        /// <summary>
        /// Lookup the key value and return the corresponding value.
        /// </summary>
        /// <param name="Key">The key to lookup.</param>
        /// <returns>Registry value or null if not found.</returns>
        public byte[] GetBINARY(string Key) {
            var Entry = Get(Key) as ConfigRegistryEntryBINARY;
            return Entry == null ? null : Entry.Value;
            }

        /// <summary>
        /// Set the value of the specified key, creating a new value if necessary
        /// from a string.
        /// </summary>
        /// <param name="Key">The key to set.</param>
        /// <param name="Type">The type of data to create.</param>
        /// <param name="Value">The data value as a string.</param>
        /// <returns>true if a new value was created, otherwise false.</returns>
        public bool Set(string Key, string Type, string Value) {
            switch (Type) {
                case "SZ":{
                    return Set(Key, Value);
                    }
                case "DWORD":
                    {
                    return Set(Key, Convert.ToUInt32 (Value, 16));
                    }
                case "BINARY":
                    {
                    return Set(Key, BaseConvert.FromBase16String(Value));
                    }
                default:
                throw new Exception("Unknown Type");
                }


            }

        /// <summary>
        /// Set a key for a SZ value, creating a new key if necessary.
        /// </summary>
        /// <param name="Key">The key to set.</param>
        /// <param name="Value">The value to set it to.</param>
        /// <returns>true if a new value was created, otherwise false.</returns>
        public bool Set(string Key, string Value) {
            var Slot = Get(Key);
            if (Slot == null) {
                var NewEntry = new ConfigRegistryEntrySZ(Value);
                Dictionary.Add(Key, NewEntry);
                return true;
                }
            var Entry = Slot as ConfigRegistryEntrySZ;
            if (Entry == null) throw new Exception("Wrong type!");

            Entry.Value = Value;
            return false;
            }


        /// <summary>
        /// Set a key for a DWORD value, creating a new key if necessary.
        /// </summary>
        /// <param name="Key">The key to set.</param>
        /// <param name="Value">The value to set it to.</param>
        /// <returns>true if a new value was created, otherwise false.</returns>
        public bool Set(string Key, uint Value) {
            var Slot = Get(Key);
            if (Slot == null) {
                var NewEntry = new ConfigRegistryEntryDWORD(Value);
                Dictionary.Add(Key, NewEntry);
                return true;
                }
            var Entry = Slot as ConfigRegistryEntryDWORD;
            if (Entry == null) throw new Exception("Wrong type!");

            Entry.Value = Value;
            return false;
            }

        /// <summary>
        /// Set a key for a BINARY value, creating a new key if necessary.
        /// </summary>
        /// <param name="Key">The key to set.</param>
        /// <param name="Value">The value to set it to.</param>
        /// <returns>true if a new value was created, otherwise false.</returns>
        public bool Set(string Key, byte[] Value) {
            var Slot = Get(Key);
            if (Slot == null) {
                var NewEntry = new ConfigRegistryEntryBINARY(Value);
                Dictionary.Add(Key, NewEntry);
                return true;
                }
            var Entry = Slot as ConfigRegistryEntryBINARY;
            if (Entry == null) throw new Exception("Wrong type!");

            Entry.Value = Value;
            return false;
            }

        }

    /// <summary>
    /// Parent class for registry entries.
    /// </summary>
    public abstract class ConfigRegistryEntry {

        /// <summary>
        /// Write the value to an XML stream.
        /// </summary>
        /// <param name="Key">The key to write</param>
        /// <param name="Writer"></param>
        public abstract void Write(string Key, XmlWriter Writer);
        }

    /// <summary>
    /// Registry entry for null terminated string.
    /// </summary>
    public class ConfigRegistryEntrySZ : ConfigRegistryEntry {
        /// <summary>
        /// The entry value
        /// </summary>
        public string Value;

        /// <summary>
        /// Construct a new instance.
        /// </summary>
        /// <param name="Value">the initial value of the entry.</param>
        public ConfigRegistryEntrySZ(string Value) {
            this.Value = Value;
            }

        /// <summary>
        /// Write the formatted value to an XML stream.
        /// </summary>
        /// <param name="Key">The registry key/XML element name.</param>
        /// <param name="Writer">The writer to output the entry to.</param>
        public override void Write(string Key, XmlWriter Writer) {
            Writer.WriteStartElement(Key);
            Writer.WriteAttributeString("type", "SZ");
            Writer.WriteString(Value);
            Writer.WriteEndElement();
            }
        }



    /// <summary>
    /// Registry entry for unsigned 32 bit integer.
    /// </summary>
    public class ConfigRegistryEntryDWORD : ConfigRegistryEntry {
        /// <summary>
        /// The entry value
        /// </summary>
        public uint Value;

        /// <summary>
        /// Construct a new instance.
        /// </summary>
        /// <param name="Value">the initial value of the entry.</param>
        public ConfigRegistryEntryDWORD(uint Value) {
            this.Value = Value;
            }

        /// <summary>
        /// Write the formatted value to an XML stream.
        /// </summary>
        /// <param name="Key">The registry key/XML element name.</param>
        /// <param name="Writer">The writer to output the entry to.</param>
        public override void Write(string Key, XmlWriter Writer) {
            Writer.WriteStartElement(Key);
            Writer.WriteAttributeString("type", "DWORD");
            Writer.WriteString(Value.ToString ("x8"));
            Writer.WriteEndElement();
            }
        }

    /// <summary>
    /// Registry entry for binary data.
    /// </summary>
    public class ConfigRegistryEntryBINARY : ConfigRegistryEntry {
        /// <summary>
        /// The entry value
        /// </summary>
        public byte[] Value;

        /// <summary>
        /// Construct a new instance.
        /// </summary>
        /// <param name="Value">the initial value of the entry.</param>
        public ConfigRegistryEntryBINARY(byte[] Value) {
            this.Value = Value;
            }

        /// <summary>
        /// Write the formatted value to an XML stream.
        /// </summary>
        /// <param name="Key">The registry key/XML element name.</param>
        /// <param name="Writer">The writer to output the entry to.</param>
        public override void Write(string Key, XmlWriter Writer) {
            Writer.WriteStartElement(Key);
            Writer.WriteAttributeString("type", "BINARY");
            foreach (var Byte in Value) {
                Writer.WriteString(Byte.ToString("x2"));
                }

            Writer.WriteEndElement();
            }
        }
    }
