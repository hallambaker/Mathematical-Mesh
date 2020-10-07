using System;
using System.Collections.Generic;


// should add in a class that the _Parser class can inherit from.
// Will make it easier to then pass the parser to the lexer as a class rather than
// as a delegate.


namespace Goedel.Registry {

    /// <summary>
    /// Base class for all Goedel parsers.
    /// </summary>
    public abstract class Parser {

        /// <summary>Start and elapsed time</summary>
        public Dispatch Options;

        /// <summary>
        /// Process a an input token. This is a push parser that is fed tokens
        /// each time it is called.
        /// </summary>
        /// <param name="Token">The token to process</param>
        /// <param name="Position">Position in the file</param>
        /// <param name="Text">Token text</param>
        public virtual void Process(
                        TokenType Token, Position Position, string Text) {
            }

        /// <summary>Initialize.</summary>
        public virtual void Init() {
            }

        }

    /// <summary>Track start and end time of parse.</summary>
    public abstract class Dispatch {
        /// <summary>Record start time.</summary>
        public DateTime Started = DateTime.Now;

        /// <summary>Calculate elapsed time.</summary>
        public TimeSpan Elapsed => DateTime.Now - Started;

        }





    /// <summary>
    /// Track a data source
    /// </summary>
    public class Source {

        /// <summary>The source name</summary>
        public string Name { get; private set; }

        /// <summary>
        /// Create a source
        /// </summary>
        /// <param name="NameIn">The source name</param>
        public Source(string NameIn) => Name = NameIn;


        /// <summary>
        /// Convert position to text.
        /// </summary>
        /// <returns>The string value</returns>
        public override string ToString() => Name;
        }

    /// <summary>Track position in a source file.</summary>
    public class Position {
        /// <summary>The input source</summary>
        public Source File;
        /// <summary>Line number</summary>
        public int Ln = 0;
        /// <summary>Column number</summary>
        public int Col = 0;
        /// <summary>The current character</summary>
        public int Ch = 0;

        /// <summary>
        /// Convert position to text.
        /// </summary>
        /// <returns>The string value</returns>
        public override string ToString() => ("Line " + Ln.ToString() + " Col " + Col.ToString() + " in :" + File.Name);

        /// <summary>
        /// Create new position.
        /// </summary>
        /// <param name="NameIn">Name of the source.</param>
        public Position(string NameIn) => File = new Source(NameIn);
        }

    /// <summary>
    /// Goedel parser type and instance registry.
    /// </summary>
    /// <typeparam name="T">The parse tree type.</typeparam>
    public class Registry<T> where T : class {
        /// <summary>The input sources</summary>
        public List<Source> Files = new List<Source>();
        /// <summary>The types</summary>
        public List<TYPE<T>> Types = new List<TYPE<T>>();
        /// <summary>The identifiers.</summary>
        public List<ID<T>> IDs = new List<ID<T>>();

        /// <summary>Construct new registry.</summary>
        public Registry() {
            }

        //http://msdn.microsoft.com/en-us/library/x0b5b5bc.aspx

        /// <summary>
        /// Set the current source file.
        /// </summary>
        /// <param name="file">The file name.</param>
        /// <returns>The source record.</returns>
        public Source SetFile(string file) {
            Source result = new Source(file);
            Files.Add(result);
            return result;
            }

        /// <summary>
        /// Locate a type by name
        /// </summary>
        /// <param name="Token">the type name</param>
        /// <returns>the type if found.</returns>
        public TYPE<T> FindType(string Token) {
            TYPE<T> result = Types.Find(
                delegate (TYPE<T> TT) {
                    return TT.Label == Token;
                    });
            return result;
            }

        /// <summary>
        /// Find identifier.
        /// </summary>
        /// <param name="Token">The name to find</param>
        /// <param name="Type">The type that must be matched.</param>
        /// <returns>The identifier record (if found).</returns>
        private ID<T> FindID(string Token, TYPE<T> Type) {
            try {
                ID<T> result = IDs.Find(
                    delegate (ID<T> TT) {
                        return TT.Label == Token;
                        });
                return result;
                }
            catch {
                return null;
                }
            }

        /// <summary>
        /// Find type and create if unknown.
        /// </summary>
        /// <param name="Text">The name to find</param>
        /// <returns>The type label.</returns>
        public TYPE<T> TYPE(string Text) {
            TYPE<T> result = new TYPE<T>() {
                Label = Text
                };
            Types.Add(result);
            return result;

            }

        /// <summary>
        /// Create identifier at a given source position.
        /// </summary>
        /// <param name="Position">Position in the source.</param>
        /// <param name="Text">The name</param>
        /// <param name="Type">The type</param>
        /// <param name="ObjectIn">The parse tree being constructed.</param>
        /// <returns>The identifier created</returns>
        public ID<T> ID(Position Position, string Text, TYPE<T> Type, T ObjectIn) {
            //Console.WriteLine ("Declare ID {0}", Text);

            ID<T> ID = FindID(Text, Type);

            if (ID != null) {
                if (ID.Declared) {
                    throw new Exception("Label already defined [" + Text + "]");
                    }
                ID.Object = ObjectIn;
                ID.Declared = true;
                return ID;
                }
            else {
                ID = new ID<T>(Position, Text, Type, true, ObjectIn);
                IDs.Add(ID);
                //Type.IDs.Add (ID);
                return ID;
                }
            }

        /// <summary>
        /// Create reference of specified type
        /// </summary>
        /// <param name="Position">Position in the source.</param>
        /// <param name="Text">The name</param>
        /// <param name="Type">The type</param>
        /// <param name="ObjectIn">The parse tree being constructed.</param>
        /// <returns>The reference created</returns>
        public REF<T> REF(Position Position, string Text, TYPE<T> Type, T ObjectIn) {
            ID<T> ID = FindID(Text, Type);

            if (ID == null) {
                ID = new ID<T>(Position, Text, Type, false, null);
                IDs.Add(ID);
                //Type.IDs.Add (ID);
                }

            REF<T> result = new REF<T>(Position, ID, ObjectIn);

            return result;
            }

        /// <summary>
        /// Create token of specified type
        /// </summary>
        /// <param name="Position">Position in the source.</param>
        /// <param name="Text">The name</param>
        /// <param name="Type">The type</param>
        /// <param name="ObjectIn">The parse tree being constructed.</param>
        /// <returns>The token created</returns>
        public TOKEN<T> TOKEN(Position Position, string Text, TYPE<T> Type, T ObjectIn) {
            ID<T> ID = FindID(Text, Type);

            if (ID == null) {
                ID = new ID<T>(Position, Text, Type, false, null);
                IDs.Add(ID);
                //Type.IDs.Add (ID);
                }

            TOKEN<T> result = new TOKEN<T>(Position, ID, ObjectIn);

            return result;
            }
        }

    /// <summary>
    /// A type.
    /// </summary>
    /// <typeparam name="T">The parser output type</typeparam>
    public class TYPE<T> where T : class {
        /// <summary>The type label</summary>
        public string Label;
        /// <summary>List of all references.</summary>
        public List<ID<T>> IDs = new List<ID<T>>();
        }

    /// <summary>
    /// An identifier
    /// </summary>
    /// <typeparam name="T">The parser output type</typeparam>
    public class ID<T> where T : class {
        /// <summary>Position in the source</summary>
        public Position Position;
        /// <summary>The label.</summary>
        public string Label;
        /// <summary>The declared type.</summary>
        public TYPE<T> Type;
        /// <summary>List of all references to this identifier</summary>
        public List<REF<T>> REFs;
        /// <summary>If true, the identifier has been declared in the
        /// source.</summary>
        public bool Declared;
        /// <summary>The parse tree being constructed.</summary>
        public T Object;


        /// <summary>
        /// Construct identifier at position in a source.
        /// </summary>
        /// <param name="Position">Position in the source.</param>
        /// <param name="Label">The name</param>
        /// <param name="Type">The type</param>
        /// <param name="Declared">If true, this is a declaration for the ID.</param>
        /// <param name="ObjectIn">The parse tree being constructed.</param>
        public ID(Position Position, string Label, TYPE<T> Type, bool Declared, T ObjectIn) {
            this.Position = Position;
            this.Label = Label;
            this.Declared = Declared;
            REFs = new List<REF<T>>();
            Object = ObjectIn;
            Type.IDs.Add(this);

            }

        /// <summary>
        /// Return the label value
        /// </summary>
        /// <returns>The label</returns>
        public override string ToString() => Label;
        }

    /// <summary>
    /// Reference to an identifier
    /// </summary>
    /// <typeparam name="T">The parser output type</typeparam>
    public class REF<T> where T : class {
        /// <summary>Position the reference occurs in the source.</summary>
        public Position Position;
        /// <summary>The identifier.</summary>
        public ID<T> ID;
        /// <summary>The parse tree being constructed.</summary>
        public T Object;

        /// <summary>
        /// Get the object being defined.
        /// </summary>
        public T Definition => ID?.Object;


        /// <summary>
        /// Default constructor.
        /// </summary>
        public REF() {
            }

        /// <summary>
        /// Construct a reference at a position in the source. Note that 
        /// references must be defined by exactly one identifier.
        /// </summary>
        /// <param name="Position">Position in the source.</param>
        /// <param name="ID">The identifier</param>
        /// <param name="ObjectIn">The parse tree being constructed.</param>
        public REF(Position Position, ID<T> ID, T ObjectIn) {
            this.Position = Position;
            this.ID = ID;
            Object = ObjectIn;
            this.ID.REFs.Add(this);
            }

        /// <summary>
        /// Return the label value
        /// </summary>
        /// <returns>The label</returns>
        public override string ToString() => ID.Label;

        /// <summary>
        /// Return the label value
        /// </summary>
        public string Label => ToString();

        }

    /// <summary>
    /// Token class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TOKEN<T> : REF<T> where T : class {

        /// <summary>
        /// Construct a token at a position in the source. A token MAY be defined
        /// but not defining a token does not cause an error to be thrown.
        /// </summary>
        /// <param name="Position">Position in the source.</param>
        /// <param name="ID">The identifier</param>
        /// <param name="ObjectIn">The parse tree being constructed.</param>
        public TOKEN(Position Position, ID<T> ID, T ObjectIn) {
            base.Position = Position;
            base.ID = ID;
            Object = ObjectIn;
            base.ID.REFs.Add(this);
            }

        /// <summary>
        /// Return the label value
        /// </summary>
        /// <returns>The label</returns>
        public override string ToString() => ID.Label;
        }

    }
